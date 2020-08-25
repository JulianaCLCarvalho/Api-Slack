using RestSharp;
using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Helpers;
using System.IO;
using System.Text;

namespace DesafioAutomacaoApi.Requests.Chat

{
    public class CompartilharMensagemCanalRequest : RequestBase
    {
        public CompartilharMensagemCanalRequest(string channel, string text)
        {
            requestService = "/api/chat.meMessage";
            method = Method.POST;
            parameters.Add("channel", channel);
            parameters.Add("text", text);
        }

        public void SetJsonBody(string channel,string text)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Chat/messageJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$channel", channel);
            jsonBody = jsonBody.Replace("$text", text);
        }
    }
}

