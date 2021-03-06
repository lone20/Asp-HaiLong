using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LLVBog.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Không bỏ trống mật khẩu", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }

        [Required]
        public System.Guid ResetCode { get; set; }
    }
}