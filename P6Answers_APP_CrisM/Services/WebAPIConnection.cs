using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6Answers_APP_CrisM.Services
{
    public static class WebAPIConnection
    {
        //variable
        public static string BaseURL = "http://192.168.100.9:45455/api/";

        //incluir info de seguridad
        //para los end point del API

        public static string ApiKeyName = "ApiKey";
        public static string ApiKeyValue = "CrisP62024answer123";
    }
}
