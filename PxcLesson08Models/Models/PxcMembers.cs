using System.ComponentModel;

namespace PxcLesson08Models.Models
{
    public class PxcMembers
    {
        public string PxcMembersId { get; set; }
        public string PxcUserName { get; set; }
        public string PxcPassword { get; set; }
        [DisplayName("Họ và tên")]
        public string PxcFullname { get; set; }
        public string PxcEmail { get; set; }
    }
}
