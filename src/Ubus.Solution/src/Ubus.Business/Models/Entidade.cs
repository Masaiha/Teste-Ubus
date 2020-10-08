using System;

namespace Ubus.Business.Models
{
    public abstract class Entidade
    {
        public Guid Id { get; private set; }

        public Entidade()
        {
            Id = Guid.NewGuid();
        }
    }
}
