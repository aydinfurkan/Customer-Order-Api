using System;

namespace OrderApi.Models
{
    public class BaseModel
    {
        protected BaseModel()
        {
            CreatedTime = DateTime.SpecifyKind(CreatedTime, DateTimeKind.Utc);
            UpdatedTime = DateTime.SpecifyKind(UpdatedTime, DateTimeKind.Utc);
        }

        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}