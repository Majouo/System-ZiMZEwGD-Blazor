using System.ComponentModel.DataAnnotations;

namespace System_ZiMZEwGD_Blazor.Data
{
    public abstract class Measurment
    {
        [Key]
        public abstract DateTime date { get; set; }
        public abstract ulong value { get; set; }
        public abstract string type { get; set; }

    }
    public class Consumption:Measurment
    {
        [Key]
        public override DateTime date { get; set; }
        public override ulong value { get; set; }
        public override string type { get; set; } 

        public Consumption()
        {
            value = 0;
            type = "KW/H";
            date = DateTime.Now;
        }
        public Consumption(ulong v, DateTime d)
        {
            value = v;
            type = "KW/H";
            date = d;
        }
        public Consumption(string data)
        {
            string v = data.Split(' ')[0];
            type = "KW/H";
            DateTime d =DateTime.Parse(data.Split(' ')[1]);

        }

    }
}
