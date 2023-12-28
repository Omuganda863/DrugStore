using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.Controllers.Models
{
    public class Drugs
    {
        public Guid Id { get;set; }= Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }

        [ForeignKey("Id")]
        public User user { get; set; } = default!;
        public Guid UserId { get; set; }

    }
}
