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

            public bool Next() 
            { 
                if(collectionReference.TryGetTarget(out Iterator[]? collection))
                {
                    if (collection != null)
                    {
                        if(index >= collection.Length - 1) return false;

                        index++;
                        Value = collection[index].Value;
                        return true;
                    }
                }

                Value = default;
                return false;
            }

            public bool Reset()
            {
                index = 0;

                if (collectionReference.TryGetTarget(out Iterator[]? collection))
                {
                    if (collection != null)
                    {
                        Value = collection[index].Value;
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
