using RestSharp;
using DesafioAutomacaoApi.Helpers;
using System;
using System.Collections.Generic;

namespace DesafioAutomacaoApi.Bases
{
    public class RequestBase
    {
        #region Parameters
        protected string jsonBody = null;

        protected string newQuery = null;

        protected string url = Properties.Settings.Default.URL;

        protected string requestService = null;

        protected Method method;

        protected bool httpBasicAuthenticator = false;

        protected bool ntlmAuthenticator = false;

        protected IDictionary<string, string> headers = new Dictionary<string, string>()
        {
            //Dicionário de headeres deve ser iniciado com os headers comuns a todos os métodos da API
            {"Content-Type", "application/json;charset=utf-8"},
            {"Authorization", "Bearer "+Properties.Settings.Default.TOKEN}
        };

        protected IDictionary<string, string> cookies = new Dictionary<string, string>()
        {
            //Dicionário de cookies deve ser iniciado com os headers comuns à todas os métodos da API
        };

        protected IDictionary<string, string> parameters = new Dictionary<string, string>();
        //protected IDictionary<string, string> queryParameters = new Dictionary<string, string>();
        #endregion

        #region Actions
        [Obsolete]
        public IRestResponse<dynamic> ExecuteRequest()
        {
            IRestResponse<dynamic> response = RestSharpHelpers.ExecuteRequest(url, requestService, method, headers, cookies, parameters, jsonBody, httpBasicAuthenticator, ntlmAuthenticator);

            ExtentReportHelpers.AddTestInfo(url, requestService, method.ToString(), headers, cookies, parameters, jsonBody, httpBasicAuthenticator, ntlmAuthenticator, response);

            return response;
        }

        public void RemoveHeader(string header)
        {
            headers.Remove(header);
        }

        public void RemoveCookie(string cookie)
        {
            cookies.Remove(cookie);
        }

        public void RemoveParameter(string parameter)
        {
            parameters.Remove(parameter);
        }

        public void SetMethod(Method method)
        {
            this.method = method;
        }
        #endregion
    }
}
