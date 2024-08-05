using MultipleSolutions.Models;
using System.Collections;

namespace MultipleSolutions.Implementations
{

    public class PersonIterator(Dictionary<Person, int> dictionary) : IEnumerable<KeyValuePair<Person, int>>
    {
        private readonly Dictionary<Person, int> _dictionary = dictionary;

        public IEnumerator<KeyValuePair<Person, int>> GetEnumerator()
        {
            return new PersonDictionaryEnumerator(_dictionary);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class PersonDictionaryEnumerator : IEnumerator<KeyValuePair<Person, int>>
        {
            private readonly Dictionary<Person, int> _dictionary;
            private IEnumerator<KeyValuePair<Person, int>> _enumerator;

            public PersonDictionaryEnumerator(Dictionary<Person, int> dictionary)
            {
                _dictionary = dictionary;
                _enumerator = _dictionary.GetEnumerator();
            }

            public KeyValuePair<Person, int> Current => _enumerator.Current;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _enumerator.Dispose();
            }

            public bool MoveNext()
            {
                return _enumerator.MoveNext();
            }

            public void Reset()
            {
                _enumerator.Reset();
            }
        }
    }

}
