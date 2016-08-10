using System;

namespace ExifLib
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class IFDAttribute : Attribute
    {
        public readonly IFD IFD;

        public IFDAttribute(IFD ifd)
        {
            IFD = ifd;
        }
    }
}