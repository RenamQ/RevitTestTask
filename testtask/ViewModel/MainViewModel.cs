namespace TestTask.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string _title = "Plugin";
        private string _message = "test";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
    }
}