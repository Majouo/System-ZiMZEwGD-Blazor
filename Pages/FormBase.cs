using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System_ZiMZEwGD_Blazor.Data;

namespace FormBase
{
    public class FormBase : ComponentBase
    {
        public Consumption Form
        {
            get;
            set;
        }
        protected override Task OnInitializedAsync()
        {
            Form = new Consumption();
            return base.OnInitializedAsync();
        }
        public void SaveForm()
        {


        }
    }
}
