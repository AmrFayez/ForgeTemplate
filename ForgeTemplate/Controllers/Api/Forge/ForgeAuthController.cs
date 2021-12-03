using Autodesk.Forge;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForgeTemplate.Controllers.Api.Forge
{
    [Route("api/Forge")]
    [ApiController]
    public class ForgeAuthController : ControllerBase
    {
        private readonly ForgeAuthService _forgeAuthService;

        public ForgeAuthController(ForgeAuthService forgeAuthService)
        {
            this._forgeAuthService = forgeAuthService;
        }
        [HttpGet("Token")]
        public async Task< ForgeToken> GetAcessToken()
        {
            return await _forgeAuthService.GetInternalTokenAsync();
        }
    }
}
