using DbProvider;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace OtusExam;

public partial class SuppliersWindow : Window
{
    public SuppliersWindow()
    {
        InitializeComponent();

        using TestContext db = new();
        var suppliers = db.Suppliers.AsNoTracking().ToArray();

        SupplierListView.ItemsSource = suppliers;
    }
}
