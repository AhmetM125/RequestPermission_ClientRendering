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
            string? token = await _localStorage.GetItemAsync<string>(TokenKey);
            if (string.IsNullOrWhiteSpace(token))
                return Anonymous;

            Guid employeeId = await _localStorage.GetItemAsync<Guid>("EmployeeId");
            var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, employeeId.ToString()) }, "jwtAuthType"));
            return new AuthenticationState(cp);
        }

        public async Task MarkUserAsAuthenticated(TokenVM token, LoginResponse response, bool writeLocalStorage)
        {
            await _localStorage.SetItemAsStringAsync(TokenKey, token.Token);
            await _localStorage.SetItemAsync("EmployeeId", response.Id);
            await _localStorage.SetItemAsync("Username", response.Username);
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token.Token);
            NotifyUserLogin(response.Username);

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

        //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    //try
        //    //{
        //    //    var savedToken = await _localStorage.GetItemAsStringAsync(TokenKey);
        //    //    var token = new TokenVM() { Token = savedToken };

        //    //    if (string.IsNullOrWhiteSpace(savedToken))
        //    //        return Anonymous;

        //    //    return BuildAuthenticatedState(token);
        //    //}
        //    //catch(Exception e)
        //    //{
        //    //    Console.WriteLine(e);
        //    //    return new(new(new ClaimsIdentity()));
        //    //}
        //}
        //private AuthenticationState BuildAuthenticatedState(TokenVM savedToken)
        //{
        //    //_httpClient.DefaultRequestHeaders.Authorization = new("bearer", savedToken.Token);
        //    //return new(new(new ClaimsIdentity(ParseClaimsFromJwt(savedToken.Token), "apiauth")));
        //}
        //public async Task<bool> MarkUserAsAuthenticated(TokenVM token, bool writeToStorage = true)
        //{
        //    try
        //    {
        //        //var jwt = .Request.Headers["Authorization"].Replace("Bearer ", string.Empty);
        //        //_httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token.Token);
        //        //var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token.Token), "apiauth"));
        //        //var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        //        //NotifyAuthenticationStateChanged(authState);
        //        //if (writeToStorage)
        //        //    await _localStorage.SetItemAsync(TokenKey, token.Token);
        //        //return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
        //private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        //{
        //    //var handler = new JwtSecurityTokenHandler();
        //    //var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(jwt);
        //    ////var token = handler.ReadJwtToken(jwt);
        //    //var claims = token.Claims.Select(claim => new Claim(claim.Type, claim.Value)).ToList();
        //    //return claims;


        //    //var handler = new JwtSecurityTokenHandler();
        //    //if (handler.ReadToken(jwt) is not JwtSecurityToken tokenS) return null;

        //    //var username = tokenS.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name).Value;
        //    //var userId = tokenS.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        //    //return new Claim[]
        //    // {
        //    //new("username", username),
        //    //new("id", userId)
        //    // };
        //}
    }
}
