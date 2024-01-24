namespace CrudExtensions
{
    public static class PostHelper
    {

        public static void Initialize()
        {
            CommentHelper.Initialize();

            if (Posts.Count == 0)
            {
                Posts.Add(new Post() { Id = 1, Title = "Books", Text = "I like books.", Comments = CommentHelper.Comments.FindAll(x => x.PostId == 1) } );
                Posts.Add(new Post() { Id = 2, Title = "Toys", Text = "I like toys.", Comments = CommentHelper.Comments.FindAll(x => x.PostId == 2) });
                Posts.Add(new Post() { Id = 3, Title = "Videogames", Text = "I like videogames.", Comments = CommentHelper.Comments.FindAll(x => x.PostId == 3) });
                Posts.Add(new Post() { Id = 4, Title = "Pencils", Text = "I like pencils.", Comments = CommentHelper.Comments.FindAll(x => x.PostId == 4) });
                Posts.Add(new Post() { Id = 5, Title = "Notepads", Text = "I like notepads.", Comments = CommentHelper.Comments.FindAll(x => x.PostId == 5) });
            }
        }
        public static List<Post> Posts { get; set; } = new List<Post>();

    }
}
