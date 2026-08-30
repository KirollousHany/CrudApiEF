using CrudApiDemo.Data;
using CrudApiDemo.Extensions.DJ;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApplicationServices();
builder.Services.AddControllers();


builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly, includeInternalTypes: true);
//builder.Services.AddValidatorsFromAssemblyContaining<CreateClientDtoValidator>();
//builder.Services.AddFluentValidationAutoValidation();

//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.InvalidModelStateResponseFactory = context =>
//    {
//        var errors = context.ModelState
//            .Where(x => x.Value?.Errors.Count > 0)
//            .SelectMany(x => x.Value!.Errors)
//            .Select(x => x.ErrorMessage)
//            .ToList();

//        var errorMessage = string.Join(" ", errors);

//        var response = BaseResponse<object>.FailResponse(
//            errorMessage,
//            StatusCodes.Status400BadRequest);

//        return new BadRequestObjectResult(response);
//    };
//});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
//app.MapClientEndpoints();
//app.MapProductEndpoints();
//app.MapOrderEndpoints();
//app.MapOrderItemEndpoints();

app.Run();