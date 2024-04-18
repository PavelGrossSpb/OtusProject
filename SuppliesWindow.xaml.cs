using DbProvider;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace OtusExam;

/// <summary>
/// Interaction logic for Suppliers.xaml
/// </summary>
public partial class SuppliesWindow : Window
{
    public SuppliesWindow()
    {
        InitializeComponent();

        Update();
    }

    private void NewSupply(object sender, RoutedEventArgs e)
    {
        if (new NewSupplyDlg().ShowDialog() == true)
        {
            Update();
        }
    }

    private void Update()
    {
        using TestContext db = new();
        var result = db.SuppliesView.FromSqlRaw("select * from factoring.getSupplies();");

        var suppliers = result.ToArray();
        SuppliesListView.ItemsSource = suppliers;
    }
}
