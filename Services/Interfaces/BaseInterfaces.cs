using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface BaseInterfaces<T,P>
    {
        public Task Create(P obj);

        public Task Delete(T id);

        public Task<List<P>> Get();

        public Task Update(T id, P obj);

    }
}
