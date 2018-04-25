namespace WhiskyReviewer.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Grade { get; set; }

        public int WhiskyId { get; set; }
        public Whisky Whisky { get; set; }
    }
}