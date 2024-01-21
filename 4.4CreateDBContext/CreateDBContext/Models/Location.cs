
namespace CreateDBContext.Models
{
    public sealed class Location
    {
        public int Id { get; set; }
        public string Location_Name { get; set; }

        public List<Pet> Pets { get; set; }
    }
}
