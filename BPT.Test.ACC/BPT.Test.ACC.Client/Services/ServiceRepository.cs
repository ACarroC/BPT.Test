using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BPT.Test.ACC.Client.Services
{
    public class ServiceRepository
    {
        public HttpClient client { get; set; }
        public ServiceRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44349/");
        }
        public async Task<Response> GetAsync<T>(string urlBase , string servicePrefix, string tokenType, string accessToken, T request)
        {
            try
            {
                
                
                string url = urlBase + $"{servicePrefix}";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                        EstatusCode = ((int)response.StatusCode).ToString()
                    };
                }

                var userResponse = JsonConvert.DeserializeObject<T>(result);
                var objectResult = new Response
                {
                    IsSuccess = true,
                    Result = userResponse
                };
                return objectResult;
            }
            catch (System.Net.WebException webex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Fallo la conexion intente mas tarde"
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> PostAsync<T>(string urlBase, string servicePrefix, string tokenType, string accessToken, T request)
        {
            try
            {
                string Objeto = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(Objeto, Encoding.UTF8, "application/json");
               
                string url = urlBase + $"{servicePrefix}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                        EstatusCode = ((int)response.StatusCode).ToString()
                    };
                }

                return new Response
                {
                    IsSuccess = true,
                    Result = answer,
                    EstatusCode = ((int)response.StatusCode).ToString()
                };
            }
            catch (System.Net.WebException webex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Fallo la conexion intente mas tarde"
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> PutAsync<T>(string urlBase, string servicePrefix, string tokenType, string accessToken, T model)
        {
            try
            {
                string request = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                string url = urlBase + $"{servicePrefix}";
                HttpResponseMessage response = await client.PutAsync(url, content);
                string answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                        EstatusCode = ((int)response.StatusCode).ToString()
                    };
                }
                else
                {
                    var responseResult = JsonConvert.DeserializeObject<T>(answer);
                    return new Response
                    {
                        IsSuccess = true,
                        Result = responseResult,
                    };
                }
            }
            catch (System.Net.WebException webex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Fallo la conexion intente mas tarde"
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> DeleteAsync<T>(string urlBase, string servicePrefix, string tokenType, string accessToken, T model)
        {
            try
            {
                string request = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
               
                string url = urlBase + $"{servicePrefix}";
                HttpResponseMessage response = await client.DeleteAsync(url);
                string answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                        EstatusCode = ((int)response.StatusCode).ToString()
                    };
                }
                else
                {
                    var responseResult = JsonConvert.DeserializeObject<T>(answer);
                    return new Response
                    {
                        IsSuccess = true,
                        Result = responseResult,
                    };
                }
            }
            catch (System.Net.WebException webex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Fallo la conexion intente mas tarde"
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
