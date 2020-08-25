using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using DesafioAutomacaoApi.Flows;
using NUnit.Framework;
using RestSharp;
using System;


namespace DesafioAutomacaoApi.Tests.Channels
{
   [TestFixture]
    public class RemoverMembroDoCanalTests : TestBase
    {

        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosValidos()
        {
            //Parametros
            string channel = "CRTAQ5N30";
            string user = "URDS6NWLB";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";

            //Fluxo
            ConviteCanalFlows.ConviteCanal(channel, user);
            IRestResponse<dynamic> response = RemoverMembroDoCanalFlows.RemoverMembroDoCanal(channel, user);

            Assert.Multiple (()=>
                {
                    Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                    Assert.AreEqual(ok, response.Data["ok"].ToString());
                });
        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void UsuarioNaoEstaNoCanal()
        {
            //Parametros
            string channel = "CRTAQ5N30";
            string user = "URT6EQA2K";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "not_in_channel";

            //Fluxo
            IRestResponse<dynamic> response = RemoverMembroDoCanalFlows.RemoverMembroDoCanal(channel, user);

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
        public void RemoverUsuarioAutenticado()
        {
            //Parametros
            string channel = "CRTAQ5N30";
            string user = "URMUP85T8";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "cant_kick_self";

            //Fluxo
            IngressarEmUmCanalFlows.IngressarEmUmCanal(user);
            IRestResponse<dynamic> response = RemoverMembroDoCanalFlows.RemoverMembroDoCanal(channel, user);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });
        }

    }
}
