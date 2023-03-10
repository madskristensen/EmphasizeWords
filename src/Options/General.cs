using System.ComponentModel;
using System.Runtime.InteropServices;

namespace EmphasizeWords
{
    internal partial class OptionsProvider
    {
        [ComVisible(true)]
        public class GeneralOptions : BaseOptionPage<General> { }
    }

    public class General : BaseOptionModel<General>
    {
        [Category("General")]
        [DisplayName("Percentage of word")]
        [Description("The percentage of word to mark bold.")]
        [DefaultValue(.5)]
        public double PercentageOfWord { get; set; } = .5;

        [Category("General")]
        [DisplayName("Enabled")]
        [Description("Controls if the Emphasize Words mode is enabled or not..")]
        [DefaultValue(true)]
        public bool Enabled { get; set; } = true;
    }
}
