using RestSharp;
using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Helpers;
using System.IO;
using System.Text;

namespace DesafioAutomacaoApi.Requests.Channels

{
    public class DefinirUmTopicoDoCanalRequest : RequestBase
    {
        public DefinirUmTopicoDoCanalRequest(string channel, string topic)
        {
            requestService = "/api/channels.setTopic";
            method = Method.POST;
            parameters.Add("channel", channel);
            parameters.Add("topic", topic);
        }

        public void SetJsonBody(string channel, string topic)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Channels/topicJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$channel", channel);
            jsonBody = jsonBody.Replace("$topic", topic);
        }
    }
}

