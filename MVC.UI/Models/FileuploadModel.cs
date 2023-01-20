using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.UI.Models
{
    public class FileuploadModel
    {
        //[DataType(DataType.Upload)]
        //[Display(Name = "Upload File")]
        //[Required(ErrorMessage = "Please choose file to upload.")]
        public string file { get; set; }
    }
}