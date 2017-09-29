using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RealEstate.HtmlHelpers
{
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Property,AllowMultiple =false)]
    public class EmailAddressesAttribute:DataTypeAttribute
    {
        readonly Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled);

        public EmailAddressesAttribute() : base(DataType.EmailAddress)
        {
            
        }
        public override bool IsValid(object value)
        {
            string str = Convert.ToString(value, CultureInfo.CurrentCulture);
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }
            Match match = regex.Match(str);
            return (match.Success && (match.Index == 0) && (match.Length == str.Length));
        }
    }
}