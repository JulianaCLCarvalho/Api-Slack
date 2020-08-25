using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Team;
using NUnit.Framework;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Tests.Team
{
    [TestFixture]
    public class ConsultaInformacaoEquipeTests : TestBase
    {
        ConsultaInformacaoEquipeRequest consultaInformacaoEquipeRequest;

        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosValidos()
        {
            //Parametros
            string team = "TRKNJ1UU8";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";
            string name = "DesafioAutomacaoApi";
            string domain = "desafioautomacaoapico";
 
            //Fluxo
            consultaInformacaoEquipeRequest = new ConsultaInformacaoEquipeRequest(team);
            IRestResponse<dynamic> response = consultaInformacaoEquipeRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(team, response.Data["team"]["id"].ToString());
                Assert.AreEqual(name, response.Data["team"]["name"].ToString());
                Assert.AreEqual(domain, response.Data["team"]["domain"].ToString());
            });
        }


        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosInvalidos()
        {
            //Parametros
            string team = "ABDCEF12";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "team_not_found";

            //Fluxo
            consultaInformacaoEquipeRequest = new ConsultaInformacaoEquipeRequest(team);
            IRestResponse<dynamic> response = consultaInformacaoEquipeRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());

            });
        }

    }
}
