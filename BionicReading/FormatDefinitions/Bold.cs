using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace BionicReading
{
    [ClassificationType(ClassificationTypeNames = Name)]
    [Export(typeof(EditorFormatDefinition))]
    [Name(Name)]
    [Order(After = Priority.High)]
    [UserVisible(true)]
    public class Bold : ClassificationFormatDefinition
    {
        public const string Name = "Bionic Bold";

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(Name)]
        public static readonly ClassificationTypeDefinition ClassificationType;

        public Bold()
        {
            DisplayName = Name;
            IsBold = true;
        }
    }
}