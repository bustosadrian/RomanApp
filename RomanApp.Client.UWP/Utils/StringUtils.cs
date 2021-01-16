using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanApp.Client.UWP.Utils
{
    public static class StringUtils
    {

        public static string Enumerate(IEnumerable enumerable)
        {
            string retval = null;

            if(enumerable != null)
            {
                StringBuilder sb = new StringBuilder();
                IEnumerator en = enumerable.GetEnumerator();
                if (en.MoveNext())
                {
                    string last = en.Current.ToString();
                    while (en.MoveNext())
                    {
                        if(sb.Length > 0)
                        {
                            sb.Append(", ");
                        }
                        sb.Append(last);
                        last = en.Current.ToString();
                    }

                    if(sb.Length > 0)
                    {
                        sb.Append(" and " + last);
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
