using RestSharp;
using DesafioAutomacaoApi.Bases;

namespace DesafioAutomacaoApi.Requests.Channels

{
    public class ConsultaInformacaoCanalRequest : RequestBase
    {
        public ConsultaInformacaoCanalRequest(string channel)
        {
            requestService = "/api/channels.info";
            method = Method.GET;
            parameters.Add("channel", channel);
        }
    }
}

