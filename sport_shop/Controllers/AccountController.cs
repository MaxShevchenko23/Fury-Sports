using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using sport_shop_bll.AdditionalServices;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Services;
using System.Runtime.Intrinsics.Arm;
using static sport_shop_bll.AdditionalServices.GoogleOAuthService;
using static System.Net.WebRequestMethods;

namespace sport_shop.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService service;

        public AccountController(AccountService service)
        {
            this.service = service;
        }

        [HttpGet("oAuth")]
        public async Task<ActionResult<string>> OAuth()
        {
            var scope = "https://www.googleapis.com/auth/userinfo.email";
            var redirectUrl = "https://localhost:7097/account/code";

            //var codeVerifier = Guid.NewGuid().ToString();
            var codeVerifier = "secret";

            //HttpContext.Session.SetString("codeVerifier", codeVerifier);

            var codeChallenge = Sha256Helper.ComputeHash(codeVerifier);
            
            var url = GoogleOAuthService.GenerateOAuthRequestUrl(scope, redirectUrl, codeChallenge);

            return url;
        }

        [HttpGet("code")]
        public async Task<ActionResult<TokenResult>> Code(string code)
        {
            string codeVerifier = "secret";
            var redirectUrl = "https://localhost:7097/account/code";

            var tokenResult = await GoogleOAuthService.ExchangeCodeOnTokenAsync(code, codeVerifier,
                redirectUrl);

            return Ok(tokenResult);
        }

        [HttpPost("auth")]
        public async Task<ActionResult<AccountGet>> AuthorizateAsync(AccountPost model)
        {
            var created = await service.AuthorizateAsync(model);
            return Ok(created);
        }

    }
}
