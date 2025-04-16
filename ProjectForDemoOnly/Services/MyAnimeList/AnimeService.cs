using System;
using System.Net.Http;

namespace ProjectForDemoOnly.Services.MyAnimeList
{
    public static class AnimeService
    {
        // Status:
        public static string State = "";

        public static IMALServices CreateConnect(ChooseConnector connectorType, string apiKey, string apiValue)
        {
            switch (connectorType)
            {
                case ChooseConnector.JsonServer:
                    
                    State = "Type connect: JsonServer. ";
                    return new JsonServerConnector();

                case ChooseConnector.RappiApi:
                    
                    if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiValue))
                        throw new ArgumentException("Đối với Rappiapi, apiKey và apiValue không được để trống.");
                    // return new JsonServerConnector();
                    
                    
                    State = "Type connect: Rapidapi. ";
                    return new RapidapiConnector(new HttpClient(), apiKey, apiValue);

                default:
                    
                    State = "Type connect: Not connect to Server.";
                    throw new NotSupportedException("Loại kết nối không được hỗ trợ.");
            }
        }
    }
}