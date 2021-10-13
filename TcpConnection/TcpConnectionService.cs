using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using Matriks.Api;
using Matriks.API.Shared;
using Matriks.ApiClient.Services;
using MessagePack;
using MessagePack.Resolvers;
using Newtonsoft.Json;

namespace Matriks.ApiClient.TcpConnection
{
    public class TcpConnectionService
    {
        private static Timer _dummyTimer;
        static TcpClient _ipClient;
        private IPacketRouter _packetRouter;
        public event EventHandler<bool> Connected;
        private TcpCallbackService _tcpCallbackService;
        public const byte Sync1 = 0xFF;
        public const byte Sync2 = 0xFA;
        private IApiPackageService _apiPackageService;
        private string _ip;
        private int _port;


        public TcpConnectionService(TcpCallbackService tcpCallbackService,string ip,int port)
        {
            _dummyTimer = new Timer(6000);
            _dummyTimer.Elapsed += DummyTimerOnElapsed;
            InitializeTcpConnection();
            _tcpCallbackService = tcpCallbackService;
            _apiPackageService = new ApiPackageService();
            _packetRouter = new PacketRouter(_tcpCallbackService, _apiPackageService);
            this._ip = ip;
            this._port = port;
            
        }

        private void DummyTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (!_ipClient.Connected)
            {
                Connect(_ip, _port);
                return;
            }

            //var orderMessage = new OrderRequest("GARAN", 8,1, 0, false, '1', '1',
            //    '1', "0~801949", "7");
            //orderMessage.ApiCommands = (int)ApiCommands.NewOrder;
            //var jsonObject = JsonConvert.SerializeObject(orderMessage);
            //ipClient.DataToSend = jsonObject;
        }

        private void InitializeTcpConnection()
        {
            try
            {
                _ipClient = new TcpClient();
                //ipClient.Config("InBufferSize=30000000");
                //ipClient.Config("MaxLineLength=65536");
                //ipClient.Config("TcpNoDelay=true");
                _ipClient.OnConnected += IpClientOnOnConnected;
                _ipClient.OnDataIn += IpClientOnOnDataIn;
                _ipClient.OnDisconnected += IpClientOnOnDisconnected;
                _ipClient.OnConnectionStatus += IpClientOnOnConnectionStatus;
                _ipClient.OnReadyToSend +=IpClientOnOnReadyToSend;

                _dummyTimer.Start();
            }
            catch (Exception e)
            {
            }
        }

        private void IpClientOnOnReadyToSend(object sender, bool e)
        {
        }

        private void IpClientOnOnConnectionStatus(object sender, bool e)
        {
            throw new NotImplementedException();
        }

        private void IpClientOnOnDisconnected(object sender, bool e)
        {
            throw new NotImplementedException();
        }

        private void IpClientOnOnDataIn(object sender, OnDataInEventArgs e)
        {
            try
            {
                if (_dataType == DataType.Json)
                {
                    byte[] bytes = Encoding.Default.GetBytes(e.Text);
                    var encoded = Encoding.UTF8.GetString(bytes);
                    _stringBuilder.Append(encoded);
                    if (!encoded.EndsWith(UnicodeToUtf8(((char)11).ToString())))
                    {
                        return;
                    }


                    var splittedPackages = _stringBuilder.ToString().Split(_delims,
                        StringSplitOptions.RemoveEmptyEntries);

                    foreach (var splittedPackage in splittedPackages)
                    {
                        var packet = JsonConvert.DeserializeObject<Packet>(splittedPackage);
                        packet.Text = splittedPackage;
                        _packetRouter.Compute(packet);
                    }

                    _stringBuilder.Clear();
                }
                else if (_dataType == DataType.MessagePack)
                {
                    _memoryStream.Write(e.Bytes, 0, e.Bytes.Length);
                    _memoryStream.Position = 0;
                    ReadFromStream();
                }
            }
            catch (Exception exception)
            {

            }
        }

        private void IpClientOnOnConnected(object sender, bool e)
        {
            if (_ipClient.Connected)
                ConnectedEvent(true);
        }


        private void ipClient_OnDisconnected(object sender, OnDataInEventArgs e)
        {
            Console.WriteLine("Disconnected");
        }
        static string UnicodeToUtf8(string from)
        {
            var bytes = Encoding.UTF8.GetBytes(from);
            return new string(bytes.Select(b => (char)b).ToArray());
        }

        char[] _delims = new[] { (char)11 };
        StringBuilder _stringBuilder = new StringBuilder();
        MemoryStream _memoryStream = new MemoryStream();

        private void ReadFromStream()
        {
            if (_memoryStream.Length < 6)
                return;

            try
            {
                BinaryReader br = new BinaryReader(_memoryStream);
                if (br.ReadByte() == Sync1 && br.ReadByte() == Sync2)
                {

                    var packetSize = br.ReadInt32();
                    if (_memoryStream.Length < packetSize)
                        return;
                    var payload = br.ReadBytes(packetSize);
                    br.ReadInt16();
                    Console.WriteLine(MessagePackSerializer.ToJson(payload));
                    var packet = MessagePack.MessagePackSerializer.Deserialize<Packet>(payload, ContractlessStandardResolver.Instance);
                    packet.Payload = payload;
                    _packetRouter.Compute(packet);
                    var leftOverBytes = _memoryStream.ToArray().Skip(2 + 4 + 2 + packetSize).ToArray();
                    _memoryStream = new MemoryStream();
                    _memoryStream.Write(leftOverBytes, 0, leftOverBytes.Length);
                    if (leftOverBytes.Length > 0)
                    {
                        _memoryStream.Position = 0;
                        ReadFromStream();
                    }
                        
                }
                else
                    _memoryStream = new MemoryStream();
            }
            catch (Exception)
            {

                _memoryStream = new MemoryStream();
            }

        }

       
        private void ConnectedEvent(bool isConnected)
        {
            var handler = Connected;
            if (handler != null)
            {
                handler(this, isConnected);
            }

        }

        private DataType _dataType;

        public void SetDataType(DataType dataType)
        {
            _dataType = dataType;
        }

        public void SendToServer(object objectToSend, DataType dataType)
        {
            if(dataType== DataType.Json)
                _ipClient.SendMessage(objectToSend.ToString()); 
            else if (dataType == DataType.MessagePack)
                _ipClient.SendMessage(objectToSend as byte[]);
        }


        public bool Connect(string server, int port)
        {
            bool isOk = false;
            try
            {
                Task t = new Task(() =>
                    _ipClient.Start(server, port));
                t.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return isOk;
        }

    }
}
