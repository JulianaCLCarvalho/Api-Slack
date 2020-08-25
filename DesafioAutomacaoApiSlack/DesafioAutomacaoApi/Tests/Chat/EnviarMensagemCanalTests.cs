using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Chat;
using DesafioAutomacaoApi.Helpers;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections;

namespace DesafioAutomacaoApi.Tests.Chat
{
    [TestFixture]
    public class EnviarMensagemCanalTests : TestBase
    {
        EnviarMensagemCanalRequest enviarMensagemCanalRequest;
        
        //usando Data Driven
        #region Data Driven Providers 
        public static IEnumerable EnviarMensagemCanalProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/MensagemCanalData.csv");
        }
        #endregion

        [Obsolete]
        [Test, TestCaseSource("EnviarMensagemCanalProvider")]
        [Parallelizable]
        public void DadosValidos(ArrayList testData)
        {
            //Parametros
            string channel = testData[0].ToString().Trim();
            string text = testData[1].ToString().Trim();
            
            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";
            string type = "message";
            string subType = "bot_message";
            string username = "Slack API Tester";
            string bot_id = "BRPUDMRAM";

            //Fluxo
            enviarMensagemCanalRequest = new EnviarMensagemCanalRequest(channel, text);
            enviarMensagemCanalRequest.SetJsonBody(channel, text);
            IRestResponse<dynamic> response = enviarMensagemCanalRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(channel, response.Data["channel"].ToString());
                Assert.AreEqual(type, response.Data["message"]["type"].ToString());
                Assert.AreEqual(subType, response.Data["message"]["subtype"].ToString());
                Assert.AreEqual(text, response.Data["message"]["text"].ToString());
                StringAssert.IsMatch("[0-9]{10}\\.[0-9]{6}", response.Data["message"]["ts"].ToString()); // validacao usando REGEX 
                Assert.AreEqual(username, response.Data["message"]["username"].ToString());
                Assert.AreEqual(bot_id, response.Data["message"]["bot_id"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void CampoVazio()
        {
            //Parametros
            string channel = string.Empty;
            string text = "Hello world";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "channel_not_found";

            //Fluxo
            enviarMensagemCanalRequest = new EnviarMensagemCanalRequest(channel, text);
            enviarMensagemCanalRequest.SetJsonBody(channel, text);
            IRestResponse<dynamic> response = enviarMensagemCanalRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });
        }

    }
}
