using RestSharp;
using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Helpers;
using System.IO;
using System.Text;

namespace DesafioAutomacaoApi.Requests.Channels

{
    public class DefinirFinalidadeDeUmCanalRequest : RequestBase
    {
        public DefinirFinalidadeDeUmCanalRequest(string channel, string purpose)
        {
            requestService = "/api/channels.setPurpose";
            method = Method.POST;
            parameters.Add("channel", channel);
            parameters.Add("purpose", purpose);
        }

        public void SetJsonBody(string channel, string purpose)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Channels/purposeJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$channel", channel);
            jsonBody = jsonBody.Replace("$purpose", purpose);
        }
    }
}

