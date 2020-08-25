using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Flows
{
    class SairDoCanalFlows : TestBase
    {
        [Obsolete]
        public static IRestResponse<dynamic> SairDoCanal(string channel)
        {
            SairDoCanalRequest sairDoCanalRequest = new SairDoCanalRequest(channel);
            IRestResponse<dynamic> response = sairDoCanalRequest.ExecuteRequest();
            return response;
        }

    }
}

