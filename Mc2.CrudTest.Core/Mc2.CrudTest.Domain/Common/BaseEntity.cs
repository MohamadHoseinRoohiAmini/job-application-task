using System;

namespace Mc2.CrudTest.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate => DateTime.Now;
        public DateTime? UpdatedDate => DateTime.Now;
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted => false;
    }
}
