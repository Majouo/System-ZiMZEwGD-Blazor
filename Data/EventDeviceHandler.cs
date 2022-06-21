using System.ComponentModel.DataAnnotations;
using Renci.SshNet;

namespace System_ZiMZEwGD_Blazor.Data
{
    public class EventDeviceHandler
    {
        [Key]
        public string name { get; set; }
        public string command { get; set; }
        public DateTime when { get; set; }
        public Device device { get; set; }

        public EventDeviceHandler(string n,string c,DateTime w, Device d)
        {
            name = n;
            command = c;
            when = w;
            device = d;

        }

        public async Task<Consumption> Get(Device d, string filename)
        {
            using (var httpClient = new HttpClient())
            {
                var adress = new Uri("http//" + d.IP + d.Port + "/" + filename);
                var result = httpClient.GetAsync(adress).Result;
                string content = result.Content.ReadAsStringAsync().Result;
                Consumption data = new Consumption(content);
                return await Task.FromResult(data);
            }

        }

        public async Task<Consumption> sendCommand(Device d, string command)
        {
            var method = new PasswordAuthenticationMethod(d.Name, d.Password);//użytkownik i hasło
            var connection = new Renci.SshNet.ConnectionInfo(d.IP,d.Name, method);// połączenie                                                                        //urządzenie
            var client = new SshClient(connection);
            if (!client.IsConnected)
            {
                Console.WriteLine("Not connected... ");
                client.Connect();
            }
            var writeCommand =client.RunCommand(command);
            Console.WriteLine(writeCommand.Result);
            ulong value;
            if(ulong.TryParse(writeCommand.Result, out value))
            {
                Consumption data = new Consumption(value, DateTime.Now);
                client.Disconnect();
                return data;
            }
            else
            {
                Consumption data = new Consumption();
                client.Disconnect();
                return data;
            }
            
            
        }


    }
}
