using System;

namespace Ksb.Domain
{
    public class Children
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public string DateNaiss { get; set; }
        public string Quartier { get; set; }
        public string contact { get; set; }
        public string ContactParent { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
