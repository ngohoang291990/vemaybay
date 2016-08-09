using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("Nationality")]
    public class Nationality
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nationality Name")]
        [Required(ErrorMessage = "Yêu cầu nhập tiêu đề !")]
        [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
        public string NationalityName { get; set; }

        [Display(Name = "NationalityCode")]
        public string NationalityCode { get; set; }

        public int Fee { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Hiển thị")]
        public bool IsActive { get; set; }
        [Display(Name = "Thứ tự")]
        public int SortOrder { get; set; }


        public string TimeZoo { get; set; }

        [Display(Name = "Icon")]
        [StringLength(250, ErrorMessage = "Bạn chỉ được nhập tối đa 250 ký tự !")]
        public string Icon { get; set; }

        public string Embassy { get; set; }
        public string Requirement { get; set; }
        public string FilterName { get; set; }
        public string Tips { get; set; }
    }
}