using System.ComponentModel.DataAnnotations;

namespace System_ZiMZEwGD_Blazor.Data
{
    public abstract class Device
    {
        [Key]

        public abstract uint ID { get; set; }
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract string IP { get; set; }
        public abstract uint Port { get; set; }
        public abstract string Password { get; set; }
    }
}
