using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tracker.Core.Abstraction.Business
{
    public interface ICommandHandler <TDomain>
    {
        Task<int> Create(TDomain domainObj, CancellationToken cancellationToken);

        IEnumerable<TDomain> Read(CancellationToken cancellationToken);

        Task<int> Update(TDomain domainObj, CancellationToken cancellationToken);

        Task<int> Delete(TDomain domainObj, CancellationToken cancellationToken);
    }
}
