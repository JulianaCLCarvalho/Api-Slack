﻿using RestSharp;
using DesafioAutomacaoApi.Bases;
using DesafioAutomacaoApi.Helpers;
using System.IO;
using System.Text;

namespace DesafioAutomacaoApi.Requests.Channels

{
    public class RemoverMembroDoCanalRequest : RequestBase
    {
        public RemoverMembroDoCanalRequest(string channel,string user)
        {
            requestService = "/api/channels.kick";
            method = Method.POST;
            parameters.Add("channel",channel);
            parameters.Add("user", user);
        }

        public void SetJsonBody(string channel,string user)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Channels/inviteJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$channel",channel);
            jsonBody = jsonBody.Replace("$user", user);
        }
    }
}

