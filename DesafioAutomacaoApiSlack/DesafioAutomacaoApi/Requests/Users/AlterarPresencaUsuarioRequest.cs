using RestSharp;
using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Helpers;
using System.IO;
using System.Text;

namespace DesafioAutomacaoApi.Requests.Users

{
    public class AlterarPresencaUsuarioRequest : RequestBase
    {
        public AlterarPresencaUsuarioRequest(string presence)
        {
            requestService = "/api/users.setPresence";
            method = Method.POST;
            parameters.Add("presence", presence);
        }

        public void SetJsonBody(string presence)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Users/presenceJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$presence", presence);
        }
    }
}

