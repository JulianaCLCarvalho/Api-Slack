using RestSharp;
using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Helpers;
using System.IO;
using System.Text;

namespace DesafioAutomacaoApi.Requests.Channels

{
    public class ArquivarUmCanalRequest : RequestBase
    {
        public ArquivarUmCanalRequest(string channel)
        {
            requestService = "api/channels.archive";
            method = Method.POST;
            parameters.Add("channel", channel);
        }

        public void SetJsonBody(string channel)

        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Channels/channelJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$channel", channel);
        }
    }
}

