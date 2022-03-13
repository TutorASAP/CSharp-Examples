namespace LinearSearch
{
    public sealed partial class LinearCollection<T>
    {
        public sealed class Iterator
        {
            private readonly WeakReference<Iterator[]?> collectionReference;
            private int index;
             
            public T? Value { get; set; }
            public int Index { get => index; }
            public WeakReference<Iterator[]?> Reference { get => collectionReference; }

            public Iterator(Iterator[] collection, T? value, int index = 0)
            {
                collectionReference = new WeakReference<Iterator[]?>(collection);

                this.index = index;
                Value = value; 
            }

            public T?[]? ToArray()
            {
                if (collectionReference == null) return default;

                if(collectionReference.TryGetTarget(out var collection))
                {
                    var returnArray = new T?[collection.Length];

                    for (int i = 0; i < returnArray.Length; i++)
                    {
                        returnArray[i] = collection[i].Value;
                    }

                    return returnArray;
                }

                return default;
            }

            public bool Next() 
            {
                if (collectionReference.TryGetTarget(out Iterator[]? collection))
                {
                    if (collection == null) return false;
                    if (index >= collection.Length - 1) return false;

                    index++;
                    Value = collection[index].Value;

                    return true;
                }

                return false;
            }

            public bool Reset()
            {
                index = 0;

                if (collectionReference.TryGetTarget(out Iterator[]? collection))
                {
                    if (collection == null) return false;

                    Value = collection[index].Value;
                    return true;
                }

                return false;
            }
        }
    }
}
