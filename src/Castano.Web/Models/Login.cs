namespace Castano.Web.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Login
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class RecaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("error_codes")]
        public string[] ErrorCodes { get; set; }
    }
}