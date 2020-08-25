using RestSharp;
using DesafioAutomacaoApi.Bases;

namespace DesafioAutomacaoApi.Requests.Users

{
    public class ConsultaInformacaoUsuarioRequest : RequestBase
    {
        public ConsultaInformacaoUsuarioRequest(string user)
        {
            requestService = "/api/users.info";
            method = Method.GET;
            parameters.Add("user", user);
        }
    }
}

