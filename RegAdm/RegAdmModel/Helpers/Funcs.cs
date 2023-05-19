using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RegAdmModel.Helpers
{
    public static class Funcs
    {
        public static int GetAge(DateOnly bday)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            int age = today.Year - bday.Year;
            if (bday > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
