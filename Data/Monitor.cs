namespace System_ZiMZEwGD_Blazor.Data
{
    public class Monitor : Device
    {
        public Monitor(string name, string description, string ip, uint port, string password)
        {
            Name = name;
            Description = description;
            IP = ip;
            Port = port;
            Password = password;
        }
        public override string Name { get; }
        public override string Description { get; }
        public override string IP { get; }
        public override uint Port { get; }
        internal override string Password { get; }

    }
}
