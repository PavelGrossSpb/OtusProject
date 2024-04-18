using System.Windows;

namespace OtusExam
{
    public partial class IncomingPayment : Window
    {
        public IncomingPayment()
        {
            InitializeComponent();
        }

        public int ContractId { get; set; }

        public string InvoiceNum { get; set; }

        public decimal Amount { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContractId = int.Parse(ContractNumTb.Text);
            Amount = decimal.Parse(AmountTb.Text);
            InvoiceNum = InvoiceNumTb.Text;
            
            DialogResult = true;

            Close();
        }
    }
}

