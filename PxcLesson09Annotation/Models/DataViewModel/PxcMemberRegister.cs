using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PxcLesson09Annotation.Models.DataViewModel
{
    public class PxcMemberRegister
    {
        public int PxcMemberId { get; set; }
        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không để trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage ="Tên đăng nhập có độ dài trong khoảng 220 ký tự")]
        public string PxcMemberName { get; set; }
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trồng")]
        [DataType(DataType.Password)]
        public string PxcMemberPassword { get; set; }
        public string PxcMemberEmail { get; set; }
        public string PxcMemberPhoneNumber { get; set; }
        public string PxcMemberFullName { get; set; }
        public DateTime PxcBirthday { get; set; }
    }
}
