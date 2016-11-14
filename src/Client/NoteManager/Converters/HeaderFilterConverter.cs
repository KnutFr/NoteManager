using System;
using System.Windows.Data;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Text;
using System.IO;

namespace NoteManager.Converters
{
    public class HeaderFilterConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string filter = values[0] as string;
            string headerText = values[1] as string;

            string text = "{0}{3}" + headerText + " {4}";
            if (!String.IsNullOrEmpty(filter))
                text += "(Filter: {2}" + values[0] + "{4})";
            text += "{1}";

            text = new System.Xml.Linq.XText(text).ToString();

            text = String.Format(text,
             @"<TextBlock xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>",
             "</TextBlock>", "<Run FontWeight='bold' Text='", "<Run Text='", @"'/>");

            MemoryStream stream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(text));

            TextBlock block = (TextBlock)System.Windows.Markup.XamlReader.Load(stream);
            return block;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
