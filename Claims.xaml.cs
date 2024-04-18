using DbProvider;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace OtusExam
{
    /// <summary>
    /// Interaction logic for Claims.xaml
    /// </summary>
    public partial class Claims : Window
    {
        public Claims()
        {
            InitializeComponent();
            Update();
        }

        private void Update()
        {
            using TestContext db = new();
            var tariffs = db.MonetaryСlaims.AsNoTracking().ToArray();

            ClaimsListView.ItemsSource = tariffs;
        }
    }
}
