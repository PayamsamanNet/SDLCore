using Data.Interfaces;
using Data.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace WebFrameWork.Configuration
{
    public static class ServicesCollectionExtended
    {
        public static void RegisterServiesEntities(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAgreementRepository, AgreementRepository>();
            services.AddScoped<IAgreementDetailRepository, AgreementDetailRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IBoxRepository, BoxRepository>();
            services.AddScoped<IBoxTypeRepository, BoxTypeRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IBranchManagerRepository, BranchManagerRepository>();
            services.AddScoped<IIbanRepository, IbanRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDegreeRepository, DegreeRepository>();
            services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();
            services.AddScoped<IForeignCustomerRepository, ForeignCustomerRepository>();
            services.AddScoped<IInsuranceRepository, Insurancerepository>();
            services.AddScoped<IlawyerRepository, LawyerRepository>();
            services.AddScoped<ILegalCustomerRepository, LegalCustomerRepository>();
            services.AddScoped<IRegionCodeRepository, RegionCodeRepository>();
            services.AddScoped<IRealCustomerRepository, RealCustomerRepository>();
            services.AddScoped<IlogRepository, LogRepository>();
            services.AddScoped<IRepositoryRepository, RepositoryRepository>();
            services.AddScoped<IRepositoryColumnRepository, RepositoryColumnRepository>();
            services.AddScoped<ISmsRepository, SmsRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
