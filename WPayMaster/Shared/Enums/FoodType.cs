using System.ComponentModel;

namespace Shared.Enums
{
    public enum FoodType
    {
        [Description("Салат")]
        Салат,

        [Description("Перша страва")]
        Першастрава,

        [Description("Мясна страва")]
        Мяснастрава,

        [Description("Рибна страва")]
        Рибнастрава,

        [Description("Гарнір")]
        Гарнір,

        [Description("Піца")]
        Піца,

        [Description("Паста")]
        Паста,

        [Description("Борошняний виріб")]
        Борошнянийвиріб,

        [Description("Десерт")]
        Десерт     
    }
}