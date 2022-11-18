using System;

namespace Matriks.ApiClient.Api.ResposeModels
{
    [Serializable]
    public class ChangeLoggingModeResponseModel
    {
        public string Message { get; set; }
        public int LoggingMode { get; set; }
    }
}