using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using SoftwareControle.Context;
using SoftwareControle.Repositories.Interfaces;
using SoftwareControle.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SoftwareControle;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }



    // This method gets called by the runtime. Use this method to add services to the container.


    //AQUI FAZEMOS A CONFIGURAÇÃO PARA CONEXAO COM O BANCO

    // Aqui, você está usando o método AddDbContext para registrar o contexto do banco de dados AppDbContext no contêiner de injeção de dependência. O método UseSqlServer especifica que você deseja usar o provedor SQL Server para a conexão com o banco de dados. A configuração da conexão é buscada do arquivo appsettings.json usando a chave "DefaultConnection".
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        

       // Registro do serviço do repositório
            services.AddScoped<IFerramentaRepository, FerramentaRepository>();
            services.AddScoped<ICriarOrdemRepository, CriarOrdemRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
           
        
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



        services.AddControllersWithViews();
        services.AddMemoryCache();
        services.AddSession();



    }




    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseSession();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}