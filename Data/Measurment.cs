namespace System_ZiMZEwGD_Blazor.Data
{
    public class Measurment
    {
        protected ulong Value { get; }
        protected string Type { get; }

        protected DateTime Date { get; }
        public Measurment(ulong value, string type)
        {
            Value = value;
            Type = type;
            Date = DateTime.Now;
        }

    }
}
