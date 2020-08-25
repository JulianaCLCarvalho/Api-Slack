using RestSharp;
using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Helpers;
using System.IO;
using System.Text;

namespace DesafioAutomacaoApi.Requests.Groups

{
    public class CriarGrupoRequest : RequestBase
    {
        public CriarGrupoRequest(string name)
        {
            requestService = "api/groups.create";
            method = Method.POST;
            parameters.Add("name", name);
        }

        public void SetJsonBody(string name)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Channels/nameJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$name", name);
        }
    }
}

