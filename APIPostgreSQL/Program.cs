
using APIPostgreSQL.Entidades;
using APIPostgreSQL.Service;
using NHibernate;
using NHibernate.Cfg;

namespace APIPostgreSQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ClienteService>();//Registrar serviço
            builder.Services.AddScoped<PedidosService>();//Registrar serviço
            builder.Services.AddControllers();
            //configuração nhibernate
            builder.Services.AddSingleton<ISessionFactory>((s) =>
            {
                var config = new Configuration();
                config.Configure();
                return config.BuildSessionFactory();
            });
            // fim config nhibernate

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //configuração cors para integrar a api com javascript
            //builder.Services.AddCors(
            //b => b.AddDefaultPolicy(c =>
            //c.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
            //    )
            //);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}
