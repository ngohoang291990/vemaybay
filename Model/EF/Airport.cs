using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("Airport")]
    public class Airport
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Tên sân bay")]
        [Required(ErrorMessage = "Yêu cầu nhập tên sân bay !")]
        [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
        public string AirportName { get; set; }

        [Display(Name = "Mã sân bay")]
        [StringLength(10, ErrorMessage = "Bạn chỉ được nhập tối đa 10 ký tự !")]
        public string AirportCode { get; set; }

        [Display(Name = "Thứ tự")]
        public int SortOrder { get; set; }

        [Display(Name = "Hiển thị")]
        public bool IsActive { get; set; }
    }
}