public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        /*
            Plan:
            number = number to multiply
            length = total count of numbers to return

            Using recursion?

            if the length is not 0, call MultiplesOf(number, length - 1), then add number * length to the returned list
            if the length is 0, return a new list

            Using a loop?

            create array with a size of length
            for loop starting at 1 and ending at length
            set the item at index-1 to be index * number
            return array
        */

        // recursion method (it works):
        //if (length == 0) return [];
        //
        //double[] arr = [.. MultiplesOf(number, length - 1), number * length];

        // loop method(s) (they all work):
        double[] arr = new double[length];

        //for (int i = 0; i < length; i++) arr[i] = number * (i+1);
        //for (int i = 1; i <= length; i++) arr[i-1] = number * i;
        for (int i = 0; i < length;) arr[i] = number * ++i;

        // I should really stop trying to code-golf everything
        return arr;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        /*
            plan:
            data = list of numbers to shift
            amout = number of spaces to shift by

            loop?

            save the last item to tmp
            index starts as the size of the list
            while index is not 0, save the item at index to tmp and replace it with the item in tmp
            remove amount from index
            if index is less than 0, add the length of the list to it

            Nope
            // int size = data.Count;
            // int tmp = data[size];
            // int i = size;
            //
            // while (i != 0) {
            //     int j = i;
            //     i -= amount;
            //     if (i < 0) i += size;
            //     (data[j], data[i]) = (data[i], data[j]);
            // }
        
            ...

            fancy math?

            create new list same size as original
            for every item in the original list, place it into the new list offset by the amount
            if the offset results in a number below 0, add the size of the list to the offset
            replace the original list with the new one

            Nope
            // for (int i = size - 1; i > 0; i--) {
            //     int offset = i - amount;
            //     if (offset < 0) offset += size;
            //     data2[offset] = data[i];
            // }
            //
            // data = data2;
        
            ...

            fancy methods?

            set size to be the size of the list - 1
            create a new list
            set offset to be amount, and add or subtract size from it if it is less than 0 or greater than size
            insert the original list items into the new list starting from the offset
            while the new list is smaller than the original list, add items to it starting from the front

            Nope
            // int size = data.Count - 1;
            // List<int> data2 = [];
            // int offs = amount;
            //
            // if (offs < 0) offs += size;
            // else if (offs > size) offs -= size;
            //
            // data2.InsertRange(offs, data);
            //
            // for (int i = 0; data2.Count < data.Count; i++) data2.Add(data[i]); 
        
            ...

            Recursion?

            First call: data, amount
            save the size of the list
            save and remove the last item in the list
            if length of data id 0, return a new list with the saved item being inserted where index = amount
            if length of data is greater than 0, recurse with: data - last item, and amount being the same
            add the saved item to the list where index = amount

            no no no bad
            // if (data.Count == 0) return;
            // int size = data.Count;
            // int lastItem = data[size-1];
            // data.Remove(size);
            // RotateListRight(data, amount);
            // data[(data.Count + amount) % size] = lastItem;

            ...

            idk what to call it at this point, just "the clone method"?

            get the size of data
            make a copy of the list
            starting from 0, copy items from the copy at index to the original at the same index + amount, mod size

            Okay that worked yay
            This probably would have been easier if I had done it earlier in the day
        */

        int size = data.Count;

        List<int> copy = data[..size];

        for (int i = 0; i < size; i++) data[(amount + i) % size] = copy[i];
    }
}