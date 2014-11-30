namespace ImdbLite.Web.Areas.Administration.ViewModels.Actors
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    using ImdbLite.Common;

    public class CreateActorViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [UIHint("SingleLineText")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [UIHint("SingleLineText")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [UIHint("SingleLineText")]
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        [UIHint("DateTime")]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = GlobalConstants.DateTimeFormatString, ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [UIHint("SingleLineText")]
        [Display(Name = "City")]
        public string BirthCity { get; set; }

        [UIHint("SingleLineText")]
        [Display(Name = "Country")]
        public string BirthCountry { get; set; }

        [UIHint("MultiLineText")]
        [Display(Name = "Biography")]
        [DataType(DataType.MultilineText)]
        public string Biography { get; set; }

        [UIHint("UploadFile")]
        [Display(Name = "Main Photo")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase MainPhotoFile { get; set; }
    }
}