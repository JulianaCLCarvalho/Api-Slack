using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Users;
using NUnit.Framework;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Tests.Users
{
    [TestFixture]
    public class ConsultaPresencaUsuarioTests : TestBase
    {
        ConsultaPresencaUsuarioRequest consultaPresencaUsuarioRequest;

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
            string presence = "active";
            string online = "True";
            string auto_away = "False";
            string manual_away = "False";
            string connection_count = "1";

            //Fluxo
            consultaPresencaUsuarioRequest = new ConsultaPresencaUsuarioRequest(user);
            IRestResponse<dynamic> response = consultaPresencaUsuarioRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(presence, response.Data["presence"].ToString());
                Assert.AreEqual(online, response.Data["online"].ToString());
                Assert.AreEqual(auto_away, response.Data["auto_away"].ToString());
                Assert.AreEqual(manual_away, response.Data["manual_away"].ToString());
                Assert.AreEqual(connection_count, response.Data["connection_count"].ToString());

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
            consultaPresencaUsuarioRequest = new ConsultaPresencaUsuarioRequest(user);
            IRestResponse<dynamic> response = consultaPresencaUsuarioRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });
        }
    }
}
