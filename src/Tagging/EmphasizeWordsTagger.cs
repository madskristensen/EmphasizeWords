using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;

namespace EmphasizeWords.Tagging
{
    internal class EmphasizeWordsTagger : ITagger<ClassificationTag>
    {
        private static readonly Regex _words = new(@"(_|\b|#|-)([\p{L}]+)\b", RegexOptions.Compiled);
        private static readonly Regex _capitalWords = new(@"(?<!^)(?=[A-Z])", RegexOptions.Compiled);
        private readonly double _percent;
        private readonly bool _isEnabled;
        private readonly IClassificationType _classification;

        public EmphasizeWordsTagger(IClassificationTypeRegistryService classificationRegistry)
        {
            _classification = classificationRegistry.GetClassificationType(Bold.Name);
            _percent = General.Instance.PercentageOfWord;
            _isEnabled = General.Instance.Enabled;
        }

        public IEnumerable<ITagSpan<ClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            if (!_isEnabled)
                yield break;

            foreach (SnapshotSpan span in spans)
            {
                if (span.IsEmpty) continue;

                string text = span.GetText();
                MatchCollection matches = _words.Matches(text);

                foreach (Match match in matches)
                {
                    string[] parts = _capitalWords.Split(match.Groups[2].Value);
                    int position = 0;

                    foreach (string part in parts)
                    {
                        int length = (int)Math.Max(part.Length * _percent, 1);
                        int start = span.Start.Position + match.Groups[2].Index + position;

                        yield return new TagSpan<ClassificationTag>(
                                    new SnapshotSpan(span.Snapshot, start, length),
                                    new ClassificationTag(_classification));

                        position += part.Length;
                    }                 
                }
            }
        }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged
        {
            add { }
            remove { }
        }
    }
}