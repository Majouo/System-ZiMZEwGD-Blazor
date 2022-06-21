using System.ComponentModel.DataAnnotations;
using Renci.SshNet;

namespace System_ZiMZEwGD_Blazor.Data
{
    public class EventDeviceHandler
    {
        public string Name { get; set; }
        [Key]
        public string Command { get; set; }
        public DateTime When { get; set; }


        public EventDeviceHandler(string name, string command, DateTime when)
        {
            Name = name;
            Command = command;
            When = when;
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
            var connection = new Renci.SshNet.ConnectionInfo(d.IP, d.Name, method);// połączenie                                                                        //urządzenie
            var client = new SshClient(connection);
            if (!client.IsConnected)
            {
                Console.WriteLine("Not connected... ");
                client.Connect();
            }
            var writeCommand = client.RunCommand(command);
            Console.WriteLine(writeCommand.Result);
            ulong value;
            if (ulong.TryParse(writeCommand.Result, out value))
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
