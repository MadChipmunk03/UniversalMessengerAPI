using System.ComponentModel.DataAnnotations.Schema;

namespace UniversalMessengerAPI.Model
{
    [Table("tbRecipients")]
    public class Recipient
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("recipient")]
        public string Value { get; set; }

        [Column("service")]
        public string Service { get; set; }    
    }
}
