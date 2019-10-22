using System.ComponentModel.DataAnnotations.Schema;
using Fathcore.EntityFramework;

namespace Simantri.Data.Domain
{
    public class Config : BaseEntity<Config, int>
    {
        public string Key { get; set; }
        public string Value { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
    }
}
