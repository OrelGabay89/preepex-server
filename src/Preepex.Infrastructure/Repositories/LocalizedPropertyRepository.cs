using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Domain.Entities;
using Preepex.Infrastructure.DbContexts;
using System.Linq;

namespace Preepex.Infrastructure.Repositories
{
    public class LocalizedPropertyRepository : ILocalizedPropertyRepository
    {
        private readonly PreepexContext _preepexContext;

        public LocalizedPropertyRepository(PreepexContext preepexContext)
        {
            _preepexContext = preepexContext;
        }

        public IQueryable<Localizedproperty> Table()
        {
            return _preepexContext.Localizedproperties;
        }
    }
}
