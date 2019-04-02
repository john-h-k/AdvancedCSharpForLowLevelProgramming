using System;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
    public delegate int Add_dt(int a, int b);

    static void Main(string[] args)
    {
        var method = new DynamicMethod("Add", typeof(int), new[] {typeof(int), typeof(int)});
        var il = method.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Add_Ovf);
        il.Emit(OpCodes.Ret);
        var add = (Add_dt) method.CreateDelegate(typeof(Add_dt));
        Console.WriteLine("2 + 2 = {0}", add(2, 2));
    }
}