using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.CrossCore.Converters;
using ResidentAppCross.Resources;

public class SharedIconsConverter : MvxValueConverter<SharedResources.Icons, string>
{
    protected override string Convert(SharedResources.Icons value, Type targetType, object parameter, CultureInfo culture)
    {
        return value.ToString().ToLower();
    }
}

