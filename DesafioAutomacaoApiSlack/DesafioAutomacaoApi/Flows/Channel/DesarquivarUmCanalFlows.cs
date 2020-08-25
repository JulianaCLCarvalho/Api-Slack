using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Flows
{
    class DesarquivarUmCanalFlows : TestBase
    {
        [Obsolete]
        public static IRestResponse<dynamic> DesarquivarUmCanal(string channel)
        {
            DesarquivarUmCanalRequest desarquivarUmCanalRequest = new DesarquivarUmCanalRequest(channel);
            desarquivarUmCanalRequest.SetJsonBody(channel);
            IRestResponse<dynamic> response = desarquivarUmCanalRequest.ExecuteRequest();
            return response;
        }

    }
}

