﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Matriks.Api;
using Matriks.Api.RequestModels;
using Matriks.API.Shared;
using Matriks.ApiClient.Api;
using Matriks.ApiClient.Api.RequestModels;
using Matriks.ApiClient.Services;
using Matriks.ApiClient.TcpConnection;
using Newtonsoft.Json;

namespace Matriks.ApiClient
{
    public class TcpClientService
    {
        private TcpConnectionService _tcpConnectionService;
        private TcpCallbackService _tcpCallbackService;
        private ApiPackageService _apiPackageService;
        private ApiLoggingMode _apiLoggingMode;
        private ApiBroadcastMode _apiBroadcastMode;
        private string Ip { get; set; }
        private  int Port { get; set; }
        public TcpClientService(TcpCallbackService tcpCallbackService,string ip, int port, ApiLoggingMode apiLoggingMode = ApiLoggingMode.All, ApiBroadcastMode apiBroadcastMode = ApiBroadcastMode.All)
        {
            _tcpCallbackService = tcpCallbackService;
            _apiPackageService = new ApiPackageService();
            this.Ip = ip;
            this.Port = port;
            _apiLoggingMode = apiLoggingMode;
            _apiBroadcastMode = apiBroadcastMode;
        }


        public void InitializeTcpConnection()
        {
            _tcpConnectionService = new TcpConnectionService(_tcpCallbackService,Ip,Port);
            _tcpConnectionService.Connected += TcpConnectionServiceOnConnected;
            _tcpConnectionService.Connect(Ip, Port);
        }

        public void SetMessageType(DataType dataType)
        {
            _apiPackageService.DataType = dataType;
            _tcpConnectionService.SetDataType(dataType);
            _tcpConnectionService.SendToServer($"SetMessageType{(int)dataType}",DataType.Json);
        }


        private void TcpConnectionServiceOnConnected(object sender, bool e)
        {
            try
            {
                SetMessageType(DataType.Json);
                ChangeLoggingMode(_apiLoggingMode);
                ChangeBroadcastMode(_apiBroadcastMode);
                RequestAccounts();
            }
            catch (Exception exception)
            {
            }
        }

        public  void RequestWaitingOrders(string accountId,string brokageId,int exchangeId)
        {
            ListOrdersApiRequest packet = new ListOrdersApiRequest();
            packet.ApiCommands = (int)ApiCommands.ListOrders;
            packet.AccountId = accountId;
            packet.BrokageId = brokageId;
            packet.ExchangeId = exchangeId;
            var seriealizePacket = _apiPackageService.Serialize(packet);

            //var jsonText = CreateRequestPacket(packet);
            _tcpConnectionService.SendToServer(seriealizePacket,_apiPackageService.DataType);
        }

        public void RequestPositions(string brokageId,string accountId,int exchangeId)
        {
            ListPositionsApiModel packet = new ListPositionsApiModel();
            packet.ApiCommands = (int)ApiCommands.ListPositions;
            packet.AccountId = accountId;
            packet.BrokageId = brokageId;
            packet.ExchangeId = exchangeId;
            var jsonText = CreateRequestPacket(packet);
            _tcpConnectionService.SendToServer(jsonText,_apiPackageService.DataType);
        }

        public void RequestAccounts()
        {
            try
            {
                
                Packet packet = new Packet();
                packet.ApiCommands = (int)ApiCommands.ListAccounts;
                var jsonText = CreateRequestPacket(packet);
                _tcpConnectionService.SendToServer(jsonText, _apiPackageService.DataType);
            }
            catch (Exception e)
            {
            }
        }

        public void SendCancelOrder(OrderRequest orderApiModel)
        {

            orderApiModel.ApiCommands = (int)ApiCommands.CancelOrder;
            //var jsonText = JsonConvert.SerializeObject(orderApiModel);
            var objectToSend = _apiPackageService.Serialize(orderApiModel);
            SendToServer(objectToSend);
        }

        public void SendNewOrder(OrderRequest orderRequest)
        {
            orderRequest.ApiCommands = (int)ApiCommands.NewOrder;
            //var jsonText = JsonConvert.SerializeObject(orderRequest);
            var objectToSend = _apiPackageService.Serialize(orderRequest);
            SendToServer(objectToSend);
        }

        public void SendEditOrder(OrderRequest orderRequest)
        {
            orderRequest.ApiCommands = (int)ApiCommands.EditOrder;
            //var jsonText = JsonConvert.SerializeObject(orderRequest);

            var objectToSend = _apiPackageService.Serialize(orderRequest);
            SendToServer(objectToSend);
        }

        public void SendAccountInformationRequest(AccountInformationRequest request)
        {
            request.ApiCommands = (int)ApiCommands.GetAccountInformation;
            //var jsonText = JsonConvert.SerializeObject(orderRequest);

            var objectToSend = _apiPackageService.Serialize(request);
            SendToServer(objectToSend);
        }

        public void RequestFilledOrders(string accountId,string brokageId,int exchangeId)
        {
            ListFilledOrdersApiRequest packet = new ListFilledOrdersApiRequest();
            packet.ApiCommands = (int)ApiCommands.ListFilledOrders;
            packet.AccountId = accountId;
            packet.BrokageId = brokageId;
            packet.ExchangeId = exchangeId;
            var seriealizePacket = _apiPackageService.Serialize(packet);

            //var jsonText = CreateRequestPacket(packet);
            _tcpConnectionService.SendToServer(seriealizePacket,_apiPackageService.DataType);
        }

        public void RequestCanceledOrders(string accountId,string brokageId,int exchangeId)
        {
            ListCanceledOrdersApiRequest packet = new ListCanceledOrdersApiRequest();
            packet.ApiCommands = (int)ApiCommands.ListCanceledOrders;
            packet.AccountId = accountId;
            packet.BrokageId = brokageId;
            packet.ExchangeId = exchangeId;
            var seriealizePacket = _apiPackageService.Serialize(packet);

            //var jsonText = CreateRequestPacket(packet);
            _tcpConnectionService.SendToServer(seriealizePacket,_apiPackageService.DataType);
        }

        public void ChangeLoggingMode(ApiLoggingMode loggingMode)
        {
            _apiLoggingMode = loggingMode;
            ChangeLoggingModeRequest packet = new ChangeLoggingModeRequest((int)loggingMode);
            packet.ApiCommands = (int)ApiCommands.ChangeLoggingMode;
            var seriealizePacket = _apiPackageService.Serialize(packet);
            _tcpConnectionService.SendToServer(seriealizePacket,_apiPackageService.DataType);
        }
        public void ChangeBroadcastMode(ApiBroadcastMode broadcastMode)
        {
            _apiBroadcastMode = broadcastMode;
            ChangeBroadcastModeRequest packet = new ChangeBroadcastModeRequest((int)broadcastMode);
            packet.ApiCommands = (int)ApiCommands.ChangeBroadcastMode;
            var seriealizePacket = _apiPackageService.Serialize(packet);
            _tcpConnectionService.SendToServer(seriealizePacket,_apiPackageService.DataType);
        }

        public void SendKeepAlive()
        {
            var keepAlive = new KeepAlive();
            keepAlive.KeepAliveDate = DateTime.Now;
            keepAlive.ApiCommands = (int) ApiCommands.KeepAlive;
            var objectToSend = _apiPackageService.Serialize(keepAlive);
            SendToServer(objectToSend);
        }

        public object CreateRequestPacket(Packet pack)
        {
            var apiCommands = (ApiCommands)pack.ApiCommands;
            object result = null;
            switch (apiCommands)
            {
                case ApiCommands.ListAccounts:
                    result = _apiPackageService.Serialize(pack);
                    //result  = JsonConvert.SerializeObject(pack);
                    break;
                case ApiCommands.ListPositions:
                    result = _apiPackageService.Serialize(pack);
                    //result = JsonConvert.SerializeObject(pack);
                    break;
                case ApiCommands.ListOrders:
                    result = _apiPackageService.Serialize(pack);
                    //result = JsonConvert.SerializeObject(pack);
                    break;
                case ApiCommands.NewOrder:
                    result = _apiPackageService.Serialize(pack);
                    break;
                case ApiCommands.CancelOrder:
                    result = _apiPackageService.Serialize(pack);
                    break;
                case ApiCommands.EditOrder:
                    result = _apiPackageService.Serialize(pack);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        public void SendToServer(object objectToSend)
        {
            _tcpConnectionService.SendToServer(objectToSend, _apiPackageService.DataType);
        }

    }
}
