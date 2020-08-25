using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using DesafioAutomacaoApi.Flows;
using NUnit.Framework;
using RestSharp;
using System;


namespace DesafioAutomacaoApi.Tests.Channels
{
   [TestFixture]
    public class SairDoCanalTests : TestBase
    {
        SairDoCanalRequest sairDoCanalRequest;

        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosValidos()
        {
            //Parametros
            string channel = "CRTAQ5N30";
            string name = "automação";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";


            //Fluxo

            IngressarEmUmCanalFlows.IngressarEmUmCanal(name);
            sairDoCanalRequest = new SairDoCanalRequest(channel);
            sairDoCanalRequest.SetJsonBody(channel);
            IRestResponse<dynamic> response = sairDoCanalRequest.ExecuteRequest();

            Assert.Multiple (()=>
                {
                    Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                    Assert.AreEqual(ok, response.Data["ok"].ToString());
                });

        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void UsuarioNaoPodeSairDoCanalGeral()
        {
            //Parametros
            string channel = "CRMUP910W";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "cant_leave_general";

            //Fluxo

            sairDoCanalRequest = new SairDoCanalRequest(channel);
            sairDoCanalRequest.SetJsonBody(channel);
            IRestResponse<dynamic> response = sairDoCanalRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });

        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void CanalInvalido()
        {
            //Parametros
            string channel = "ABCDE12";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "channel_not_found";

            //Fluxo

            sairDoCanalRequest = new SairDoCanalRequest(channel);
            sairDoCanalRequest.SetJsonBody(channel);
            IRestResponse<dynamic> response = sairDoCanalRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });

        }

    }
}
