int[] vs = {10,2,1,5,7,4,8,9,3,6 };
vs.SelectionSort();

for(int i = 0; i < vs.Length; i++)  
Console.WriteLine(vs[i]);

//SORTING ALGORITHM

static class ExtensionSortMethods
{
    /// <summary>
    /// Extension Linear Sort Algorithm for unmanaged value types collections.
    /// </summary>
    /// <typeparam name="T">The unmanaged type of the self referenced collection.</typeparam>
    /// <param name="collection">The self referenced collection.</param>
    public static unsafe void SelectionSort<T>(this T[] collection) 
    where T : unmanaged, IComparable<T>
    {
        var numberOfItems = collection.Length - 1; //Number of items in collection
        var typeSize = sizeof(T); // Number of bytes the type of the collection uses
        var collectionSize = typeSize * numberOfItems;
        
        fixed (T* collectionPtr = collection)
        {
            var sortedCollection = stackalloc T[collectionSize];
            *sortedCollection = *collectionPtr;

            var selected = default(int);

            for (int i = 0; i < collectionSize; i += typeSize)
            {
                selected = i;

                for (int x = i + typeSize; x < collectionSize; x += typeSize)
                {
                    if ((*(sortedCollection + x)).CompareTo((*(sortedCollection + i))) < 0)
                        selected = x;
                }

                var currentItem = sortedCollection + i;
                var selectedItem = sortedCollection + selected;
                var temp = *selectedItem;

                *selectedItem = *currentItem; 
                *currentItem = temp;
            }

            *collectionPtr = *sortedCollection;
        }
    }

    /// <summary>
    /// Extension Bubble Sort Algorithm for unmanaged value types collections.
    /// </summary>
    /// <typeparam name="T">The unmanaged type of the self referenced collection.</typeparam>
    /// <param name="collection">The self referenced collection.</param>
    public static unsafe void BubbleSort<T>(this T[] collection) where T : unmanaged
    {
        var size = collection.Length - 1; //Number of items in collection
        var unitSize = sizeof(T); // Number of bytes the type of the collection uses

        fixed(T* collectionPtr = collection)
        {
            var ptr = (byte*)collectionPtr; //Convert ptr to byte ptr

            while(true)
            {
                var isSorted = true;

                for (var i = 0; i < unitSize * size; i += unitSize) // Go variable by variable using the size of T
                {
                    var left = ptr + i; //The left item of the comparation
                    var right = ptr + i + unitSize; //The right item of the comparation

                    if (*left > *right || *right < *left)
                    {
                        var value = *left;

                        *left = *right;
                        *right = value;

                        isSorted = false;
                    }
                }

                if(isSorted) break;
            }    
        }
    }

    public static unsafe void RecursiveBubbleSort<T>(this T[] collection) where T : unmanaged
    {
        var size = collection.Length - 1; //Number of items in collection
        var unitSize = sizeof(T); // Number of bytes the type of the collection uses

        fixed (T* collectionPtr = collection)
        {
            var ptr = (byte*)collectionPtr; //Convert ptr to byte ptr

            var isSorted = true;

            for (var i = 0; i < unitSize * size; i += unitSize) // Go variable by variable using the size of T
            {
                var left = ptr + i; //The left item of the comparation
                var right = ptr + i + unitSize; //The right item of the comparation

                if (*left > *right || *right < *left)
                {
                    var value = *left;

                    *left = *right;
                    *right = value;

                    isSorted = false;
                }
            }

            if (isSorted) return;

            RecursiveBubbleSort(collection);
        }
    }

}
