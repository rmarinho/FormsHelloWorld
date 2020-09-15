using System.Reflection;
using Xamarin.Forms;

namespace HelloWorld
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
#if _XAMLC_
			lblXamlc.Text = "USING XAMLC";
#else
			lblXamlc.Text = "NOT USING XAMLC";
#endif

			var attribute = typeof(Label).Assembly.GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute;
			btnXamarinForms.Text = attribute.InformationalVersion;
		}
	}
}
