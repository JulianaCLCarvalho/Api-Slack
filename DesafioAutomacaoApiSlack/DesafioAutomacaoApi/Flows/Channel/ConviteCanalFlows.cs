using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Flows
{
    class ConviteCanalFlows : TestBase
    {
        [Obsolete]
        public static IRestResponse<dynamic> ConviteCanal(string channel, string user)
        {
            ConviteCanalRequest conviteCanalRequest = new ConviteCanalRequest(channel, user);
            conviteCanalRequest.SetJsonBody(channel, user);
            IRestResponse<dynamic> response = conviteCanalRequest.ExecuteRequest();
            return response;
        }

    }
}

