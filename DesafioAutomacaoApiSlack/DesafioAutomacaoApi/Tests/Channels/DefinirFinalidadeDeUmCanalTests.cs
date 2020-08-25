using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using DesafioAutomacaoApi.Flows;
using NUnit.Framework;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Tests.Channels
{
   [TestFixture]
    public class DefinirFinalidadeDeUmCanalTests : TestBase
    {
        DefinirFinalidadeDeUmCanalRequest definirFinalidadeDeUmCanalRequest;

        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosValidos()
        {
            //Parametros
            string channel = "CRMUP910W";
            string purpose = "Proposito";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";

            //Fluxo
            definirFinalidadeDeUmCanalRequest = new DefinirFinalidadeDeUmCanalRequest(channel, purpose);
            definirFinalidadeDeUmCanalRequest.SetJsonBody(channel, purpose);
            IRestResponse<dynamic> response = definirFinalidadeDeUmCanalRequest.ExecuteRequest();

            Assert.Multiple (()=>
                {
                    Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                    Assert.AreEqual(ok, response.Data["ok"].ToString());
                    Assert.AreEqual(purpose, response.Data["purpose"].ToString());
                });
        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void CampoVazio()
        {
            //Parametros
            string channel = string.Empty;
            string purpose = string.Empty;

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "channel_not_found";

            //Fluxo
            definirFinalidadeDeUmCanalRequest = new DefinirFinalidadeDeUmCanalRequest(channel, purpose);
            definirFinalidadeDeUmCanalRequest.SetJsonBody(channel, purpose);
            IRestResponse<dynamic> response = definirFinalidadeDeUmCanalRequest.ExecuteRequest();

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
        public void CanalArquivado()
        {
            //Parametros
            string channel = "CRSA9PGTW";
            string purpose = "Proposito";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "is_archived";

            //Fluxo
            ArquivarUmCanalFlows.ArquivarUmCanal(channel);
            definirFinalidadeDeUmCanalRequest = new DefinirFinalidadeDeUmCanalRequest(channel, purpose);
            definirFinalidadeDeUmCanalRequest.SetJsonBody(channel, purpose);
            IRestResponse<dynamic> response = definirFinalidadeDeUmCanalRequest.ExecuteRequest();

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
        public void ExcederLimiteDeCaracteres()
        {
            //Parametros
            string channel = "CRMUP910W";
            string purpose = "O que temos que ter sempre em mente é que o início da atividade geral de formação de atitudes nos obriga à análise do levantamento das " +
                "variáveis envolvidas. Nunca é demais lembrar o peso e o significado destes problemas, uma vez que a constante divulgação das informações prepara-nos " +
                "para enfrentar situações atípicas decorrentes do sistema de formação de quadros que corresponde às necessidades.";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "too_long";

            //Fluxo
            definirFinalidadeDeUmCanalRequest = new DefinirFinalidadeDeUmCanalRequest(channel, purpose);
            definirFinalidadeDeUmCanalRequest.SetJsonBody(channel, purpose);
            IRestResponse<dynamic> response = definirFinalidadeDeUmCanalRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });
        }
    }
}
