using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Flows
{
    class RemoverMembroDoCanalFlows : TestBase
    {
        [Obsolete]
        public static IRestResponse<dynamic> RemoverMembroDoCanal(string channel, string user)
        {
            RemoverMembroDoCanalRequest removerMembroDoCanalRequest = new RemoverMembroDoCanalRequest(channel,user);
            removerMembroDoCanalRequest.SetJsonBody(channel, user);
            IRestResponse<dynamic> response = removerMembroDoCanalRequest.ExecuteRequest();
            return response;
        }

    }
}

