namespace CrudExtensions
{
    public static class CommentHelper
    {

        public static void Initialize()
        {
            if (Comments.Count == 0)
            {
                Comments.Add(new Comment() { PostId = 1, Id = 1, Username = "BookLiker", Text = "I like books too!", Likes = 6 });
                Comments.Add(new Comment() { PostId = 1, Id = 2, Username = "BookCentrist", Text = "I'm ok with books!", Likes = 3 });
                Comments.Add(new Comment() { PostId = 1, Id = 3, Username = "BookHater", Text = "I hate books!!!!", Likes = 0 });
                Comments.Add(new Comment() { PostId = 1, Id = 4, Username = "RandomGuy27", Text = "I like trains more :)", Likes = 10 });
                Comments.Add(new Comment() { PostId = 2, Id = 1, Username = "ToyLiker", Text = "I like toys too!", Likes=2 });
                Comments.Add(new Comment() { PostId = 3, Id = 1, Username = "VideogameLiker", Text = "I like videogames too!", Likes = 4 });
                Comments.Add(new Comment() { PostId = 5, Id = 1, Username = "NotepadLiker", Text = "I like notepads too!", Likes = 5 });
                Comments.Add(new Comment() { PostId = 5, Id = 2, Username = "NotepadHater", Text = "I hate notepads :(", Likes = 1 });
            }
        }
        public static List<Comment> Comments { get; set; } = new List<Comment>();

    }
}
