using System.ComponentModel;
using Shared.Converter;

namespace Shared.Enums
{
    public enum DrinkType : int
    {
        [Description("Сік")]
        Сік,

        [Description("Гарячий напій")]
        Гарячийнапій,

        [Description("Холодний напій")]
        Холоднийнапій        
    }
}