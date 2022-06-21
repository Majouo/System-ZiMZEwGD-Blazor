
using System.ComponentModel.DataAnnotations;

namespace System_ZiMZEwGD_Blazor.Data
{
    public class Monitor : Device
    {
        [Key]
        public override uint ID { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override string IP { get; set; }
        public override uint Port { get; set; }
        public override string Password { get; set; }

        public Monitor()
        {
            Name = "N/A";
            Description = "N/A";
            IP = "N/A";
            Port = 0;
            Password = "N/A";
        }
        public Monitor(string name, string description, string ip, uint port, string password)
        {
            Name = name;
            Description = description;
            IP = ip;
            Port = port;
            Password = password;
        }

    }
}
