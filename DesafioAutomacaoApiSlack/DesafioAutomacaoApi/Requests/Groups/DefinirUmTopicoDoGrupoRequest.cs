using RestSharp;
using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Helpers;
using System.IO;
using System.Text;

namespace DesafioAutomacaoApi.Requests.Groups

{
    public class DefinirUmTopicoDoGrupoRequest : RequestBase
    {
        public DefinirUmTopicoDoGrupoRequest(string channel, string topic)
        {
            requestService = "/api/groups.setTopic";
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

