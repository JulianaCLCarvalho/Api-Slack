using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Flows;
using NUnit.Framework;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Tests.Channels
{
    [TestFixture]
    public class ArquivarUmCanalTests : TestBase
    {
        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosValidos()
        {
            //Parametros
            string channel = "CRSC5A0TW";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";

            //Fluxo

            DesarquivarUmCanalFlows.DesarquivarUmCanal(channel);
            IRestResponse<dynamic> response = ArquivarUmCanalFlows.ArquivarUmCanal(channel);

            Assert.Multiple(() =>
           {
               Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
               Assert.AreEqual(ok, response.Data["ok"].ToString());
           });

        }

            [Test]
            [Parallelizable]
            [Obsolete]
            public void ArquivarCanalGeral()
            {
                //Parametros
                string channel = "CRMUP910W";

                //Resultados Esperados
                string statusCodeEsperado = "OK";
                string ok = "False";
                string error = "cant_archive_general";

                //Fluxo

                DesarquivarUmCanalFlows.DesarquivarUmCanal(channel);
                IRestResponse<dynamic> response = ArquivarUmCanalFlows.ArquivarUmCanal(channel);

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
            public void DadosInvalidos()
            {
            //Parametros
            string channel = string.Empty;

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "channel_not_found";

            //Fluxo

            DesarquivarUmCanalFlows.DesarquivarUmCanal(channel);
            IRestResponse<dynamic> response = ArquivarUmCanalFlows.ArquivarUmCanal(channel);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });

            }

    }
}




