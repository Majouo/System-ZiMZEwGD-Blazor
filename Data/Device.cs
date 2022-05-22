namespace System_ZiMZEwGD_Blazor.Data
{
    public abstract class Device
    {
        protected abstract string Name { get; }
        protected abstract string Description { get; }
        protected abstract string IP { get; set; }
        protected abstract uint Port { get; set; }
    }
}
