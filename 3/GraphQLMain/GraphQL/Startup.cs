using ConferencePlanner.GraphQL.Buyers;
using ConferencePlanner.GraphQL.Categories;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using ConferencePlanner.GraphQL.Events;
using ConferencePlanner.GraphQL.Sellers;
using ConferencePlanner.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ApplicationDbContext>(
                options => options.UseSqlite("Data Source=conference.db"));

            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<BuyerQueries>()
                    .AddTypeExtension<SellerQueries>()
                    .AddTypeExtension<EventQueries>()
                    .AddTypeExtension<CategoryQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<BuyerMutations>()
                    .AddTypeExtension<EventMutations>()
                    .AddTypeExtension<SellerMutations>()
                    .AddTypeExtension<CategoryMutations>()
                .AddSubscriptionType(d => d.Name("Subscription"))
                    .AddTypeExtension<BuyerSubscriptions>()
                    .AddTypeExtension<EventSubscriptions>()
                .AddType<BuyerType>()
                .AddType<EventType>()
                .AddType<SellerType>()
                .AddType<CategoryType>()
                .EnableRelaySupport()
                 .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true) // Додайте цей рядок
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions()
                .AddDataLoader<SellerByIdDataLoader>()
                .AddDataLoader<EventByIdDataLoader>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
