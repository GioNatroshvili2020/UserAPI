using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserApi.DAL.Annotations
{
    public class PersonNameValidation : ValidationAttribute
    {
        private static string Georgian = "აბგდევზთიკლმნპჟრსტუფქღყშჩცძწჭხჯჰ";
        public override bool IsValid(object value)
        {
            string name = value.ToString().ToLower().Trim();

            bool isLatin = Regex.IsMatch(name,
              @"^[a-zA-Z]+$");

            bool isGeorgian = true;
           
            foreach(var i in name)
            {
                if (!Georgian.Contains(i))
                {
                    isGeorgian = false;
                    break;
                }
            }

            bool isValid = isGeorgian||isLatin;

            if (isGeorgian && isLatin)
                isValid = false;

            return isValid;
        }
    }
}
