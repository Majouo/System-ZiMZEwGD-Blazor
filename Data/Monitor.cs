namespace System_ZiMZEwGD_Blazor.Data
{
    public class Monitor : Device
    {
        public Monitor(string name, string description, string ip, uint port)
        {
            Name = name;
            Description = description;
            IP = ip;
            Port = port;
        }
        protected override string Name { get; }
        protected override string Description { get; }
        protected override string IP { get; set; }
        protected override uint Port { get; set; }

    }
}
