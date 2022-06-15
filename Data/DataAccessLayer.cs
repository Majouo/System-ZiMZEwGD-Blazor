using System_ZiMZEwGD_Blazor.Data;
using System;
namespace System_ZiMZEwGD_Blazor.Data

{
    public class DataAccessLayer
    {
        public void Dispose()
        {


        }
        public void SaveForm(Consumption consumption)
        {
            using (ApplicationDbContext applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Consumption.Add(consumption);
                applicationDbContext.SaveChanges();
            }
        }
    }
}
