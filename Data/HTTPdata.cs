using System.Net.Http;

namespace System_ZiMZEwGD_Blazor.Data
{
    
    public class HTTPdata
    {

        public async Task<Consumption> get(Monitor device,string filename)
        {
            using (var httpClient = new HttpClient())
            {
                var adress = new Uri("http//"+device.IP+device.Port+"/"+filename);
                var result = httpClient.GetAsync(adress).Result;
                string content = result.Content.ReadAsStringAsync().Result;
                Consumption data= new Consumption(content);
                return await Task.FromResult(data);
            }


        }
        public async Task<string> getext(Monitor device, string filename)
        {
            using (var httpClient = new HttpClient())
            {
                var adress = new Uri(device.IP + device.Port + "/" + filename);
                var result = httpClient.GetAsync(adress).Result;
                var content = result.Content.ReadAsStringAsync().Result;
                return await Task.FromResult<string>(content);
            }


        }
    }
    
}
    
