using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using DesafioAutomacaoApi.Helpers;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;

namespace DesafioAutomacaoApi.Tests.Channels
{
   [TestFixture]
    public class RenomearCanalTests : TestBase
    {
        RenomearCanalRequest renomearCanalRequest;

        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosValidos()
        {

            //Parametros
            string channel = "CRMUP910W";
            string name = GeneralHelpers.alfanumericoAleatorio();

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";
            string is_Channel = "True";
            string is_Archived = "False";
            //string is_General = "True";
            string is_Private = "False";
            string is_Mpim = "False";

            //Fluxo
            renomearCanalRequest = new RenomearCanalRequest(channel,name);
            renomearCanalRequest.SetJsonBody(channel,name);
            IRestResponse<dynamic> response = renomearCanalRequest.ExecuteRequest();

            Assert.Multiple (()=>
                {
                    Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                    Assert.AreEqual(ok, response.Data["ok"].ToString());
                    Assert.AreEqual(channel, response.Data["channel"]["id"].ToString());
                    Assert.AreEqual(name, response.Data["channel"]["name"].ToString());
                    Assert.AreEqual(is_Channel, response.Data["channel"]["is_channel"].ToString());
                    Assert.AreEqual(is_Archived, response.Data["channel"]["is_archived"].ToString());
                    //Assert.AreEqual(is_General, response.Data["channel"]["is_general"].ToString());
                    Assert.AreEqual(is_Private, response.Data["channel"]["is_private"].ToString());
                    Assert.AreEqual(is_Mpim, response.Data["channel"]["is_mpim"].ToString());
                });
        }
        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosInvalidos()
        {

            //Parametros
            string channel = string.Empty;
            string name = "Teste";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "channel_not_found";


            //Fluxo
            renomearCanalRequest = new RenomearCanalRequest(channel, name);
            renomearCanalRequest.SetJsonBody(channel, name);
            IRestResponse<dynamic> response = renomearCanalRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });
        }


    }
}
