using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Flows
{
    class IngressarEmUmCanalFlows : TestBase
    {
        [Obsolete]
        public static IRestResponse<dynamic> IngressarEmUmCanal(string name)
        {
            IngressarEmUmCanalRequest ingressarEmUmCanalRequest = new IngressarEmUmCanalRequest(name);
            IRestResponse<dynamic> response = ingressarEmUmCanalRequest.ExecuteRequest();
            return response;
        }

    }
}

