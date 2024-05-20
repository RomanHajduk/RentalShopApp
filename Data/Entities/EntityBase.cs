using System.ComponentModel.DataAnnotations.Schema;

namespace RentalShopApp.Data.Entities
{
    public abstract class EntityBase : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
