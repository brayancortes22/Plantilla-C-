using System;

namespace Entity.Model.Base
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Active { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
