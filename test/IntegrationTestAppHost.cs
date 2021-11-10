using Funq;
using ServiceStack;
using ServiceStack.Auth;

namespace test
{
    public class IntegrationTestAppHost : AppSelfHostBase
    {
        public IntegrationTestAppHost() 
            : base("Test", typeof(Startup).Assembly) {}

        public override void Configure(Container container)
        {
            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                new IAuthProvider[] {
                    // Adapter to enable ASP.NET Core Identity Auth in ServiceStack
                    new NetCoreIdentityAuthProvider(AppSettings),
                }));
        }
    }
}