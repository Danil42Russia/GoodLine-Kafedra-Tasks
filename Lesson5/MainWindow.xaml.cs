using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Lesson5
{
    public delegate void DelegateEditStatus(Status status);

    public partial class MainWindow : Window
    {
        private static int page = 1;
        private UsersParser _parser;

        public MainWindow()
        {
            InitializeComponent();
        }

        void EditStatus(Status status)
        {
            string str = "";
            switch (status)
            {
                case Status.DOWNLOADING:
                    str = "Загрузка...";
                    break;
                case Status.GOOD:
                    str = "Выполнено";
                    break;
                case Status.ERROR:
                    str = "Ошибка при загрузке";
                    break;
            }
            Dispatcher.Invoke(() =>
            {
                StatusLabel.Content = str;
            });
        }

        async void GetInfo()
        {
            Result result = new Result();
            await Task.Run(() => { result = _parser.GetUsers(page); });           

            if (result == null)
                return;
            PreviousButton.IsEnabled = (page != 1);
            NextButton.IsEnabled = (page != result.total_pages);

            UsersList.Items.Clear();
            foreach (var data in result.data)
            {
                string name = data.first_name + " " + data.last_name;
                UsersList.Items.Add(name);
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            page++;
            GetInfo();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            page--;
            GetInfo();
        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            DelegateEditStatus edit = EditStatus;
            _parser = new UsersParser(edit);
            GetInfo();
        }
    }
}
