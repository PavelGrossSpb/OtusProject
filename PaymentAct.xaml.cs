using System.Windows;

namespace OtusExam;

public partial class PaymentAct : Window
{
    public PaymentAct(string text)
    {
        InitializeComponent();

        txt.Text = text.Replace(",", $",{Environment.NewLine}")
            .Replace("[", string.Empty)
            .Replace("]", string.Empty)
            .Replace("{", "{" + Environment.NewLine)
            .Replace("}", Environment.NewLine + "}"); 
    }
}
