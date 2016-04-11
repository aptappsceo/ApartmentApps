using System;
using System.ComponentModel.DataAnnotations;

namespace ApartmentApps.Data
{
    public partial class ImageReference   
    {

        [Key]
        public int Id { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }

        public Guid GroupId { get; set; }

    }
}