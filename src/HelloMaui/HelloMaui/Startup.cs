using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;

namespace HelloMaui
{
	public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			//Uncomment for Preview4
			//appBuilder.UseFormsCompatibility();
			appBuilder.UseMauiApp<App>();
				//.ConfigureFonts(fonts =>
				//{
				//	fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				//});
		}
	}
}