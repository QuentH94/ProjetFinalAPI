using BLL.Services;
using BLL.Interfaces;
using DAL.Repositories;
using DAL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ProjetFinalAPI;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {


            // ValidateIssuer = false;
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["jwt:issuer"],

            //ValidateAudience = false;
            ValidateAudience = true,
            ValidAudience = builder.Configuration["jwt:audience"],


            ValidateLifetime = true,


            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]))
        };
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddSignalR();
builder.Services.AddRouting();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
    );
});
builder.Services.AddScoped<IMessageGlobalRepository, MessageGlobalService>(sp =>
    new MessageGlobalService(
        new System.Data.SqlClient.SqlConnection(
            builder.Configuration.GetConnectionString("default"))));

builder.Services.AddScoped<IAmiRepository, AmiService>(sp =>
    new AmiService(
        new System.Data.SqlClient.SqlConnection(
            builder.Configuration.GetConnectionString("default"))));

builder.Services.AddScoped<IUtilisateurRepository, UtilisateurService>(sp =>
    new UtilisateurService(
        new System.Data.SqlClient.SqlConnection(
            builder.Configuration.GetConnectionString("default"))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();


app.UseRouting();

app.UseCors("CorsPolicy");

app.UseWebSockets(new Microsoft.AspNetCore.Builder.WebSocketOptions { KeepAliveInterval = TimeSpan.FromSeconds(120) });
app.UseAuthorization();
app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MessageGlobalHub>("/MessageGlobalHub", options =>
    {
        options.Transports = HttpTransportType.WebSockets;
    });
    
    endpoints.MapControllers();
});


app.Run();
