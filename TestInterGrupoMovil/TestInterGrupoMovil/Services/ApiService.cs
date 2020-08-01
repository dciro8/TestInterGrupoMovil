using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestInterGrupoMovil.Clases;
using Xamarin.Forms.Internals;

namespace TestInterGrupoMovil.Services
{
    public class ApiService
    {
        #region Methods
        public async Task<Response> Get<T>(string urlBase, string key)
        {
            try
            {

                var header_base = "x-rapidapi-key";
               // var header_1 = "x-rapidapi-host";
                // get URL 
                var client = new HttpClient();
                
                client.DefaultRequestHeaders.Add(header_base, key);  
            
               
                var url = urlBase;
                var uri = new Uri(url);

                //var url = string.Format("{0}{1}", servicePrefix, id);
                var response = await client.GetAsync(uri);


                // Validate response return Error
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.StatusCode.ToString(),

                    };
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<T>>(result);
                    //If Success return Data
                    return new Response
                    {
                        IsSuccess = true,
                        Message = "Ok",
                        Result = list
                    };
                }

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
        #endregion

    }
}
