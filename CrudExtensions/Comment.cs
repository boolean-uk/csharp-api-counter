namespace CrudExtensions
{
    public class Comment
    {
        public int PostId { get; set; }
        public int Id { get; set; }
        public string Text { get; set; }
        public string Username { get; set; }

        public int Likes { get; set; }
    }
}
