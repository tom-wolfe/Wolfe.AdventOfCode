using System.Collections;

namespace Wolfe.AdventOfCode.Helpers
{
    public class SneakyEnumerator<T> : IEnumerator<T?>
    {
        private readonly IEnumerator<T?> _source;

        private T? _current;
        private T? _peeked;
        private bool _hasPeeked;
        private bool _hasFirst;

        public SneakyEnumerator(IEnumerator<T?> source)
        {
            _source = source;
        }

        public T? Current
        {
            get
            {
                if (!_hasFirst)
                {
                    MoveNext();
                }
                return _current;
            }
        }

        object? IEnumerator.Current => Current;

        public bool MoveNext()
        {
            _hasFirst = true;

            if (_hasPeeked)
            {
                _current = _peeked;
                _peeked = default;
                _hasPeeked = false;
                return true;
            }
            else
            {
                var result = _source.MoveNext();
                _current = result ? _source.Current : default;
                return result;
            }
        }

        public T? Peek()
        {
            if (_hasPeeked) return _peeked;

            _hasPeeked = true;
            return _peeked = _source.GetNext();
        }

        public void Reset()
        {
            _current = default;
            _peeked = default;
            _hasPeeked = false;
            _hasFirst = false;
            _source.Reset();
        }

        public void Dispose()
        {
            _source.Dispose();
        }
    }
}
