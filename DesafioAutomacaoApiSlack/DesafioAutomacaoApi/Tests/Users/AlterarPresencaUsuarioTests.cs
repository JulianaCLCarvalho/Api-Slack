using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Users;
using NUnit.Framework;
using RestSharp;
using System;


namespace DesafioAutomacaoApi.Tests.Users
{
    [TestFixture]
    public class AlterarPresencaUsuarioTests : TestBase
    {
        AlterarPresencaUsuarioRequest alterarPresencaUsuarioRequest;

        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadoValido()
        {
            //Parametros
            string presence = "auto";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";

            //Fluxo
            alterarPresencaUsuarioRequest = new AlterarPresencaUsuarioRequest(presence);
            alterarPresencaUsuarioRequest.SetJsonBody(presence);
            IRestResponse<dynamic> response = alterarPresencaUsuarioRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadoInvalido()
        {
            //Parametros
            string presence = "active";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "invalid_presence";

            //Fluxo
            alterarPresencaUsuarioRequest = new AlterarPresencaUsuarioRequest(presence);
            alterarPresencaUsuarioRequest.SetJsonBody(presence);
            IRestResponse<dynamic> response = alterarPresencaUsuarioRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });
        }
    }
}
