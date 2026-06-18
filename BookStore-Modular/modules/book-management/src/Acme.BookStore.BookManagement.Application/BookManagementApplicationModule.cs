using Volo.Abp.Modularity;

namespace Acme.BookStore.BookManagement
{
    [DependsOn(
        typeof(BookManagementDomainModule),
        typeof(BookManagementApplicationContractsModule)
        )]
    public class BookManagementApplicationModule : AbpModule
    {
    }
}
