using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using NUnit.Framework;
using RestSharp;
using System;
using DesafioAutomacaoApi.Flows;

namespace DesafioAutomacaoApi.Tests.Channels
{
    [TestFixture]
    public class ConviteCanalTests : TestBase
    {
        ConviteCanalRequest conviteCanalRequest;
        
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
            string is_Channel = "True";
            string is_Archived = "False";
            string is_General = "False";
            string is_Private = "False";
            string is_Mpim = "False";


            //Fluxo
            RemoverMembroDoCanalFlows.RemoverMembroDoCanal(channel,user);
            IRestResponse<dynamic> response = ConviteCanalFlows.ConviteCanal(channel,user);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(channel, response.Data["channel"]["id"].ToString());
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
        public void UsuarioAutenticado()
        {
            //Parametros
            string channel = "CRMUP910W";
            string user = "URMUP85T8";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "cant_invite_self";

            //Fluxo
            conviteCanalRequest = new ConviteCanalRequest(channel, user);
            conviteCanalRequest.SetJsonBody(channel, user);
            IRestResponse<dynamic> response = conviteCanalRequest.ExecuteRequest();

            Assert.Multiple (()=>
                {
                    Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                    Assert.AreEqual(ok, response.Data["ok"].ToString());
                    Assert.AreEqual(error, response.Data["error"].ToString());

                });
        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void UsuarioInvalido()
        {
            //Parametros
            string channel = "CRMUP910W";
            string user = "TESTE";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "user_not_found";

            //Fluxo
            conviteCanalRequest = new ConviteCanalRequest(channel, user);
            conviteCanalRequest.SetJsonBody(channel, user);
            IRestResponse<dynamic> response = conviteCanalRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());

            });

        }

    }
}
