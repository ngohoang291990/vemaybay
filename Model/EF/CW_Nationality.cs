using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("CW_Nationality")]
    public class CW_Nationality
    {
       
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Tên quốc gia")]
        [Required(ErrorMessage = "Yêu cầu nhập tiêu đề !")]
        [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
        public string NationalityName { get; set; }

        [Display(Name = "Mã quốc gia")]
        public string NationalityCode { get; set; }

        [Display(Name = "Fee")]
        public int Fee { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Hiển thị")]
        public bool IsActive { get; set; }
        [Display(Name = "Thứ tự")]
        public int SortOrder { get; set; }

        [Display(Name = "TimeZoo")]
        public string TimeZoo { get; set; }

        [Display(Name = "Icon")]
        [StringLength(250, ErrorMessage = "Bạn chỉ được nhập tối đa 250 ký tự !")]
        public string Icon { get; set; }

        [Display(Name = "Embassy")]
        public string Embassy { get; set; }

        [Display(Name = "Requirement")]
        public string Requirement { get; set; }

        public string FilterName { get; set; }
        [Display(Name = "Tips")]
        public string Tips { get; set; }

        
    }
}