using ProjectForDemoOnly.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Services.Description;

namespace ProjectForDemoOnly.Services.MyAnimeList
{
    public static class AnimeService
    {
        // Status:
        public static string State = "Choose Service.";

        public static void DeleteCookies(HttpResponseBase response)
        {
            var cookieNames = new List<string> { "serverType", "apiKey", "apiValue" };

            foreach (var name in cookieNames)
            {
                if (response.Cookies[name] != null)
                {
                    var expiredCookie = new HttpCookie(name)
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };
                    response.Cookies.Add(expiredCookie);
                }
            }

            State = "Choose Service.";
        }

        public static void SaveConnectionCookies(HttpResponseBase response, ChooseConnector connectorType, string apiKey, string apiValue)
        {
            // Delete old Cookies Service Type.
            DeleteCookies(response);

            // Create new Cookie Sevice Type.
            var cookies = new List<HttpCookie> {
                new HttpCookie("serverType", connectorType.ToString()),
                new HttpCookie("apiKey", apiKey),
                new HttpCookie("apiValue", apiValue)
            };

            // Set Cookie Expires.
            foreach (var cookie in cookies) {
                cookie.Expires = DateTime.Now.AddMinutes(5);
                response.Cookies.Add(cookie);
            }

            State = $"Config Service ({connectorType}) is Save.";
        }

        public static IMALServices InitService(HttpRequestBase request)
        {
            var connectorStr = request.Cookies["serverType"]?.Value;
            var apiKey = request.Cookies["apiKey"]?.Value;
            var apiValue = request.Cookies["apiValue"]?.Value;

            // handle cookie.
            if (string.IsNullOrEmpty(connectorStr) 
                || string.IsNullOrEmpty(apiKey) 
                || string.IsNullOrEmpty(apiValue)) return null;

            // Parse Type Service.
            var connectorType = (ChooseConnector)Enum.Parse(typeof(ChooseConnector), connectorStr);
            
            // Create Service.
            return CreateConnect(connectorType, apiKey, apiValue);
        }

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