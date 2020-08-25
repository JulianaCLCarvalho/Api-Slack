using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Chat;
using DesafioAutomacaoApi.Helpers;
using DesafioAutomacaoApi.Flows;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections;

namespace DesafioAutomacaoApi.Tests.Chat
{
    [TestFixture]
    public class CompartilharMensagemCanalTests : TestBase
    {
        CompartilharMensagemCanalRequest compartilharMensagemCanalRequest;

        //usando Data Driven
        #region Data Driven Providers 
        public static IEnumerable CompartilharMensagemCanalProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/MensagemCanalData.csv");
        }
        #endregion

        [Obsolete]
        [Test, TestCaseSource("CompartilharMensagemCanalProvider")]
        [Parallelizable]
        public void DadosValidos(ArrayList testData)
        {
            //Parametros
            string channel = testData[0].ToString().Trim();
            string text = testData[1].ToString().Trim();

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";

            //Fluxo
            compartilharMensagemCanalRequest = new CompartilharMensagemCanalRequest(channel, text);
            compartilharMensagemCanalRequest.SetJsonBody(channel, text);
            IRestResponse<dynamic> response = compartilharMensagemCanalRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(channel, response.Data["channel"].ToString());
                StringAssert.IsMatch("[0-9]{10}\\.[0-9]{6}", response.Data["ts"].ToString()); // validacao usando REGEX 
            });
        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void CompartilharMensagemCanalArquivado()
        {
            //Parametros
            string channel = "CRSA9PGTW";
            string text = "Hello people";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "is_archived";

            //Fluxo
            ArquivarUmCanalFlows.ArquivarUmCanal(channel);
            compartilharMensagemCanalRequest = new CompartilharMensagemCanalRequest(channel, text);
            compartilharMensagemCanalRequest.SetJsonBody(channel, text);
            IRestResponse<dynamic> response = compartilharMensagemCanalRequest.ExecuteRequest();

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
            string channel = "ABCDEF12";
            string text = "Hello people";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "channel_not_found";

            //Fluxo
            compartilharMensagemCanalRequest = new CompartilharMensagemCanalRequest(channel, text);
            compartilharMensagemCanalRequest.SetJsonBody(channel, text);
            IRestResponse<dynamic> response = compartilharMensagemCanalRequest.ExecuteRequest();

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
        public void TextoNaoInformado()
        {
            //Parametros
            string channel = "CRMUP910W";
            string text = string.Empty;

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "no_text";

            //Fluxo
            compartilharMensagemCanalRequest = new CompartilharMensagemCanalRequest(channel, text);
            compartilharMensagemCanalRequest.SetJsonBody(channel, text);
            IRestResponse<dynamic> response = compartilharMensagemCanalRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });
        }
      
    }
}
