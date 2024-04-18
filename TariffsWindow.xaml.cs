using DbProvider;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace OtusExam
{
    public partial class TariffsWindow : Window
    {
        public TariffsWindow()
        {
            InitializeComponent();
            Update();
        }

        private void Update()
        {
            using TestContext db = new();
            var tariffs = db.Tariffs.AsNoTracking().ToArray();

            TariffListView.ItemsSource = tariffs;
        }
    }
}
