using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text.Json.Serialization;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

var dataSourceBuilder = new NpgsqlDataSourceBuilder(builder.Configuration.GetConnectionString("myCon"));
//dataSourceBuilder.MapEnum<NodeType>("nodetype");
//dataSourceBuilder.MapEnum<RowStatus>("rowstatus");
var dataSource = dataSourceBuilder.Build();
//#pragma warning disable CS0618 // Type or member is obsolete
NpgsqlConnection.GlobalTypeMapper.MapEnum<NodeType>("nodetype");
NpgsqlConnection.GlobalTypeMapper.MapEnum<RowStatus>("rowstatus");
//#pragma warning restore CS0618 // Type or member is obsolete

// Add services to the container.
builder.Services.AddDbContext<InfrastructureDbContext>(op => op.UseNpgsql(dataSource));

builder.Services.AddControllers().AddJsonOptions(op =>
{
    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter<NodeType>());
    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter<RowStatus>());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
