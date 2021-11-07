namespace Work3.Interfaces.Models
{
    public interface IBook : IProduct
    {
        int Id { get; set; }
        string Genre { get; set; }
        int AgeRestriction { get; set; }
        int IdAuthor { get; set; }
    }
}