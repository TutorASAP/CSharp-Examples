namespace LinearSearch
{
    public sealed partial class LinearCollection<T>
    {
        private Iterator[]? collection = null;

        public T? this[int index]
        {
            get => index < collection?.Length ? collection[index].Value : default;
            set { if (index < collection?.Length) collection[index].Value = value; }
        }

        public LinearCollection(T?[] collection)
        {
            Iterator[] returnArray = new Iterator[collection.Length];

            for (int i = 0; i < returnArray.Length; i++)
            {
                returnArray[i] = new Iterator(returnArray, collection[i], i);
            }

            this.collection = returnArray;
        }

        public void Add(T? value)
        {
            if (collection == null) return;

            var newCollection = new Iterator[collection.Length + 1];

            for(int i = 0; i < collection.Length; i++)
            {
                newCollection[i] = collection[i];
            }

            newCollection[collection.Length] = new Iterator(newCollection, value, collection.Length);

            collection = newCollection;
        }

        public void Remove(T? value)
        {
            if(collection == null) return;

            var newCollection = Array.Empty<LinearCollection<T>.Iterator>();

            foreach (var item in collection)
            {
                if (Equals(item.Value, value)) continue;
                newCollection = newCollection.Append(item).ToArray();
            }

            collection = newCollection;
        }

        public Iterator? Find(T? value)
        {
            if(collection == null) return default;

            var counter = 0;

            foreach(var item in collection)
            {
                if(Equals(item.Value, value))
                {
                    return new Iterator(collection, value, counter);
                }

                counter++;
            }

            return default;
        }
    }
}
