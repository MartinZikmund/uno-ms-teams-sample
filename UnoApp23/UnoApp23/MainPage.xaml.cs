namespace UnoApp23
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TbCounter.Text = (int.Parse(TbCounter.Text) + 1).ToString();
        }
    }
}
