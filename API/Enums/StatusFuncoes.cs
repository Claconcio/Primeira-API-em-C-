using System.ComponentModel;

namespace API.Enums

{
    public enum StatusFuncoes
    {
        [Description("A Fazer")]
        AFazer = 1,

        [Description("Em andamento")]
        EmAndamento = 2,

        [Description("Concluído")]
        Concluido  = 3,
    }
}
