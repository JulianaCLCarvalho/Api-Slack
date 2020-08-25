using Newtonsoft.Json;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApi.Helpers
{
    public class JsonSerializer : ISerializer
    {
        public string contentType = "application/json";
        public string ContentType
        { get => contentType;
          set => contentType = value;
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
