namespace Work4.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wage { get; set; }

        public Post() { }

        public Post(string name, int wage) =>
            (Name, Wage) = (name, wage);

        public Post(int id, string name, int wage) =>
            (Id, Name, Wage) = (id, name, wage);
    }
}
