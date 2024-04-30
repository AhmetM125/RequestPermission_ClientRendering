using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using RequestPermission_ClientRendering.ViewModels.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RequestPermission_ClientRendering.Base
{
    public class AuthorizationProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private string TokenKey = "RandomTokenName";
        private AuthenticationState Anonymous => new(new(new ClaimsIdentity()));
        public AuthorizationProvider(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorage = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var savedToken = await _localStorage.GetItemAsync<TokenVM>(TokenKey);
                if (savedToken == null)
                    return Anonymous;
                return BuildAuthenticatedState(savedToken);

            }
            catch(Exception ex)
            {
                return new(new(new ClaimsIdentity()));
            }
        }
        private AuthenticationState BuildAuthenticatedState(TokenVM savedToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("bearer", savedToken.Token);
            return new(new(new ClaimsIdentity(ParseClaimsFromJwt(savedToken.Token), "apiauth")));
        }

        public async Task MarkUserAsAuthenticated(TokenVM token, LoginResponse response, bool writeLocalStorage)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("bearer", token.Token);
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token.Token), "apiauth"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
            if (writeLocalStorage)
                await _localStorage.SetItemAsync(TokenKey, token);
        }
        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            if (handler.ReadToken(jwt) is not JwtSecurityToken tokenS) return null;

            var username = tokenS.Claims.FirstOrDefault(claim => claim.Type == "Username")?.Value;
            var id = tokenS.Claims.FirstOrDefault(claim => claim.Type == "EmployeeId")?.Value;
            return new Claim[]
             {
            new("EmployeeId", id),
            new("Username", username),
             };
        }
        public void NotifyUserLogin(String username)
        {
            var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(cp));

            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(Anonymous);
            NotifyAuthenticationStateChanged(authState);
        }

        
        
    }
}
