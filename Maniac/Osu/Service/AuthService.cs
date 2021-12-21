using Maniac.Model;
using Maniac.Model.Auth;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maniac.Api
{
    public class AuthService
    {
        private static readonly Auth auth;
        static AuthService()
        {
            auth = RestService.For<Auth>(Bot.BaseUrl, new RefitSettings(new NewtonsoftJsonContentSerializer()));
        }

        public static Authorization GetToken(OsuToken getToken)
        {
            return auth.GetToken(getToken).Result;
        }
    }
}