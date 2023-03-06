using Common.Setting;
using Data.Interfaces;
using Data.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Service.Authentication;
using Service.ServiceFile;
using System.Text;

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
            services.AddScoped<IJwtRepository, JwtRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IFileService, FileService>();
        }
        public static void RegisterJwtService(this IServiceCollection services, SecuritySetting _siteSetting)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var secretKey = Encoding.UTF8.GetBytes(_siteSetting.SecretKey);
                ///Encrypting
                var keyEncrypting = Encoding.UTF8.GetBytes(_siteSetting.Encryptkey);
                var securityKeyEncryp = new SymmetricSecurityKey(keyEncrypting);
                var validationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    RequireSignedTokens = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    TokenDecryptionKey = securityKeyEncryp,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidAudience = _siteSetting.Audience,
                    ValidateIssuer = true,
                    ValidIssuer = _siteSetting.Issuer,

                };
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = validationParameters;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCors", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                   .Build();

                });
            });

        }


    }
}
