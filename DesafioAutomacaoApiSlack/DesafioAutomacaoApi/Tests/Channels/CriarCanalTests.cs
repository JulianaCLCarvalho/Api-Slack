using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using DesafioAutomacaoApi.Helpers;
using NUnit.Framework;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Tests.Channels
{
   [TestFixture]
    public class CriarCanalTests : TestBase
    {
        CriarCanalRequest criarCanalRequest;

        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosValidos()
        {
            //Parametros
            string name = GeneralHelpers.alfanumericoAleatorio();

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";
            string is_Channel = "True";
            string is_Archived = "False";
            string is_General = "False";
            string is_Private = "False";
            string is_Mpim = "False";

            //Fluxo
            criarCanalRequest = new CriarCanalRequest(name);
            criarCanalRequest.SetJsonBody(name);
            IRestResponse<dynamic> response = criarCanalRequest.ExecuteRequest();

            Assert.Multiple (()=>
                {
                    Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                    Assert.AreEqual(ok, response.Data["ok"].ToString());
                    Assert.AreEqual(name, response.Data["channel"]["name"].ToString());
                    Assert.AreEqual(is_Channel, response.Data["channel"]["is_channel"].ToString());
                    Assert.AreEqual(is_Archived, response.Data["channel"]["is_archived"].ToString());
                    Assert.AreEqual(is_General, response.Data["channel"]["is_general"].ToString());
                    Assert.AreEqual(is_Private, response.Data["channel"]["is_private"].ToString());
                    Assert.AreEqual(is_Mpim, response.Data["channel"]["is_mpim"].ToString());
                });

        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void NomeVazio()

        {
            //Parametros
            string name = string.Empty;

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "no_channel";


            //Fluxo
            criarCanalRequest = new CriarCanalRequest(name);
            criarCanalRequest.SetJsonBody(name);
            IRestResponse<dynamic> response = criarCanalRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });
        }

    }
}
