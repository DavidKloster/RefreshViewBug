namespace RefreshViewBug
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
       public bool Refreshing {get;set;}
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
         
        }

        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            Refreshing = false;
            this.OnPropertyChanged(nameof(Refreshing));
        }
    }

}
