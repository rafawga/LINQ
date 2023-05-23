using System;
using System.Collections.Generic;

List<int> list = new List<int>();
list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);
list.Add(5);

Stack<string> stack = new Stack<string>();
stack.Push("1");
stack.Push("2");
stack.Push("3");


var result  = list.Skip(1).Take(5);
foreach (var i in result)
    System.Console.WriteLine(i);

// Console.WriteLine(Enumerable.Count<int>(Enumerable.Take<int>(list, 2))); // 2
// Console.WriteLine(Enumerable.Count<string>(Enumerable.Take<string>(stack, 10))); // 3


public static class Enumerable
{
    public static IEnumerable<T> Take<T>(
       this  IEnumerable<T> coll, int N)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < N && it.MoveNext(); i++)
            yield return it.Current;
    }

    public static int Count<T>(IEnumerable<T> coll)
    {
        int count = 0;

        var it = coll.GetEnumerator();
        while (it.MoveNext())
            count++;

        return count;
    }

    public static IEnumerable<T> Skip<T>(
        this IEnumerable<T> coll, int N)
    {
        int i = 0;
        var it = coll.GetEnumerator();
        while (it.MoveNext())
        {
            if(i > N)
                yield return it.Current;
            i++;
        }
    }

    public static IEnumerable<T> Append<T>(
        IEnumerable<T> coll, T obj)
    {

        var it = coll.GetEnumerator();
        foreach (var item in coll)
        {
            yield return item;
        }
        yield return obj;
    }

    public static IEnumerable<T> Prepend<T>(
        IEnumerable<T> coll, T obj)
    {
        var it = coll.GetEnumerator();
        yield return it.Current;
        while (it.MoveNext())
            yield return it.Current;
    }

    public static T[] ToArray<T>(

        IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();

        T[] vetor = new T[coll.Count()];


        int count = 0;
        while (it.MoveNext())
        {
            vetor[count] = it.Current;
            count++;
        }

        return vetor;

    }

    public static IEnumerable<T> Concat<T>(
        IEnumerable<T> frs, IEnumerable<T> scn)
    {
        var it = frs.GetEnumerator();
        var it2 = scn.GetEnumerator();

        while (it.MoveNext())
            yield return it.Current;
        while (it2.MoveNext())
            yield return it2.Current;

    }

    public static T FirstOrDefault<T>(
        IEnumerable<T> coll)
    {

        var it = coll.GetEnumerator();

        if (!it.MoveNext())
            return default(T);


        return it.Current;
    }

    public static T LastOrDefault<T>(
        IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();

        if (!it.MoveNext())
            return default(T);

        while (it.MoveNext()) ;

        return it.Current;

    }
}
