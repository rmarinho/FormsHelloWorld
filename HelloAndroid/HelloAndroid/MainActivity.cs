using System;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Threading;

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
			public string GetText() => "Learn more at https://aka.ms/xamarin-quickstart";

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
