using System.Collections.Generic;

namespace WhiskyReviewer.Models
{
    public class Distillery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public List<Whisky> Whiskies { get; set; }
    }
}