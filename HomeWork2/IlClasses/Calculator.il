.class public abstract sealed auto ansi beforefieldinit
  IlClasses.Calculator
    extends [mscorlib]System.Object
{

  .method public hidebysig static float64
    Calculate(
      float64 value1,
      valuetype IlClasses.CalculatorOperation operation,
      float64 value2
    ) cil managed
  {
    .maxstack 3
    .locals init (
      [0] bool V_0
    )
    
    ldarg.1
    ldc.i4.4
    ceq
    stloc.0
    ldloc.0
    brfalse.s    IL_0001

    newobj instance void [mscorlib]System.ArgumentOutOfRangeException::.ctor()
    throw
    
    IL_0001:
    ldarg.0
    ldarg.2
    ldarg.1
    
    switch (sum, substraction, multiplication, division)
    
    sum: add ret
    substraction: sub ret
    multiplication: mul ret
    division: div ret
  }
}



