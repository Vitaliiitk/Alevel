
namespace CreateDBContext.Models
{
    public sealed class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int? CategoryID { get; set; }
        public Breed Breed { get; set; }
        public int? BreedID { get; set; }
        public float Age { get; set; }
        public Location Location { get; set; }
        public string Image_Url { get; set; }
        public string Description { get; set; }
    }
}
