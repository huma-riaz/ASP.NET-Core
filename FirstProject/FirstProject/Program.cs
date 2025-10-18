namespace FirstProject
{
    public class program
    {
        public static void Main(string[] args)
        {

         var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMvc();
         var app = builder.Build();

            // Simple 
            //app.MapGet("/", () => "Hello World!");

            // For Only Controller 
            //app.MapControllers();

            // With Views
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );


         app.Run();

        }
    }
}
