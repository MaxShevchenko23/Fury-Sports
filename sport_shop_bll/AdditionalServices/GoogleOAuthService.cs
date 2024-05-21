using Microsoft.AspNetCore.WebUtilities;

namespace sport_shop_bll.AdditionalServices
{
    public partial class GoogleOAuthService
    {
        public const string ClientId = "385547440692-uejae5ja6l2iqvpo4g725b7sj7hhnvpv.apps.googleusercontent.com";
        public const string ClientSecret = "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";


        public static string GenerateOAuthRequestUrl(string scope, string redirectUrl, string codeChallenge)
        {
            var oAuthEndPoint = "https://accounts.google.com/o/oauth2/v2/auth";
            var queryParams = new Dictionary<string, string>
            {
                {"client_id",ClientId },
                {"redirect_uri",redirectUrl },
                {"response_type","code"},
                {"scope",scope },
                {"code_challenge",codeChallenge },
                {"code_challenge_method","S256" }
            };
            var url = QueryHelpers.AddQueryString(oAuthEndPoint,
                queryParams);
            return url;
        }

        public static async Task<TokenResult> ExchangeCodeOnTokenAsync(string code, string codeVerifier, string redirect_uri)
        {
            var tokenEndpoint = "https://oauth2.googleapis.com/token";
            var authParams = new Dictionary<string, string>
            {
                {"client_id",ClientId },
                {"client_secret",ClientSecret },
                {"code", code },
                {"code_verifier",codeVerifier },
                {"grant_type", "authorization_code"},
                {"redirect_uri", redirect_uri},
            };

           var response =  await HttpClientHelper.SendPostRequest<TokenResult>(tokenEndpoint, authParams);

            //HttpClient client = new HttpClient();
            //var response = await client.SendAsync(new(HttpMethod.Post,
            //QueryHelpers.AddQueryString(tokenEndpoint, authParams)));

            return response;
        }

        public static async Task<string> GetEmailAndUserPhoto(string accessToken)
        {

            throw new NotImplementedException();
        }

        public static object RefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }


    }
}
