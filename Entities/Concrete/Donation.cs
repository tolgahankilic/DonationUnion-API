using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Donation : IEntity
    {
        public int DonationId { get; set; }
        public int ProductId { get; set; }
        public int ReceiverId { get; set; }
        public int GiverId { get; set; }
    }
}
