using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Domain.parent
{
    public class DefaultParent
    {
        public int Id { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public Boolean IsDeleted { get; set; }
        public string DeletedAt { get; set; }
        public int UserId { get; set; }
        public string code { get; set; }
    }
}
