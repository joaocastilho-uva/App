using System.ComponentModel;

namespace App.Enums
{
    public enum MeioPagamento
    {
        [Description("Cartão de crédito")]
        Cartao = 1,

        [Description("Pix")]
        Pix = 2
    }
}
