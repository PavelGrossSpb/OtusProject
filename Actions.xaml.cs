using DbProvider;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace OtusExam
{
    /// <summary>
    /// Interaction logic for Actions.xaml
    /// </summary>
    public partial class Actions : Window
    {
        public Actions()
        {
            InitializeComponent();
            using TestContext db = new();
            var suppliers = db.Actions.AsNoTracking().ToArray();

            ActionsListView.ItemsSource = suppliers;
        }
    }
}
