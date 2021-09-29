using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Models
{
    public class Movie
    {
        [DisplayName("Film ID")]
        public int MovieId { get; set; }
        
        [DisplayName("Filmin Başlığı")]
        [Required(ErrorMessage ="Film Başlığı girmeden olmaz.")]
        [StringLength(50,MinimumLength =5,ErrorMessage ="Film Başlığı 5 karakterden az olamaz.")]
        public string Title { get; set; }        

        [DisplayName("Filmin Açıklaması")]
        [Required(ErrorMessage = "Film Açıklaması girmeden olmaz.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Film Açıklaması 5 karakterden az olamaz.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Film Yönetmeni girmeden olmaz.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Film Yönetmeni 5 karakterden az olamaz.")]
        [DisplayName("Filmin Yönetmeni")]
        public string Director { get; set; }     
        [DisplayName("Oyuncular")]
        public string[] Actors { get; set; }
        [Required(ErrorMessage = "Film Afişi girmeden olmaz.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Film Afişi 5 karakterden az olamaz.")]
        [DisplayName("Filmin Afişi")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Film Kategorisi girmeden olmaz.")]
        [DisplayName("Filmin Kategorisi")]
        public int? GenreId { get; set; }
        
    } 
}
