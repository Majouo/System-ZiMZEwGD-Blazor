
using System.ComponentModel.DataAnnotations;

namespace System_ZiMZEwGD_Blazor.Data
{
    public abstract class Device
    {
        [Key]
        public abstract string Name { get; set; }
        public abstract string Description { get; }
        public abstract string IP { get; }
        public abstract uint Port { get; }
        internal abstract string Password { get; }
    }
}
