using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }
        public int ConditionId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
