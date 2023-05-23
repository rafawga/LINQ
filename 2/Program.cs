using System;

var x = Potencia(3);
var resultado = x(2);

System.Console.WriteLine(resultado);


FuncaoMatematica Potencia(double y)
{
    double funcaoX(double x)
    {
        return Math.Pow(x, y);
    }
    return funcaoX;
}


public delegate double FuncaoMatematica(double x);





