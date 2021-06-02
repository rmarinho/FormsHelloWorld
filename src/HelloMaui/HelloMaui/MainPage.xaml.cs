using System;
using System.Reflection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace HelloMaui
{
	public partial class MainPage : ContentPage, IPage
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
