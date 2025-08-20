using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMVC.Net.Models.Contacts
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Họ Tên không được để trống")]
        [Display(Name = "Họ Tên")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; }

        [Display(Name = "Ngày Gửi")]
        public DateTime DateSent { get; set; }

        // [Required(ErrorMessage = "Nội dung không được để trống")]
        [Display(Name = "Nội Dung")]
        public string? Message { get; set; }

        [StringLength(50)]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số Điện Thoại")]
        public string? Phone { get; set; }
    }
}