using System.ComponentModel.DataAnnotations;

namespace projetdotnet.Models
{
    public class Note
    {
        [Key]
        public int Id_N { get; set; }
        [Required]
        public string Module { get; set; }
        public double NoteControle { get; set; }
        public double NoteExamain { get; set; }
        public double NoteFinal  { get; set; }
       
}
