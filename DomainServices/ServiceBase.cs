using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data;
using System;

namespace DomainServices
{
    public abstract class ServiceBase
    {
        protected IUnitOfWork UnitOfWork;
        protected IRepositoryFactory RepositoryFactory;

        public ServiceBase(IUnitOfWork<MicroserviceDbContext> unitOfWork,
            IRepositoryFactory<MicroserviceDbContext> repositoryFactory)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            RepositoryFactory = repositoryFactory ?? (IRepositoryFactory)UnitOfWork;
        }
    }
}
