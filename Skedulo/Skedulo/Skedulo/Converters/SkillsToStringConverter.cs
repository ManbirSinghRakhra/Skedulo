using Skedulo.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Skedulo.Converters
{
    public class SkillsToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<Skills> skills = (List<Skills>)value;
            var skillsNameList = skills.Select(c => c.Name);
            string skillsInString = string.Join(",", skillsNameList);
            return skillsInString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
