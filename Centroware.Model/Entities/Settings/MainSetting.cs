﻿using System.ComponentModel.DataAnnotations;

namespace Centroware.Model.Entities.Settings
{
    public class MainSetting : BaseEntity
    {
        public string Logo { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string YoutubeUrl { get; set; }
        public string ContactUsTitle { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Longtude { get; set; }
        public string Latetude { get; set; }
    }
}
