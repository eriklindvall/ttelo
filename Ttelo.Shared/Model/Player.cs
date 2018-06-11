using System.ComponentModel.DataAnnotations.Schema;

namespace Ttelo.Shared.Model
{
    public class Player
    {
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }

        [NotMapped]
        public int Rank { get; set; }
        
    }
}
