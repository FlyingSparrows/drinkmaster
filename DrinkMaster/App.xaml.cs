﻿using DrinkMaster.Pages;

namespace DrinkMaster;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new AppShell();
		MainPage = new NavigationPage(new StartPage());
	}
}
