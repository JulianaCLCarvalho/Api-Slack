using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Flows;
using NUnit.Framework;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Tests.Channels
{
    [TestFixture]
    public class DesarquivarUmCanalTests : TestBase
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

            ArquivarUmCanalFlows.ArquivarUmCanal(channel);
            IRestResponse<dynamic> response = DesarquivarUmCanalFlows.DesarquivarUmCanal(channel);

            Assert.Multiple(() =>
           {
               Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
               Assert.AreEqual(ok, response.Data["ok"].ToString());
           });

        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosInvalidos()
        {
            //Parametros
            string channel = "CRMUP910W";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "not_archived";

            //Fluxo

            ArquivarUmCanalFlows.ArquivarUmCanal(channel);
            IRestResponse<dynamic> response = DesarquivarUmCanalFlows.DesarquivarUmCanal(channel);

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
        public void CampoVazio()
        {
            //Parametros
            string channel = string.Empty;

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "channel_not_found";

            //Fluxo

            ArquivarUmCanalFlows.ArquivarUmCanal(channel);
            IRestResponse<dynamic> response = DesarquivarUmCanalFlows.DesarquivarUmCanal(channel);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });

        }

    }
}


