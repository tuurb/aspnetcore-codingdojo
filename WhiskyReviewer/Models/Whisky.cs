using System.Collections.Generic;

namespace WhiskyReviewer.Models
{
    public class Whisky
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int StatedAge { get; set; }

        public int DistilleryId { get; set; }
        public Distillery Distillery { get; set; }

        public List<Review> Reviews { get; set; }
    }
}