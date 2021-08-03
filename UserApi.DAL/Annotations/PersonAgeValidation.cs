using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApi.DAL.Annotations
{
    public class PersonAgeValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (d.Year * 100 + d.Month) * 100 + d.Day;
            var realAge= (a - b) / 10000;
            return realAge >= 18; 

        }
    }
}
