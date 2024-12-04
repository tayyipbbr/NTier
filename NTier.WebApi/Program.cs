using FluentValidation;
using NTier.Business;
using NTier.Business.Features.Categories.CreateCategory;
using NTier.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Documentation",
        Version = "v1"
    });
});



builder.Services.AddBusiness();
builder.Services.AddDataAccess(builder.Configuration); 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

var validator = builder.Services.BuildServiceProvider().GetService<IValidator<CreateCategoryCommand>>();
if (validator == null)
{
    throw new Exception("CreateCategoryValidator DI container'da bulunamadý.");
}

// Validator'ýn düzgün yüklendiðini kontrol et.
using (var scope = app.Services.CreateScope())
{
    var validators = scope.ServiceProvider.GetServices<IValidator<CreateCategoryCommand>>();

    if (!validators.Any())
    {
        throw new Exception("CreateCategoryValidator yüklenemedi.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
