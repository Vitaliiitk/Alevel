
namespace CreateDBContext.Models
{
    public sealed class Category
    {
        public int Id { get; set; }
        public string Category_Name { get; set; }
        public List<Pet> Pets { get; set; }
        public List<Breed> Breed { get; set; }
    }
}
