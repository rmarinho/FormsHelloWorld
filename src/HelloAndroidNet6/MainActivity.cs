using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Widget;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace HelloAndroidNet6
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_main);

#if __BUILDER__
			UseBuilder();
#else
			UseDefault();
#endif
		}

		void UseDefault()
		{
			var textService = new TextService();
			SetText(textService.GetText());
		}

		void UseBuilder()
		{
			var builder = Host.CreateDefaultBuilder();
			builder.ConfigureServices(collection =>
			{
				collection.AddSingleton<ITextService, TextService>();
				collection.AddSingleton<IHostLifetime, CustomHostLifetime>();
			});
			var host = builder.Build();
			host.Start();
			var textService = host.Services.GetRequiredService<ITextService>();
			SetText($"From Builder {textService.GetText()}");
		}

		void SetText(string text)
		{
			TextView textView1 = FindViewById<TextView>(Resource.Id.textView1);
			var spannable = new SpannableStringBuilder(text);
			spannable.SetSpan(new StyleSpan(TypefaceStyle.Bold), 14, text.Length - 1, 0);
			textView1.SetText(spannable, TextView.BufferType.Spannable);
		}

		public interface ITextService
		{
			string GetText();
		}

		public class TextService : ITextService
		{
			public string GetText() => "Learn more at https://github.com/dotnet/net6-mobile-samples";
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