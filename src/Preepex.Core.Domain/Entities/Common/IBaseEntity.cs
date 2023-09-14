﻿namespace Preepex.Core.Domain.Entities.Common
{
    public interface IBaseEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
