using System.Collections.Generic;
using System.Linq;

namespace Thalus.Contracts
{
    public class CompoundDTO : Dictionary<string, object>
    {
        public object this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = value;
            }
        }

        public string[] GetKeys()
        {
            List<string> st = new List<string>();

            GetKeysPrefixed(this, null, st);
            return st.ToArray();
        }
        private void GetKeysPrefixed(CompoundDTO c, string prefix, List<string> st)
        {
            foreach (var item in c)
            {
                string prf;

                if (prefix == null)
                {
                    prf = item.Key;
                }
                else
                {
                    prf = $"{prefix}.{item.Key}";
                }
                if (item.Value.GetType() == typeof(CompoundDTO))
                {


                    GetKeysPrefixed(((CompoundDTO)item.Value), prf, st);
                    continue;
                }

                st.Add(prf);
            }
        }
        new public object this[string index]
        {
            get
            {
                return GetRelative(index);
            }
            set
            {
                SetRelative(index, value);
            }
        }

        public object GetRelative(string the)
        {

            var k = the.Split('.').First();

            if (k != the)
            {
                CompoundDTO o = (CompoundDTO)base[k];
                return o.GetRelative(the.Substring(k.Length + 1));
            }

            return base[k];
        }

        public void SetRelative(string the, object value)
        {
            var k = the.Split('.').First();

            if (k != the)
            {
                var c = new CompoundDTO();
                base[k] = c;
                c.SetRelative(the.Substring(k.Length + 1), value);
                return;
            }

            base[the] = value;
        }

        public string[] GetFlatKeys()
        {
            List<string> keys = new List<string>();
            foreach (var item in this)
            {
                if (item.Value is CompoundDTO)
                {
                    keys.AddRange(((CompoundDTO)item.Value).GetFlatKeys());
                    continue;
                }

                keys.Add(item.Key);
            }

            return keys.ToArray();
        }
    }
}

