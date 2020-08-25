using RestSharp;
using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Helpers;
using System.IO;
using System.Text;

namespace DesafioAutomacaoApi.Requests.Channels

{
    public class RenomearCanalRequest : RequestBase
    {
        public RenomearCanalRequest(string channel, string name)
        {
            requestService = "api/channels.rename";
            method = Method.POST;
            parameters.Add("channel", channel);
            parameters.Add("name", name);
        }

        public void SetJsonBody(string channel,
                                string name            
                                )
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Channels/renameJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$channel", channel);
            jsonBody = jsonBody.Replace("$name", name);
        }
    }
}

