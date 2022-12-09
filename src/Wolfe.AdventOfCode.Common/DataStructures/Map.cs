namespace Wolfe.AdventOfCode.DataStructures
{
    public class Map<T>
    {
        private readonly T[,] _data;

        public Map(IEnumerable<IEnumerable<T>> data)
        {
            var map = data.Select(i => i.ToArray()).ToArray();
            _data = new T[map.Length, map[0].Length];

            for (var column = 0; column < Columns; column++)
            {
                for (var row = 0; row < Rows; row++)
                {
                    this[column, row] = map[row][column];
                }
            }
        }

        public int Rows => _data.GetLength(1);
        public int Columns => _data.GetLength(0);

        public T this[int column, int row]
        {
            get => _data[column, row];
            set => _data[column, row] = value;
        }

        public T[] GetRow(int row)
        {
            var rowData = new T[Columns];
            for (var c = 0; c < Columns; c++)
            {
                rowData[c] = _data[c, row];
            }
            return rowData;
        }

        public T[] GetColumn(int column)
        {
            var columnData = new T[Rows];
            for (var r = 0; r < Rows; r++)
            {
                columnData[r] = _data[column, r];
            }
            return columnData;
        }

        public IEnumerable<(int, int, T)> Flatten()
        {
            for (var column = 0; column < Columns; column++)
            {
                for (var row = 0; row < Rows; row++)
                {
                    yield return (column, row, this[column, row]);
                }
            }
        }
    }
}
