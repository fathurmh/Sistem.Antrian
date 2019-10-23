using System.ComponentModel.DataAnnotations.Schema;
using Fathcore.EntityFramework;

namespace Simantri.Core.Data.Domain
{
    public partial class Config : BaseEntity<Config, int>
    {
        public Config(string key, string value, bool isActive = true)
        {
            Key = key;
            Value = value;
            IsActive = isActive;
        }

        public string Key { get; set; }
        public string Value { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
    }
}
