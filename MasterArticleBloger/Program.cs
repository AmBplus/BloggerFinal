using Insfrustucture.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddTransient<>()
builder.Services.AddRazorPages();
string connection = builder.Configuration.GetConnectionString("SqlServerSa");
Bootstrapper.Config(builder.Services, connection);

//builder.Services


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
