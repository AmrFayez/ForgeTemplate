using Autodesk.Forge;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForgeTemplate
{
    public class ForgeAuthService
    {
        private static ForgeToken _internalToken;
        private readonly IConfiguration _config;

        public ForgeAuthService(IConfiguration config)

        {
            this._config = config;
        }

        #region Private Methods
        public async Task<ForgeToken> GetInternalTokenAsync()
        {
            if (_internalToken == null || _internalToken.ExpiresDate < DateTime.UtcNow)
            {
                _internalToken = await Get2LeggedTokenAsync(new Scope[] { Scope.BucketCreate, Scope.BucketRead, Scope.DataRead, Scope.DataCreate, Scope.DataWrite });
            }
            return _internalToken;
        }
        public async Task<ForgeToken> GetPublicTokenAsync()
        {
            if (_internalToken == null || _internalToken.ExpiresDate < DateTime.UtcNow)
            {
                _internalToken = await Get2LeggedTokenAsync(new Scope[] { Scope.BucketRead, Scope.DataRead });
            }
            return _internalToken;
        }
        private async Task<ForgeToken> Get2LeggedTokenAsync(Scope[] scopes)
        {
            var forge = _config.GetSection("ForgeApp");
            var clientId = forge["ClientId"];
            var clientSecret = forge["ClientSecret"];
            TwoLeggedApi oauth = new TwoLeggedApi();
            string grantType = "client_credentials";
            dynamic bearer = await oauth.AuthenticateAsync(
              clientId,
              clientSecret,
              grantType,
              scopes);

            var token = new ForgeToken()
            {
                AccessToken = bearer.access_token,
                ExpiresDate = DateTime.UtcNow.AddSeconds(bearer.expires_in),
                ExpiresIn= bearer.expires_in.ToString()
            };
            return token;
        }
        #endregion
    }
    public class ForgeToken
    {
        public string AccessToken { get; set; }
        public DateTime ExpiresDate { get; set; }
        public string ExpiresIn { get; set; }
    }

}

