using System.Text;

namespace Ezfx.Csv.ItemWizards
{
    public class EncodingComboboxItem
    {
        public EncodingInfo Value { get; set; }
        public string Text
        {
            get { return Value.DisplayName; }
        }

        public int CodePage
        {
            get { return Value.CodePage; }
        }

        public override string ToString()
        {
            return Value.DisplayName;
        }
    }
}
