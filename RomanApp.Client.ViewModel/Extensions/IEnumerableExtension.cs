using System.Collections;
using System.Text;

namespace RomanApp.Client.ViewModel.Extensions
{
    public static class IEnumerableExtension
    {
        public static string Enumerate(this IEnumerable enumerable, string andLabel)
        {
            string retval = null;

            if (enumerable != null)
            {
                StringBuilder sb = new StringBuilder();
                IEnumerator en = enumerable.GetEnumerator();
                if (en.MoveNext())
                {
                    string last = en.Current.ToString();
                    while (en.MoveNext())
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(", ");
                        }
                        sb.Append(last);
                        last = en.Current.ToString();
                    }

                    if (sb.Length > 0)
                    {
                        sb.Append($" {andLabel.ToLower()} {last}");
                    }
                    else
                    {
                        sb.Append(last);
                    }
                }

                retval = sb.ToString();
            }

            return retval;
        }
    }
}
