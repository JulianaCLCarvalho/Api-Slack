using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Requests.Groups;
using DesafioAutomacaoApi.Helpers;
using NUnit.Framework;
using RestSharp;
using System;

namespace DesafioAutomacaoApi.Tests.Groups
{
   [TestFixture]
    public class CriarGrupoTests : TestBase
    {
        CriarGrupoRequest criarGrupoRequest;

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
            string is_group = "True";
            string is_Archived = "False";
            //string is_open = "True";
            string is_Mpim = "False";

            //Fluxo
            criarGrupoRequest = new CriarGrupoRequest(name);
            criarGrupoRequest.SetJsonBody(name);
            IRestResponse<dynamic> response = criarGrupoRequest.ExecuteRequest();

            Assert.Multiple (()=>
            {
                    Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                    Assert.AreEqual(ok, response.Data["ok"].ToString());
                    Assert.AreEqual(name, response.Data["group"]["name"].ToString());
                    Assert.AreEqual(is_group, response.Data["group"]["is_group"].ToString());
                    Assert.AreEqual(is_Archived, response.Data["group"]["is_archived"].ToString());
                    //Assert.AreEqual(is_open, response.Data["group"]["is_open"].ToString());
                    Assert.AreEqual(is_Mpim, response.Data["group"]["is_mpim"].ToString());
            });

        }

        [Test]
        [Parallelizable]
        [Obsolete]
        public void CampoVazio()
        {
            //Parametros
            string name = string.Empty;

            //Resultados Esperados
            string statusCodeEsperado = "OK";
            string ok = "False";
            string error = "no_channel";

            //Fluxo
            criarGrupoRequest = new CriarGrupoRequest(name);
            criarGrupoRequest.SetJsonBody(name);
            IRestResponse<dynamic> response = criarGrupoRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(ok, response.Data["ok"].ToString());
                Assert.AreEqual(error, response.Data["error"].ToString());
            });

        }

    }
}
