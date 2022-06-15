using Renci.SshNet;
namespace System_ZiMZEwGD_Blazor.Data
{
    public class SSH
    {
        public async Task<Consumption> sendCommand(string command,Device device)
        {
            var method = new PasswordAuthenticationMethod(device.Name, device.Password);//użytkownik i hasło
            var connection = new Renci.SshNet.ConnectionInfo(device.IP,device.Name, method);// połączenie                                                                        //urządzenie
            var client = new SshClient(connection);
            if (!client.IsConnected)
            {
                Console.WriteLine("Not connected... ");
                client.Connect();
            }
            var writeCommand = client.RunCommand(command);
            Consumption data = new Consumption(writeCommand.Result);
            return await Task.FromResult(data);
        }
      
    }
}
