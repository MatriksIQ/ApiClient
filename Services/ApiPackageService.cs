using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matriks.Api;
using Matriks.API.Shared;
using Matriks.Utility;
using MessagePack;
using MessagePack.Resolvers;
using Newtonsoft.Json;

namespace Matriks.ApiClient.Services
{
    public class ApiPackageService: IApiPackageService
    {
        private Crc16 _crc16;
        public ApiPackageService()
        {
            _crc16 = new Crc16();
        }

        public DataType DataType { get; set; } 

        public const byte Sync1 = 0xFF;
        public const byte Sync2 = 0xFA;

        public object Serialize(object obj)
        {
            switch (DataType)
            {
                case DataType.Json:
                    var jsonToSend = JsonConvert.SerializeObject(obj);
                    StringBuilder stringBuilder = new StringBuilder(jsonToSend);
                    stringBuilder.Append((char)11);
                    return stringBuilder.ToString();
                case DataType.MessagePack:
                    var payload = MessagePackSerializer.Serialize(obj, ContractlessStandardResolver.Instance);
                    
                    var syncCode = new byte[2]{Sync1,Sync2};
                    var packetSize = BitConverter.GetBytes(payload.Length);
                    var crc = BitConverter.GetBytes(_crc16.ComputeChecksum(0, 0, payload));
                    var packet = syncCode.Concat(packetSize).Concat(payload).Concat(crc);
                    return packet.ToArray();
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return null;
        }

        public T Deserialize<T>(Packet data)
        {
            switch (DataType)
            {
                case DataType.Json:
                    var packet = JsonConvert.DeserializeObject<T>(data.Text);
                    return packet;
                case DataType.MessagePack:
                    var bytePacket = data.Payload as byte[];
                    return MessagePack.MessagePackSerializer.Deserialize<T>(bytePacket, ContractlessStandardResolver.Instance);


                default:
                    throw new ArgumentOutOfRangeException();
            }

            return default(T);
        }




        private string CalculateChecksum(string dataToCalculate)
        {
            if (dataToCalculate == null)
                return "";
            byte[] byteToCalculate = Encoding.ASCII.GetBytes(dataToCalculate);
            return CalculateChecksum(byteToCalculate);
        }

        private string CalculateChecksum(byte[] byteToCalculate)
        {
            if (byteToCalculate == null)
                return "";
            int checksum = 0;
            foreach (byte chData in byteToCalculate)
            {
                checksum += chData;
            }
            checksum &= 0xff;
            return checksum.ToString("X2");
        }
    }
}

