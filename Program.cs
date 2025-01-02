using WhoIsTheUgliest.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton(_ => {
    ImageAndVote item= new ImageAndVote();

    item.Votes.Add("/images/pe.jpg", 0);
    item.Votes.Add("/images/me.jpg", 0);
    item.Votes.Add("/images/mnp.jpg", 0);
    item.Votes.Add("/images/CLM.jpg", 0);
    item.Votes.Add("/images/pmh.jpg", 0);
    item.Votes.Add("/images/psa.jpg", 0);
    item.Votes.Add("/images/pucho.jpg", 0);
    item.Votes.Add("/images/tint.jpg", 0);

    return item;
});

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
