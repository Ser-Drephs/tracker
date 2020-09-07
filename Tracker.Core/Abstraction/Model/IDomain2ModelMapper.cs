using System.Collections.Generic;

namespace Tracker.Core.Abstraction.Model
{
    public interface IDomain2ModelMapper<TModel, TDomain>
    {
        TModel MapToModel(TDomain entity);
        IEnumerable<TModel> MapToModel(IEnumerable<TDomain> entities);
    }
}
