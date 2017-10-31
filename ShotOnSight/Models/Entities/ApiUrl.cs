using System.ComponentModel.DataAnnotations;

namespace ShotOnSight.Models.Entities
{
    public class ApiUrl : Transport
    {
        public long ApiUrlId { get; set; }
        [Display(Name = "Register Users")]
        public string RegisterUsersUrl { get; set; }
        [Display(Name = "Login Url")]
        public string LoginUrl { get; set; }
        [Display(Name = "Fetch Users")]
        public string FetchUsersUrl { get; set; }
        [Display(Name = "Forgot Password Link")]
        public string ForgotPasswordLinkUrl { get; set; }
        [Display(Name = "Reset Password")]
        public string ResetPasswordUrl { get; set; }
        [Display(Name = "Change Password")]
        public string ChangePasswordrl { get; set; }
        [Display(Name = "Edit Profile")]
        public string EditProfileUrl { get; set; }
        [Display(Name = "Tenantcy Identity No")]
        public long TenancyId { get; set; }
    }
}
