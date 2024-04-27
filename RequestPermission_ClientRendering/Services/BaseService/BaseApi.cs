using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace RequestPermission_ClientRendering.Services.BaseService;

public class BaseApi
{
    protected string ApiName { get; set; }
    protected HttpClient HttpClient { get; init; }
    public BaseApi(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }
    protected async Task HandlePutResponse<T>(T entity, string requestUrl)
    {
        //var response = await HttpClient.PutAsJsonAsync(ApiName + requestUrl, entity);
        var content = JsonSerializer.Serialize(entity);
        var result = new StringContent(content, Encoding.UTF8, "application/json");
        //var content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
        var response = await HttpClient.PutAsync(ApiName + requestUrl, result);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    protected async Task HandlePutResponseJson<T>(T entity)
    {
        var response = await HttpClient.PutAsJsonAsync(ApiName, entity);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    protected async Task HandlePostResponse<T>(T entity, string requestUrl)
    {
        var content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
        HttpContent httpContent = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
        var response = await HttpClient.PostAsync(ApiName + requestUrl, content);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    protected async Task HandlePostResponseAsJson<T>(T entity, string requestUrl)
    {
        var response = await HttpClient.PostAsJsonAsync(ApiName + requestUrl, entity);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    protected async Task<TItem> HandleLoginPostResponse<TItem, T>(T entity, string requestUrl)
    {
        try
        {
            var response = await HttpClient.PostAsJsonAsync(ApiName + requestUrl, entity);
            var responseEntity = await response.Content.ReadFromJsonAsync<TItem>();
            return responseEntity ?? default;
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected async Task HandleDeleteResponse(Guid id, string requestUrl)
    {
        var response = await HttpClient.DeleteAsync(ApiName + requestUrl);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    protected async Task HandleDeleteResponseByIntId(int id, string requestUrl)
    {
        var response = await HttpClient.DeleteAsync(ApiName + requestUrl);
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    protected async Task<List<T>?> HandleReadResponse<T>(string requestUrl)
    {
        try
        {
            var response = await HttpClient.GetAsync(ApiName + requestUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<List<T>>();
                return content ?? Enumerable.Empty<T>().ToList();
            }
            else
            {
                var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                throw new Exception(errorMessage);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
    protected async Task<T?> HandleSingleReadResponse<T>(string requestUrl)
    {
        var response = await HttpClient.GetAsync(ApiName + requestUrl);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<T>();
            return content ?? default;
        }
        else
        {
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
    //protected async Task HandleDeleteResponse(Guid id,string requestUrl)
    //{
    //    var response = await HttpClient.DeleteFromJsonAsync(ApiName + requestUrl,);
    //}
}
