using DbProvider;
using DbProvider.View;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace OtusExam;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ShowContracts();
    }

    private void ShowContracts()
    {
        using TestContext db = new();

        ContractListView.ItemsSource = db.Contraсts
            .AsNoTracking()
            .Select(x => new ContractView
            {
                ContractId = x.ContraсtId,
                SupplierName = x.Supplier.Name,
                BuyerName = x.Buyer.Name,
                DateFrom = x.Startdate,
                DateTo = x.Enddate,
                Tariff = x.Tariff.Name,
                Delay = x.Delay,
                FinancingPercent = x.FinancingPercent
            })
            .ToArray();
    }

    private void SuppliesBtn(object sender, RoutedEventArgs e)
    {
        new SuppliesWindow().Show();
    }

    private void SuppliersBtn(object sender, RoutedEventArgs e)
    {
        new SuppliersWindow().Show();
    }

    private void BuyersBtn(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Not implemented");
    }

    private void TariffsBtn(object sender, RoutedEventArgs e)
    {
        new TariffsWindow().Show();
    }

    private void Trunshes(object sender, RoutedEventArgs e)
    {   
        new TrunshesWindow().Show();
    }

    private async void Payment(object sender, RoutedEventArgs e)
    {
        var dlg = new IncomingPayment();

        if (dlg.ShowDialog() == true)
        {
            using TestContext db = new();

            string cmd = $"call factoring.process_payment({dlg.ContractId}, \'{dlg.InvoiceNum}\', {dlg.Amount})";
            var rowsAffected = await db.Database.ExecuteSqlRawAsync(cmd);
        }
    }

    private void Operations(object sender, RoutedEventArgs e)
    {
        new Actions().Show();
    }

    private void Claims(object sender, RoutedEventArgs e)
    {
        new Claims().Show();
    }
}
