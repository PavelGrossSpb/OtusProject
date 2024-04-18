using DbProvider;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Windows;
using System.Windows.Controls;

namespace OtusExam;

public partial class TrunshesWindow : Window
{
    public TrunshesWindow()
    {
        InitializeComponent();
        Update();
    }

    private void Update()
    {
        using TestContext db = new();
        var trunshes = db.Transhes.AsNoTracking().ToArray();

        TrunshesListView.ItemsSource = trunshes;
    }

    private void MakePP(object sender, RoutedEventArgs e)
    {
        var transh = (sender as MenuItem).DataContext as Transh;
        int? id = transh?.Transhid;

        using NpgsqlCommand command = new NpgsqlCommand($"select result from factoring.getpayment({id}) as result");
        command.Connection = new NpgsqlConnection(TestContext.ConnnectionString);
        command.Connection.Open();
        NpgsqlDataReader dr = command.ExecuteReader();

        while (dr.Read())
            new PaymentAct(dr.GetString(0)).Show();
    }
}
