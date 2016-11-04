using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NovusConceptum.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string PhoneNumber { get; set; }

        public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }

        public string ImageType { get; set; }
        public string ImageNom { get; set; } 
        public byte[] ImageData { get; set; }

        public string Steam { get; set; }
        public string Blizzard { get; set; }
        //public IndexViewModel(AspNetUserInfoSup InfoSup)
        //{
        //    HasPassword = true;
        //    ImageData = InfoSup.Image.Data;
        //    ImageNom = InfoSup.Image.Nom;
        //    ImageType = InfoSup.Image.Type;
        //}
    }
}
