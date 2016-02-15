using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;
using ResidentAppCross.Resources;

public class SharedIconsConverter : MvxValueConverter<SharedResources.Icons, string>
{
    protected override string Convert(SharedResources.Icons value, Type targetType, object parameter, CultureInfo culture)
    {
        return value.ToString().ToLower();
    }
}

public class ByteArrayToImage : MvxValueConverter<byte[], Bitmap>
{
    protected override Bitmap Convert(byte[] value, Type targetType, object parameter, CultureInfo culture)
    {
        var decodeByteArray = BitmapFactory.DecodeByteArray(value, 0, value.Length);
        return decodeByteArray;
    }
}

