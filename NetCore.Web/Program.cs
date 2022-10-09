using NetCore.Services.Interfaces;
using NetCore.Services.Svcs;
using NuGet.Protocol;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Host.ConfigureServices(services =>
{
    //의존성 주입을 사용하기 위해서 서비스로 등록
    //껍데기             내용물
    //IUser 인터페이스에 UserService 클래스 인스턴스 주입
    services.AddScoped<IUser, UserService>();

    //mvc 패턴을 사용하기 위해서 서비스로 등록
    //services.AddMvc();
});
//방법2
//builder.Services.AddScoped<IUser, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
