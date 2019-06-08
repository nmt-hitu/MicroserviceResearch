using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus
{
    public class IntegrationEvent
    {
        [JsonProperty]
        public Guid Id { get; protected set; }

        [JsonProperty]
        public DateTime CreationDate { get; protected set; }

        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime createDate)
        {
            Id = id;
            CreationDate = createDate;
        }
    }
}
