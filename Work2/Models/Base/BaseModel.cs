using System;

namespace Work2.Models.Base
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        protected static int RandomizeNewId() =>
            new Random().Next(1, int.MaxValue);
    }
}