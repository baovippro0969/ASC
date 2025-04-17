using Microsoft.AspNetCore.Identity;

namespace ASC.WEB.Areas.Accounts.Models
{
    public class ServiceEngineerViewModel
    {
        public List<IdentityUser> ServiceEngineers { get; set; } // Lưu trữ danh sách nhân viên
        public ServiceEngineerRegistrationViewModel Registration { get; set; } // Lưu trữ nhân viên mới hoặc cập nhật
    }
}
