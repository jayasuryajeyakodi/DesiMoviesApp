//---------------------------------------------------------------------------
//
// <copyright file="BubbleListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>10/4/2016 6:07:22 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.Rss;
using DesiMovies.Sections;
using DesiMovies.ViewModels;
using AppStudio.Uwp;

namespace DesiMovies.Pages
{
    public sealed partial class BubbleListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public BubbleListPage()
        {
			ViewModel = ViewModelFactory.NewList(new BubbleSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Disabled;
            Microsoft.HockeyApp.HockeyClient.Current.TrackEvent(this.GetType().FullName);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("97f5d53c-a88b-45a7-86e3-247333ec247b");
			ShellPage.Current.ShellControl.SetCommandBar(commandBar);
			if (e.NavigationMode == NavigationMode.New)
            {			
				await this.ViewModel.LoadDataAsync();
                this.ScrollToTop();
			}			
            base.OnNavigatedTo(e);
        }

    }
}
