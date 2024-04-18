using DbProvider;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace OtusExam;

public partial class NewSupplyDlg : Window
{
    public NewSupplyDlg()
    {
        InitializeComponent();

        using TestContext db = new();
        var suppliers = db.Contraсts.AsNoTracking().ToArray();

        SupplyDateTB.Text = DateTime.Now.ToString("yyyy-MM-dd");

        ContractNumsComboBox.ItemsSource = suppliers;
    }

    private void Add(object sender, RoutedEventArgs e)
    {
        using TestContext db = new();

        var supply = new Supply
        {
            Contraсtid = (ContractNumsComboBox.SelectedValue as DbProvider.Contraсt).ContraсtId,
            Amount = decimal.Parse(AmountTB.Text),
            Invoicenum = UpdNumTB.Text,
            Createdate = DateOnly.Parse(SupplyDateTB.Text),
        };

        var suppliers = db.Supplies.Add(supply);

        db.SaveChanges();

        DialogResult = true;
        Close();
    }
}
