using System;
using System.Collections.Generic;

namespace RentApartment.Core.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public byte MessageType { get; set; }
        public byte MessageStatus { get; set; }
        public string MessageBody { get; set; }
        public int FK_Account { get; set; }
        public virtual Account Account { get; set; }
    }
}
