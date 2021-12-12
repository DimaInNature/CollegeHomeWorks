namespace Work4.Models
{
    public class StructuralDivision
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StructuralDivision() { }

        public StructuralDivision(string name) => Name = name;

        public StructuralDivision(int id, string name) => (Id, Name) = (id, name);
    }
}
