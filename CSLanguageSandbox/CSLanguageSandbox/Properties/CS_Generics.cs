using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLanguageSandbox
{
    // Naming convention: call the types according to their roles: T[role]
    class GenericDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _dictionary;

        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);

        }
    }

    class GenericNullable<T> where T : struct
    {
        private object _value;

        public GenericNullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return (_value != null); }
        }

        public T GetValueOrDefault()
        {
            if(HasValue)
            {
                return (T)_value;
            }
            else
            {
                return default(T);
            }
        }
    }
}
