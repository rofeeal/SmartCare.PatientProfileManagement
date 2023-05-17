using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartCare.PatientProfileManagement.Application.Commands;
using SmartCare.PatientProfileManagement.Application.Handlers.Commands;
using SmartCare.PatientProfileManagement.Application.Handlers.Queries;
using SmartCare.PatientProfileManagement.Application.Queries;
using SmartCare.PatientProfileManagement.Domain.Entites;
using SmartCare.PatientProfileManagement.Domain.Events;
using SmartCare.PatientProfileManagement.Domain.Interfaces.Repository;
using SmartCare.PatientProfileManagement.Infrastructure.Context;
using SmartCare.PatientProfileManagement.Infrastructure.Interfaces.Database;
using SmartCare.PatientProfileManagement.Infrastructure.Repositories;
using SmartCare.PatientProfileManagement.PatientProfileManagement.Infrastructure.Models;
using SmartCare.PatientProfileManagement.Shared.Result;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Configure MS SQL Server connection
var connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.Configure<MongoDatabaseSettings>(
        builder.Configuration.GetSection(nameof(MongoDatabaseSettings)));
builder.Services.AddSingleton<IMongoDatabaseSettings>(provider =>
    provider.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);

builder.Services.AddTransient<IRequestHandler<CreatePatientProfileCommand, ResultWithData<Guid>>, CreatePatientProfileCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetPatientsProfilesQuery, ResultWithData<List<PatientProfile>>>, GetPatientsProfilesQueryHandler>();
builder.Services.AddTransient<INotificationHandler<PatientProfileCreatedEvent>, PatientProfileRepository>();

builder.Services.AddTransient<PatientProfileQueryRepository>();

builder.Services.AddScoped<IPatientProfileQueryRepository, PatientProfileQueryRepository>();
builder.Services.AddScoped<IPatientProfileCommandRepository, EventStoreRepository>();

builder.Services.AddControllers();


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
