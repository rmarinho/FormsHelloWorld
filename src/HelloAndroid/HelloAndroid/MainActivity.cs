using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Text;
using Android.Text.Style;
using Android.Widget;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace HelloAndroid
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_main);
#if __BUILDER__
			UseBuilder(false);
			UseDI();
#else
			UseDefault();
#endif
			SetButtonVersion();
		}
		void SetButtonVersion()
		{
			Button button1 = FindViewById<Button>(Resource.Id.button1);
			var attribute = typeof(Button).Assembly.GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute;
			button1.Text = attribute.InformationalVersion;
		}

		void UseDefault()
		{
			var textService = new TextService();
			SetText(textService.GetText());
		}

		void UseBuilder(bool useDefault)
		{
			IHostBuilder builder;
			if(useDefault)
			{
				builder = Host.CreateDefaultBuilder();
			}
			else
			{
				builder = new HostBuilder().UseContentRoot(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
			}
			
			builder.ConfigureServices(collection => collection.AddSingleton<IHostLifetime, CustomHostLifetime>());
			var host = builder.Build();
			host.Start();
		}

		void UseDI()
		{
			var collection = new ServiceCollection();
			collection.AddSingleton<ITextService, TextService>();
			var serviceProvider = collection.BuildServiceProvider();
			var textService = serviceProvider.GetRequiredService<ITextService>();
			SetText($"From Builder {textService.GetText()}");
		}

		void SetText(string text)
		{
			TextView textView1 = FindViewById<TextView>(Resource.Id.textView1);
			var spannable = new SpannableStringBuilder(text);
			spannable.SetSpan(new StyleSpan(TypefaceStyle.Bold), 14, 47, 0);
			textView1.SetText(spannable, TextView.BufferType.Spannable);
		}

		public interface ITextService
		{
			string GetText();
		}

		public class TextService : ITextService
		{
			public string GetText() => "Learn more at https://aka.ms/xamarin-quickstart";
		}

		public class CustomHostLifetime : IHostLifetime
		{
			public Task StopAsync(CancellationToken cancellationToken)
			{
				return Task.Run(() => { });
			}

			public Task WaitForStartAsync(CancellationToken cancellationToken)
			{
				return Task.Run(() => { });
			}
		}
	}
}
