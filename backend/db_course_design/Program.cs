using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using db_course_design.Common;
using db_course_design.Services;
using db_course_design.Services.impl;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson; // Newtonsoft.Json���Ĭ�ϵ�System.Text.Json���ṩ��AddNewtonsoftJson����
using Newtonsoft.Json;  // ����Newtonsoft.Json�����ռ�

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        // �������л�����
        options.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto; // �����̬��
        options.SerializerSettings.Formatting = Formatting.Indented; // ����JSON���
    }); ;

builder.Services.AddScoped<OrderService>();
/////////////////////////////////////////�Լ�������Ҫ�������//////////////////////////////////////////////////////////////
//���DbContext
builder.Services.AddDbContext<ModelContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IScenicSpotService, ScenicSpotService>();

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
