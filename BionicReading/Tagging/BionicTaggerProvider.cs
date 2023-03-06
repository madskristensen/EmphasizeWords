using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace BionicReading.Tagging
{
    [ContentType("text")]
    [Export(typeof(IViewTaggerProvider))]
    [TagType(typeof(ClassificationTag))]
    internal class BionicTaggerProvider : IViewTaggerProvider
    {
        [Import]
        private IClassificationTypeRegistryService _classificationRegistry = null;

        public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
        {
            return (ITagger<T>)new BionicTagger(_classificationRegistry);
        }
    }
}
