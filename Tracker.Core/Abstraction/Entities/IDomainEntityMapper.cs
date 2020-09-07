using System.Collections.Generic;

namespace Tracker.Core.Abstraction.Entities
{
    public interface IDomainEntityMapper<TEntitiy, TDomain>
    {
        TEntitiy MapToEntity(TDomain domainObject);
        IEnumerable<TEntitiy> MapToEntity(IEnumerable<TDomain> domainObjects);

        TDomain MapToDomain(TEntitiy entity);
        IEnumerable<TDomain> MapToDomain(IEnumerable<TEntitiy> entities);
    }
}
