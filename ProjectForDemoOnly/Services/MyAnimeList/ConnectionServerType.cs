using System;
using System.Web;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;

namespace ProjectForDemoOnly.Services.MyAnimeList
{
    public interface MAL_ConnectorServerType
    {
        //
        string Connect();
        string Disconnect();
    }
}