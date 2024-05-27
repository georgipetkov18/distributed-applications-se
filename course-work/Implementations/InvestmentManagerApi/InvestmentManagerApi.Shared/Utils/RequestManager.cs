using InvestmentManagerApi.Shared.Exceptions;
using System.Net;
using System.Text;
using System.Text.Json;

namespace InvestmentManagerApi.Shared.Utils
{
    public static class RequestManager
    {
        public static async Task<T> GetAsync<T>(string url, bool authorize = false)
        {
            T responseData;
            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                if (authorize)
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {SessionManager.Token}");
                }

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new ClientErrorException();
                }
                var jsonContent = await response.Content.ReadAsStringAsync();
                responseData = JsonSerializer.Deserialize<T>(jsonContent, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }

            return responseData;
        }

        public static async Task<TResult> PostAsync<TBody, TResult>(string url, TBody body, bool authorize = false, string redirectTo = null)
        {
            TResult responseData;
            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                if (authorize)
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {SessionManager.Token}");
                }
                var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                var jsonContent = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    if (redirectTo != null) 
                    {
                        throw new ClientErrorException(redirectTo);
                    }
                    throw new ClientErrorException();
                }
                responseData = JsonSerializer.Deserialize<TResult>(jsonContent, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }

            return responseData;
        }

        public static async Task<TResult> PatchAsync<TBody, TResult>(string url, TBody body, bool authorize = false, string redirectTo = null)
        {
            TResult responseData;
            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                if (authorize)
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {SessionManager.Token}");
                }
                var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PatchAsync(url, content);
                var jsonContent = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    if (redirectTo != null)
                    {
                        throw new ClientErrorException(redirectTo);
                    }
                    throw new ClientErrorException();
                }
                responseData = JsonSerializer.Deserialize<TResult>(jsonContent, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }

            return responseData;
        }

        public static async Task DeleteAsync(string url, bool authorize = false)
        {
            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                if (authorize)
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {SessionManager.Token}");
                }

                HttpResponseMessage response = await client.DeleteAsync(url);
                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new ClientErrorException();
                }
            }

        }
    }
}
