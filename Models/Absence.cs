using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetdotnet.Models
{
    public class Absence
    {
        [Key]

        public int Id_Ab{ get; set; }
        [Required]
        public DateTime DA { get; set; }
        public string matiere { get; set; }
        public string seance { get; set; }
        public string justificatif { get; set; }
        public int? IdEtudiant { get; set; }
        [ForeignKey("Id")]
        public virtual Etudiant Etudiant { get; set; }

    }
   
}
