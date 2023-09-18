var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(options);
app.UseStaticFiles();
//var cacheMaxAgeOneWeek = (60 * 60 * 24 * 7).ToString();
//app.UseStaticFiles(new StaticFileOptions()
//{
//    OnPrepareResponse = ctx =>
//    {
//        ctx.Context.Response.Headers.Append(
//             "Cache-Control", $"public, max-age={cacheMaxAgeOneWeek}");
//    },
//});
app.MapFallbackToFile("/app1/{**slug}", "app1/index.html");
app.MapFallbackToFile("/app2/{**slug}", "app2/index.html");
app.MapFallbackToFile("index.html");

app.Run();
