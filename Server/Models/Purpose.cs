using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("Purpose")]
    public class Purpose : TEntity
    {
        [JsonPropertyName("purposeId")]
        [Column("PurposeId")]
        public int Id { get; set; }
        public string Name { get; set; }

        public void Update(Purpose purpose)
        {
            Name = purpose.Name;
        }
    }
}
