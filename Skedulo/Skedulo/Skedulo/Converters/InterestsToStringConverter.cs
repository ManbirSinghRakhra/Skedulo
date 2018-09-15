using Skedulo.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace Skedulo.Converters
{
    public class InterestsToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<Interests> interests = (List<Interests>)value;
            var interestsNameList = interests.Select(c => c.Name);
            string interestsInString = string.Join(",", interestsNameList);
            return interestsInString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
