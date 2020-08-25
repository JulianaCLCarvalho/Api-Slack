using RestSharp;
using DesafioAutomacaoApi.Bases;

namespace DesafioAutomacaoApi.Requests.Users

{
    public class ConsultaPresencaUsuarioRequest : RequestBase
    {
        public ConsultaPresencaUsuarioRequest(string user)
        {
            requestService = "/api/users.getPresence";
            method = Method.GET;
            parameters.Add("user", user);
        }
    }
}

