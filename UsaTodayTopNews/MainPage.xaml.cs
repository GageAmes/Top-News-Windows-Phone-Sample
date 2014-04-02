using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace UsaTodayTopNews
{
    public partial class MainPage : PhoneApplicationPage
    {
        private ObservableCollection<NewsArticle> articles;

        public MainPage()
        {
            InitializeComponent();

            this.articles = new ObservableCollection<NewsArticle>();
            this.ArticleList.ItemsSource = this.articles;
        }

        private async void LoadArticles()
        {
            SystemTray.ProgressIndicator.IsVisible = true;

            try
            {
                List<NewsArticle> newArticles = await UsaTodayApi.GetTopNews();
                newArticles.Sort(new Comparison<NewsArticle>((a1, a2) => DateTime.Compare(a2.PublicationDate, a1.PublicationDate)));

                this.articles.Clear();
                foreach (NewsArticle article in newArticles)
                {
                    this.articles.Add(article);
                }
            }
            catch
            {
                MessageBox.Show("Unable to load the latest news articles.", "Something went wrong", MessageBoxButton.OK);
            }

            SystemTray.ProgressIndicator.IsVisible = false;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            SystemTray.ProgressIndicator = new ProgressIndicator();
            SystemTray.ProgressIndicator.IsIndeterminate = true;
            SystemTray.ProgressIndicator.Text = "Loading...";

            this.LoadArticles();
        }

        private void Article_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NewsArticle article = ((StackPanel)sender).DataContext as NewsArticle;

            if (article != null)
            {
                WebBrowserTask browser = new WebBrowserTask();
                browser.Uri = new Uri(article.Link);
                browser.Show();
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            this.LoadArticles();
        }
    }
}