using System.Text.Json.Serialization;
using AutoMapper;
using Challenge_2.Context;
using Challenge_2.DTOs.Mappings;
using Challenge_2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions
                .ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<ReceitasService>();
var mappingConfig = new MapperConfiguration(mc => 
    {
        mc.AddProfile(new MappingProfile());
    });
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
                        options.UseSqlServer(connectionString));
var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
