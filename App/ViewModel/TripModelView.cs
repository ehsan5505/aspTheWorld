using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheWorld.ModelView
{
    public class TripModelView
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255,MinimumLength =5)]
        public String Name { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public IList<StopModelView> Stops { get; set; }
    }
}
