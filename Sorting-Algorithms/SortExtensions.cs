int[] vs = { 10, 2, 1, 5, 7, 4, 8, 9, 3, 6 };
vs.InsertionSort();

for (int i = 0; i < vs.Length; i++)
    Console.WriteLine(vs[i]);

//SORTING ALGORITHMS
static class ExtensionSortMethods
{
    /// <summary>
    /// Extension Insertion Sort Algorithm for unmanaged value types collections.
    /// </summary>
    /// <typeparam name="T">The unmanaged type of the self referenced collection.</typeparam>
    /// <param name="collection">The self referenced collection.</param>
    public static void InsertionSort<T>(this T[] collection) 
    where T : unmanaged, IComparable<T>
    {
        switch (collection.Length)
        {
            case 0: return;
            case 1: return;
            case 2:
                //Fast return point
                if (collection[0].CompareTo(collection[1]) < 0) return;

                //Tuple for swapping positions
                (collection[0], collection[1]) = (collection[1], collection[0]);
                break;
            default:
                for (var i = 0; i < collection.Length; i++)
                {
                    InsSort_Move(ref collection, i);
                }
                break;
        }
    }
    /// <summary>
    /// This is a sub-method that contains the main part of the insertion algorithm used by InsertionSort method.
    /// </summary>
    /// <typeparam name="T">The unmanaged type of the referenced collection.</typeparam>
    /// <param name="collection">The referenced collection.</param>
    /// <param name="fromIndex">This is the item index of the collection to be moved.</param>
    private static void InsSort_Move<T>(ref T[] collection, int fromIndex) 
    where T : unmanaged, IComparable<T>
    {
        //The inital value from the selected index
        var value = collection[fromIndex];

        if (fromIndex != 0) //If the selected index is not the FIRST of the collection run this.
        {
            var previousToFromIndex = fromIndex - 1; //This is the item before the selected item.

            if (collection[previousToFromIndex].CompareTo(value) <= 0) return; //If the initial value is greater than the item preceding from index return.

            for (var i = previousToFromIndex; i >= 0; i--)
            {
                if (value.CompareTo(collection[i]) < 0)
                {
                    collection[i + 1] = collection[i];
                    collection[i] = value;
                }
                else //You ended sorting the section related to fromIndex.
                {
                    break; //Ends for loop.
                }
            }
        }
        else //If the selected index is the FIRST of the collection run this.
        {
            if (collection[1].CompareTo(value) > 0) return;

            collection[0] = collection[1];
            collection[1] = value;
        }

    }

    /// <summary>
    /// Extension Bubble Sort Algorithm for unmanaged value types collections.
    /// </summary>
    /// <typeparam name="T">The unmanaged type of the self referenced collection.</typeparam>
    /// <param name="collection">The self referenced collection.</param>
    public static unsafe void BubbleSort<T>(this T[] collection) 
    where T : unmanaged, IComparable<T>
    {
        var size = collection.Length - 1; //Number of items in collection
        var unitSize = sizeof(T); // Number of bytes the type of the collection uses

        fixed (T* collectionPtr = collection)
        {
            while (true)
            {
                var isSorted = true;

                for (var i = 0; i < unitSize * size; i += unitSize) // Go variable by variable using the size of T
                {
                    var left = collectionPtr + i; //The left item of the comparation
                    var right = collectionPtr + i + unitSize; //The right item of the comparation

                    if ((*left).CompareTo(*right) > 0 || (*right).CompareTo(*left) < 0)
                    {
                        var value = *left;

                        *left = *right;
                        *right = value;

                        isSorted = false;
                    }
                }

                if (isSorted) break;
            }
        }
    }

    /// <summary>
    /// Extension Recursive Bubble Sort Algorithm for unmanaged value types collections.
    /// </summary>
    /// <typeparam name="T">The unmanaged type of the self referenced collection.</typeparam>
    /// <param name="collection">The self referenced collection.</param>
    public static unsafe void RecursiveBubbleSort<T>(this T[] collection) 
    where T : unmanaged, IComparable<T>
    {
        var size = collection.Length - 1; //Number of items in collection
        var unitSize = sizeof(T); // Number of bytes the type of the collection uses

        fixed (T* collectionPtr = collection)
        {
            var isSorted = true;

            for (var i = 0; i < unitSize * size; i += unitSize) // Go variable by variable using the size of T
            {
                var left = collectionPtr + i; //The left item of the comparation
                var right = collectionPtr + i + unitSize; //The right item of the comparation

                if ((*left).CompareTo(*right) > 0 || (*right).CompareTo(*left) < 0)
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
