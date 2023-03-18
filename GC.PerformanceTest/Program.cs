using GC.PerformanceTest.validation;
using System.Diagnostics;

var sw = new Stopwatch();
var gcGen0 = System.GC.CollectionCount(0);
var gcGen1 = System.GC.CollectionCount(1);
var gcGen2 = System.GC.CollectionCount(2);
//var func = CpfValidationV1.ValidCpf;
//var func = CpfValidationV2.ValidCpf;
var func = CpfValidationV3.ValidCpf;

sw.Start();

for (var i = 0; i < 1_500_000; i++)
{
    if (!func("762.142.857-02"))
        throw new Exception("Error");

    if (func("762.142.857-01"))
        throw new Exception("Error");
}

sw.Stop();

Console.WriteLine($"Total time: {sw.ElapsedMilliseconds}ms");
Console.WriteLine($"GC Gen 0: {System.GC.CollectionCount(0) - gcGen0}");
Console.WriteLine($"GC Gen 1: {System.GC.CollectionCount(1) - gcGen1}");
Console.WriteLine($"GC Gen 2: {System.GC.CollectionCount(2) - gcGen2}");