using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6Answers_APP_CrisM.Models
{
    public class User
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }

        public int UsuarioID { get; set; }

        public string Nombre { get; set; }

        public string Contrasennia { get; set; } = null!;

    }
}
