using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Users;
using NUnit.Framework;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Tests.Users
{
    [TestFixture]
    public class ConsultaInformacaoUsuarioTests : TestBase
    {
        ConsultaInformacaoUsuarioRequest consultaInformacaoUsuarioRequest;

        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosValidos()
        {
            //Parametros
            string user = "URMUP85T8";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";
            string name = "juli.chluiz";
            string deleted = "False";
            string real_name = "Juli";
            string display_name = "Juliana Carvalho";
            string email = "juli.chluiz@gmail.com";

            //Fluxo
            consultaInformacaoUsuarioRequest = new ConsultaInformacaoUsuarioRequest(user);
            IRestResponse<dynamic> response = consultaInformacaoUsuarioRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
            Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            Assert.AreEqual(ok, response.Data["ok"].ToString());
            Assert.AreEqual(user, response.Data["user"]["id"].ToString());
            Assert.AreEqual(name, response.Data["user"]["name"].ToString());
            Assert.AreEqual(deleted, response.Data["user"]["deleted"].ToString());
            Assert.AreEqual(real_name, response.Data["user"]["real_name"].ToString());
            Assert.AreEqual(display_name, response.Data["user"]["profile"]["display_name"].ToString());
            Assert.AreEqual(email, response.Data["user"]["profile"]["email"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosInvalidos()
        {
            //Parametros
            string user = "ABCDE12";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "user_not_found";

            //Fluxo
            consultaInformacaoUsuarioRequest = new ConsultaInformacaoUsuarioRequest(user);
            IRestResponse<dynamic> response = consultaInformacaoUsuarioRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());

            });
        }
    }
}
