using System.ComponentModel.DataAnnotations;
using DogusBlog.Entity;

namespace DogusBlog.Models
{
    public class PostCreateViewModel
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [Display(Name = "Başlık")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "İçerik alanı zorunludur.")]
        [Display(Name = "İçerik")]
        public string? Content { get; set; }

        [Required(ErrorMessage = "Url alanı zorunludur.")]
        [Display(Name = "Url")]
        public string? Url { get; set; }

        public string? Image { get; set; }

        [Display(Name = "Kapak Görseli")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }

        public bool IsActive { get; set; }
    }
}