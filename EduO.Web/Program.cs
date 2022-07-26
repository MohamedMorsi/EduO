using Blazored.LocalStorage;
using EduO.Core.Dtos;
using EduO.Web;
using EduO.Web.AuthProviders;
using EduO.Web.HttpServices.Contract;
using EduO.Web.HttpServices.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44325/api/") }.EnableIntercept(sp));

//builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IBaseService<ExClassDto>, ExClassService>();
builder.Services.AddScoped<IBaseService<GradeDto>, GradeService>();
builder.Services.AddScoped<IBaseService<CourseDto>, CourseService>();
builder.Services.AddScoped<IBaseService<CourseTypeDto>, CourseTypeService>();
builder.Services.AddScoped<IBaseService<FeeDto>, FeeService>();
builder.Services.AddScoped<IBaseService<TeacherDto>, TeacherService>();
builder.Services.AddScoped<IBaseService<StudentDto>, StudentService>();
builder.Services.AddScoped<IUserService, UserService>();



builder.Services.AddMudServices();

builder.Services.AddHttpClientInterceptor();

builder.Services.AddScoped<HttpInterceptorService>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

await builder.Build().RunAsync();
