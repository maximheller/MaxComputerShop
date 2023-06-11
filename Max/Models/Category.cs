namespace Max.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Processor> Processors { get; set; }
        //public ICollection<CategoryProcessor> ProcessorCategories { get; set; }

    }

    //public class Post  = Processor
    //{
    //    public int PostId { get; set; }      
    //    public string Content { get; set; }
    //    public ICollection<Tag> Tags { get; set; }
    //}

    //public class Tag = Category
    //{
    //    public string TagId { get; set; }
    //    public ICollection<Post> Posts { get; set; }
    //}






}




