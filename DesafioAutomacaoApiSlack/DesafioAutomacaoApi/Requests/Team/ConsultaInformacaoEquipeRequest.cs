using RestSharp;
using DesafioAutomacaoApi.Bases;

namespace DesafioAutomacaoApi.Requests.Team

{
    public class ConsultaInformacaoEquipeRequest : RequestBase
    {
        public ConsultaInformacaoEquipeRequest(string team)
        {
            requestService = "/api/team.info";
            method = Method.GET;
            parameters.Add("team", team);
        }
    }
}

