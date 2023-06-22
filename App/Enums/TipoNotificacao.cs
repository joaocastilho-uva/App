using System.ComponentModel;

namespace App.Enums
{
    public enum TipoNotificacao
    {
        [Description("Sucesso")]
        Sucesso = 1,

        [Description("Informativa")]
        Informativa = 2,

        [Description("Erro")]
        Erro = 3
    }
}
