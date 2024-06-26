namespace Unique_In_Order
{
    internal class Program
    {
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            if (iterable.Count() == 0)
            {
                return iterable;
            }
            else
            {
                List<T> resultList = new List<T>() { iterable.First() };

                foreach (var item in iterable.Skip(1))
                {
                    if (!item.Equals(resultList.Last()))
                    {
                        resultList.Add(item);
                    }
                }

                return resultList;
            }
        }

        public static IEnumerable<T> UniqueInOrder2<T>(IEnumerable<T> iterable)
        {
            T previous = default(T);
            bool isFirst = true;

            foreach (var item in iterable)
            {
                if (isFirst || !EqualityComparer<T>.Default.Equals(item, previous))
                {
                    yield return item;
                    isFirst = false;
                }
                previous = item;
            }
        }


        static void Main(string[] args)
        {
            foreach (char c in UniqueInOrder2(""))
            {
                Console.WriteLine(c);
            }
        }
    }
}