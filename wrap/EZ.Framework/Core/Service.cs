using System;

namespace EZ.Framework.Core
{
    public class Service : IService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));

            UnitOfWork = unitOfWork;
        }
    }
}
