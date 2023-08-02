using System;
using System.Collections;
using System.Collections.Generic;

//ref link:https://www.youtube.com/watch?v=XQpVL9SdzCk&list=PLRwVmtr-pp07QlmssL4igw1rnrttJXerL&index=17
//ctrl+shift+space --- check target details 
// list -- are dynamic, can grow and shrink
// list -- manage array underneath
// all link function rely on IEnumerator
// IEnumerable -- the container sequence just like LINQ while IEnumerator --- can walk through the sequence of both linq and IEnumrable


class MeList<T> : IEnumerable<T>
{
    T[] items = new T[5];
    int count;
    public void Add(T item)
    {
        if (count == items.Length)
            Array.Resize(ref items, items.Length * 2);  // resize the underlying containers --- add slots by x2 of previous slot
        items[count++] = item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
            yield return items[i];      // requires yield return knowledge
        //return new MeEnumerator(this);
    }

    IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /*class MeEnumerator : IEnumerator<T>
    {
        int index = -1;
        MeList<T> theList;
        public MeEnumerator(MeList<T> theList)
        {
            this.theList = theList;
        }
        public bool MoveNext()
        {
            //index++;
            return ++index < theList.count;
        }

        public T Current
        {
            get
            {
                Console.WriteLine("Returning the Current!");
                if (index < 0 || theList.count <= index)
                    return default(T);
                return theList.items[index];
            }
        }

        public void Dispose()
        {
            Console.WriteLine("I am disposing of myself");
        }

        object System.Collections.IEnumerator.Current   // none generic current // requires knowledge in interface
        {
            get { return Current; }
        }

        public void Reset()
        {
            //throw new NotSupportedException();  // built-in yield statement
            index = -1; // force reset to sentenel value
        }
    }*/
}

static class MainClass
{
    static void Main()
    {

        //MeList<int> myPartyAges = new MeList<int>();
        //myPartyAges.Add(25);
        //myPartyAges.Add(34);
        //myPartyAges.Add(32);
        MeList<int> myPartyAges = new MeList<int>() { 25, 34, 32 };

        foreach (int i in myPartyAges)
            Console.WriteLine(i);

        /*foreach (int i in myPartyAges)
        {
            Console.WriteLine(i);
            Console.WriteLine(i);
        }
        Console.WriteLine();
        Console.WriteLine("Now doing our version...");
        IEnumerator<int> rator = myPartyAges.GetEnumerator();
        try
        {
            while (rator.MoveNext())
            {
                int i = rator.Current;
                Console.WriteLine(i);
                Console.WriteLine(i);
            }
        }
        finally
        {
            rator.Dispose(); // for database connection clean up
        }*/

    }
}