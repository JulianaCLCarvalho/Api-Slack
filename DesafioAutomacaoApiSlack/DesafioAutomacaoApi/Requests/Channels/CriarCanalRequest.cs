using RestSharp;
using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Helpers;
using System.IO;
using System.Text;

namespace DesafioAutomacaoApi.Requests.Channels

{
    public class CriarCanalRequest : RequestBase
    {
        public CriarCanalRequest(string name)
        {
            requestService = "api/channels.create";
            method = Method.POST;
            parameters.Add("name", name);
        }

        public void SetJsonBody(string name)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Channels/nameJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$name", name);
        }
    }
}

