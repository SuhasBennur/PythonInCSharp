using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
class demo
{
    const string program = @"
def sum(a, b):
    return a+b
";

    public static void Main(string[] args)
    {
        ScriptEngine engine = Python.CreateEngine();

        ScriptSource source = engine.CreateScriptSourceFromString(program);
        ScriptScope scope = engine.CreateScope();

        source.Execute(scope);

        // get the function from the python side (remember functions are
        // first class objects in python, you can refer to them like they 
        // are variables)
        var sumFunc = scope.GetVariable("sum");

        var result = sumFunc(2, 2);

        Console.WriteLine("result: {0}", result);
    }
}