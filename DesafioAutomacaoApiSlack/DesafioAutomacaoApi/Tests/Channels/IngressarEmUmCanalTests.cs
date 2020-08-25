using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Channels;
using DesafioAutomacaoApi.Flows;
using NUnit.Framework;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Tests.Channels
{
   [TestFixture]
    public class IngressarEmUmCanalTests : TestBase
    {
        IngressarEmUmCanalRequest ingressarEmUmCanalRequest;

        [Test]
        [Parallelizable]
        [Obsolete]
        public void DadosValidos()
        {
            //Parametros
            string name = "automação";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "True";
            string id = "CRTAQ5N30";
            string is_Channel = "True";
            string is_Archived = "False";
            string is_General = "False";
            //string is_Member = "True";
            string is_Private = "False";
            string is_Mpim = "False";

            //Fluxo
            ingressarEmUmCanalRequest = new IngressarEmUmCanalRequest(name);
            ingressarEmUmCanalRequest.SetJsonBody(name);
            IRestResponse<dynamic> response = ingressarEmUmCanalRequest.ExecuteRequest();

            Assert.Multiple (()=>
            {
                    Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                    Assert.AreEqual(ok, response.Data["ok"].ToString());
                    Assert.AreEqual(id, response.Data["channel"]["id"].ToString());
                    Assert.AreEqual(name, response.Data["channel"]["name"].ToString());
                    Assert.AreEqual(is_Channel, response.Data["channel"]["is_channel"].ToString());
                    Assert.AreEqual(is_Archived, response.Data["channel"]["is_archived"].ToString());
                    Assert.AreEqual(is_General, response.Data["channel"]["is_general"].ToString());
                    //Assert.AreEqual(is_Member, response.Data["channel"]["is_member"].ToString());
                    Assert.AreEqual(is_Private, response.Data["channel"]["is_private"].ToString());
                    Assert.AreEqual(is_Mpim, response.Data["channel"]["is_mpim"].ToString());
             });

        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void CanalInvalido()
        {
            //Parametros
            string name = string.Empty;

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "no_channel";

            //Fluxo
            ingressarEmUmCanalRequest = new IngressarEmUmCanalRequest(name);
            ingressarEmUmCanalRequest.SetJsonBody(name);
            IRestResponse<dynamic> response = ingressarEmUmCanalRequest.ExecuteRequest();

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
            string name = "canal_arquivado";

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "is_archived";

            //Fluxo
            ArquivarUmCanalFlows.ArquivarUmCanal(channel);
            ingressarEmUmCanalRequest = new IngressarEmUmCanalRequest(name);
            ingressarEmUmCanalRequest.SetJsonBody(name);
            IRestResponse<dynamic> response = ingressarEmUmCanalRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());

            });

        }
    }   
}
