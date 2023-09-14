﻿using Preepex.Core.Domain.Entities;
using System.Linq;

namespace Preepex.Core.Application.Interfaces.Repositories.Domain
{
    public interface ILocalizedPropertyRepository
    {
        IQueryable<Localizedproperty> Table();
    }
}
