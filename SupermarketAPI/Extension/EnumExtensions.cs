using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace SupermarketAPI.Extension
{
    public static class EnumExtensions
    {
        //Define generic method
        public static string ToDescriptionString<TEnum>(this TEnum @enum)
        {
            //get type of info (class, inteface, struct, etc definition) w/ GetType
            FieldInfo info = @enum.GetType().GetField(@enum.ToString()); //gets specific enumeration value
            //finds all description attrubutes applied over enumeration value and stores in array
            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            //short hand to check if there is at least one not null description attribute for enumeration type
            return attributes?[0].Description ?? @enum.ToString();
        }
    }
}
