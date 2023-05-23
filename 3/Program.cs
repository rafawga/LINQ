    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    IEnumerable<int> num = get();
    var num4 = num.Where(n => n % 4 == 0);
    var collatz = num.Select(x => x.Collatz(3));
    var maiorQMil = collatz.Count(n => n > 1000);
    var menorQCinco = collatz.Count(n => n < 5);

    // System.Console.WriteLine("Divisiveis por 4");

    // foreach (var item in num4){
    //     System.Console.WriteLine(item);
    // }

    //System.Console.WriteLine("\nMaior que mil");
    //System.Console.WriteLine(maiorQMil);
    //System.Console.WriteLine("\nMenor que 5");
    //System.Console.WriteLine(menorQCinco);

    
    List<Pessoa> listaPessoa = new List<Pessoa>();
    listaPessoa.Add(new Pessoa("Rafael", 19));
    listaPessoa.Add(new Pessoa("João", 21));
    listaPessoa.Add(new Pessoa("Felipe", 59));
    listaPessoa.Add(new Pessoa("Duda", 2));

    var maioresDeIdade = listaPessoa.Where(x => x.idade > 18).Select(x => x.name);
    //System.Console.WriteLine(maioresDeIdade);

    var skipWhileTest = num.SkipWhile(n => n % 2 == 0);

    //  foreach (var item in skipWhileTest){
    //     System.Console.WriteLine(item);
    // }

    var takeWhileTest = num.TakeWhile(n => n % 2 == 0);

    // foreach (var item in skipWhileTest){
    //     System.Console.WriteLine(item);
    // }

IEnumerable<int> get()
{
    for (int i = 0; i < 1000; i++)
        yield return i + 1;
}

public static class Enumerable
{
    public static int Collatz(this int num, int qnt)
    {
        for (int i = 0; i < qnt; i++)
        {
            if (num % 2 == 0)
                num /= 2;
            else num = num * 3 + 1;
        }
        return num;
    }

    public static IEnumerable<T> Where<T>(
        this IEnumerable<T> coll,
        Func<T, bool> condition
    )
    {
        foreach (var el in coll)
        {
            if (condition(el))
                yield return el;
        }
    }

    public static IEnumerable<T> SkipWhile<T>(
        this IEnumerable<T> coll,
        Func<T, bool> condition
    )
    {
        foreach (var el in coll)
        {
            if (!condition(el))
            yield return el;
        }
    }

    public static IEnumerable<T> TakeWhile<T>(
        this IEnumerable<T> coll,
        Func<T, bool> condition
    )
    {
        foreach (var el in coll)
        {
            if (condition(el))
            yield return el;
        }
    }

    public static IEnumerable<R> Select<T, R>(
        this IEnumerable<T> coll,
        Func<T, R> selector
    )
    {
        foreach (var el in coll)
            yield return selector(el);
    }

    public static IEnumerable<T> Take<T>(
        this IEnumerable<T> coll, int N)
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
        foreach (var el in coll)
        {
            if(i++ < N)
                continue;
            
            yield return el;
        }
    }
    
    public static IEnumerable<T> Append<T>(
        IEnumerable<T> coll, T obj)
    {
        foreach (var el in coll)
            yield return el;
        yield return obj;
    }
    
    public static IEnumerable<T> Prepend<T>(
        IEnumerable<T> coll, T obj)
    {
        yield return obj;
        foreach (var el in coll)
            yield return el;
    }
    
    public static T[] ToArray<T>(
        IEnumerable<T> coll)
    {
        int index = 0;
        T[] array = new T[Count(coll)];

        var it = coll.GetEnumerator();
        while(it.MoveNext())
        {
            array[index] = it.Current;
            index++;
        }

        return array;   
    }
    
    public static IEnumerable<T> Concat<T>(
        IEnumerable<T> frs, IEnumerable<T> scn)
    {
        foreach (var el in frs)
            yield return el;
        
        foreach (var el in scn)
            yield return el;
    }

    public static T FirstOrDefault<T>(
        IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        if (it.MoveNext())
            return it.Current;
        return default(T);
    }

    public static T LastOrDefault<T>(
        IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        if (!it.MoveNext())
            return default(T);

        while (it.MoveNext());
        return it.Current;
    }
}

public class Pessoa{
    public string name;
    public int idade;

    public Pessoa(string name, int idade){
        this.name = name;
        this.idade = idade;

    }
}