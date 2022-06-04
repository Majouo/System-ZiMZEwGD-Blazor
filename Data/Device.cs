namespace System_ZiMZEwGD_Blazor.Data
{
    public abstract class Device
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string IP { get; }
        public abstract uint Port { get; }
    }
}
