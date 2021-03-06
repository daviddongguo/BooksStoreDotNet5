# BooksStoreDotNet5

### Main Steps

#### Create solution and projects

- dotnet new console
- dotnet new classlib
- dotnet new mvc
- dotnet new nunit

#### Add project, add reference

- dotnet sln add
- dotnet add reference

#### Add packages

Domain:

- Microsoft.AspNetCore.Mvc.DataAnnotations" Version="2.2.0"/>
- Microsoft.EntityFrameworkCore" Version="3.1.10"/>
- Microsoft.EntityFrameworkCore.Design" Version="3.1.10"/>
- Microsoft.EntityFrameworkCore.Tools" Version="3.1.10"/>
- MySql.Data.EntityFrameworkCore" Version="8.0.22"/>
- MySqlConnector" Version="0.69.10"/>

WebApp:

- Microsoft.EntityFrameworkCore.Tools" Version="3.1.10">
- Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="5.0.1" />

#### Configure DBContext via AddDbContext

- public EFDbContext(DbContextOptions<EFDbContext> options) : base(options){}
- public EFProductRepository(EFDbContext ctx){  _ctx = ctx; }
- services.AddDbContext<EFDbContext>(x => x.UseMySQL(Configuration.GetConnectionString("MySqlConnection"),
       b => b.MigrationsAssembly("David.BooksStore.WebApp")));

#### Use DI

- public ProductController(IProductsRepository rep)
        {
            _rep = rep;
        }

- services.AddScoped<IProductsRepository, EFProductRepository>();
