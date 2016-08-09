using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên !")]
        [StringLength(300, ErrorMessage = "Bạn chỉ được nhập tối đa 300 ký tự !")]
        public string FullName { get; set; }

        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Bắt buộc phải nhập!")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Prequent")]
        public string Prequent { get; set; }
        [Display(Name = "Tin nhắn")]
        public string Message { get; set; }

        public string InfoFly { get; set; }
        public string InfoCus { get; set; }
        public int Payment { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Total { get; set; }
    }
}