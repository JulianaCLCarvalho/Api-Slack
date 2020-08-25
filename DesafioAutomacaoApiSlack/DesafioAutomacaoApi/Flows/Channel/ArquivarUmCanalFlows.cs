using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Flows
{
    class ArquivarUmCanalFlows : TestBase
    {
        [Obsolete]
        public static IRestResponse<dynamic> ArquivarUmCanal(string channel)
        {
            ArquivarUmCanalRequest arquivarUmCanalRequest = new ArquivarUmCanalRequest(channel);
            arquivarUmCanalRequest.SetJsonBody(channel);
            IRestResponse<dynamic> response = arquivarUmCanalRequest.ExecuteRequest();
            return response;
        }

    }
}

