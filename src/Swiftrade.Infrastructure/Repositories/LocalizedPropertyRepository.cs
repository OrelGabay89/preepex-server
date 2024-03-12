using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Infrastructure.DbContexts;
using System.Linq;

namespace Swiftrade.Infrastructure.Repositories
{
    public class LocalizedPropertyRepository : ILocalizedPropertyRepository
    {
        private readonly SwiftradeContext _preepexContext;

        public LocalizedPropertyRepository(SwiftradeContext preepexContext)
        {
            _preepexContext = preepexContext;
        }

        public IQueryable<Localizedproperty> Table()
        {
            return _preepexContext.Localizedproperties;
        }
    }
}
