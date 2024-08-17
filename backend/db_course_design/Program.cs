using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using db_course_design.Common;
using db_course_design.Services;
using db_course_design.Services.impl;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson; // Newtonsoft.Json替代默认的System.Text.Json，提供了AddNewtonsoftJson方法
using Newtonsoft.Json;  // 引入Newtonsoft.Json命名空间

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        // 配置序列化设置
        options.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto; // 处理多态性
        options.SerializerSettings.Formatting = Formatting.Indented; // 美化JSON输出
    }); ;

builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<IScenicSpotService, ScenicSpotService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
/////////////////////////////////////////自己根据需要添加内容//////////////////////////////////////////////////////////////
//添加DbContext
builder.Services.AddDbContext<ModelContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

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
