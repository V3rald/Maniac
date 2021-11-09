using Maniac.Model;
using Maniac.Model.Auth;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maniac.Api
{
    public interface Auth
    {
        [Post("/oauth/token")]
        Task<Token> GetToken([Body] GetToken getToken);
    }
}
