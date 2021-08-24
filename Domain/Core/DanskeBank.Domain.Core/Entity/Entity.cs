using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Domain.Core.Entity
{
    public interface IEntity
    {
    }

    public interface IEntity<TPrimaryKey> : IEntity
    {
        /// <summary>
        /// Entity'nin primary key olan property'si
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}
