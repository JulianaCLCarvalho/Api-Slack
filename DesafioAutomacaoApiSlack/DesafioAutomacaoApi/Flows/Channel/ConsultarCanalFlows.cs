using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Flows
{
    class ConsultaChannelFlows : TestBase
    {
        [Obsolete]
        public static IRestResponse<dynamic> Channel(string channel)
        {
            ConsultaInformacaoCanalRequest consultaInformacaoCanalRequests = new ConsultaInformacaoCanalRequest(channel);
            IRestResponse<dynamic> response = consultaInformacaoCanalRequests.ExecuteRequest();
            return response;
        }

    }
}

