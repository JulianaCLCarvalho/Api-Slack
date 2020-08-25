using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Groups;
using NUnit.Framework;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Tests.Groups
{
   [TestFixture]
    public class DefinirUmTopicoDoGrupoTests : TestBase
    {
        DefinirUmTopicoDoGrupoRequest definirUmTopicoDoGrupoRequest;

        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosValidos()
        {
            //Parametros
            string channel = "GRV23990D";
            string topic = "Meu Topico";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";

            //Fluxo
            definirUmTopicoDoGrupoRequest = new DefinirUmTopicoDoGrupoRequest(channel, topic);
            definirUmTopicoDoGrupoRequest.SetJsonBody(channel, topic);
            IRestResponse<dynamic> response = definirUmTopicoDoGrupoRequest.ExecuteRequest();

            Assert.Multiple (()=>
                {
                    Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                    Assert.AreEqual(topic, response.Data["topic"].ToString());
                    Assert.AreEqual(ok, response.Data["ok"].ToString());
                });
        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void CampoVazio()
        {
            //Parametros
            string channel = string.Empty;
            string topic = "Meu Topico";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "channel_not_found";

            //Fluxo
            definirUmTopicoDoGrupoRequest = new DefinirUmTopicoDoGrupoRequest(channel, topic);
            definirUmTopicoDoGrupoRequest.SetJsonBody(channel, topic);
            IRestResponse<dynamic> response = definirUmTopicoDoGrupoRequest.ExecuteRequest();

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
            string topic = "O que temos que ter sempre em mente é que o início da atividade geral de formação de atitudes nos obriga à análise do levantamento das " +
                "variáveis envolvidas. Nunca é demais lembrar o peso e o significado destes problemas, uma vez que a constante divulgação das informações prepara-nos " +
                "para enfrentar situações atípicas decorrentes do sistema de formação de quadros que corresponde às necessidades.";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "too_long";

            //Fluxo
            definirUmTopicoDoGrupoRequest = new DefinirUmTopicoDoGrupoRequest(channel, topic);
            definirUmTopicoDoGrupoRequest.SetJsonBody(channel, topic);
            IRestResponse<dynamic> response = definirUmTopicoDoGrupoRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });
        }

    }
}
