using RestSharp;
using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Helpers;
using System.IO;
using System.Text;

namespace DesafioAutomacaoApi.Requests.Channels

{
    public class SairDoCanalRequest : RequestBase
    {
        public SairDoCanalRequest(string channel)
        {
            requestService = "/api/channels.leave";
            method = Method.POST;
            parameters.Add("channel",channel);
        }

        public void SetJsonBody(string channel)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Channels/channelJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$channel",channel);
        }
    }
}

