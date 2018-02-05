using System.ComponentModel;
namespace AMS_Script.Script
{
    public enum VariableType
    {
        [Description("Decimal Numbers ex: 1.123465687 with 28-29 significant digits for most accuracy")]
        Decimal,
        [Description("Integer which will not round the value ex: 4/5 = 0")]
        IntFloor,
        [Description("Integer which will round the value ex: 4/5 = 1")]
        Int,
        [Description("Decimal Numbers with 2 decimal round ex: 1.456 = 1.46")]
        Money
    }
}
