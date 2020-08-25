using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Bot;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;

namespace DesafioAutomacaoApi.Tests.Bot
{
    [TestFixture]
    public class ConsultaUsuarioBotTests : TestBase
    {
        ConsultaUsuarioBotRequest consultaUsuarioBotRequest;

        [Test]
        [Obsolete]
        public void DadosValidos()
        {
            //Parametros
            string bot = "URH2V1W5R";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";

            //Fluxo
            consultaUsuarioBotRequest = new ConsultaUsuarioBotRequest(bot);
            IRestResponse<dynamic> response = consultaUsuarioBotRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(channel, response.Data["channel"]["id"].ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(is_Channel, response.Data["channel"]["is_channel"].ToString());
                Assert.AreEqual(is_Archived, response.Data["channel"]["is_archived"].ToString());
                Assert.AreEqual(is_General, response.Data["channel"]["is_general"].ToString());
                Assert.AreEqual(is_Member, response.Data["channel"]["is_member"].ToString());
                Assert.AreEqual(is_Private, response.Data["channel"]["is_private"].ToString());

            });
        }

        [Test]
        [Obsolete]
        public void DadosInvalidos()
        {
            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string channel = "teste";
            string ok = "False";
            string error = "channel_not_found";


            //Fluxo
            consultaInformacaoCanalRequest = new ConsultaInformacaoCanalRequest(channel);
            IRestResponse<dynamic> response = consultaInformacaoCanalRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());

            });

        }

    }
}
