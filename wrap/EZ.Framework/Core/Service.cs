using System;

namespace EZ.Framework.Core
{
    public class Service<TUnitOfWork> : IService
        where TUnitOfWork : IUnitOfWork
    {
        protected readonly TUnitOfWork UnitOfWork;

        public Service(TUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));

            UnitOfWork = unitOfWork;
        }
    }
}
