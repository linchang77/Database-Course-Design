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
        options.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto; // ������̬��
        options.SerializerSettings.Formatting = Formatting.Indented; // ����JSON���
    }); ;

// Add CORS service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:3333") // �滻Ϊǰ�˵ĵ�ַ
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IScenicSpotService, ScenicSpotService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<ITourGroupService, TourGroupService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
/////////////////////////////////////////�Լ�������Ҫ��������//////////////////////////////////////////////////////////////
//����DbContext
//builder.Services.AddDbContext<ModelContext>(options =>
//    options.UseOracle("DATA SOURCE=123.60.14.84:1521/ORCL;TNS_ADMIN=C:\\\\\\\\Users\\\\\\\\LQS\\\\\\\\Oracle\\\\\\\\network\\\\\\\\admin;PERSIST SECURITY INFO=True;USER ID=SYSTEM;PASSWORD=summer_Dt514"));
builder.Services.AddDbContext<ModelContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Enable CORS
app.UseCors("AllowSpecificOrigin");

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
