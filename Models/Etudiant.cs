using System.ComponentModel.DataAnnotations;

namespace projetdotnet.Models
{
    public class Etudiant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CIN { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string sexe { get; set; }
        public DateTime DN { get; set; }
        public string email { get; set; }
        public string classe { get; set; }
        public string specialite { get; set; }


    }
}
