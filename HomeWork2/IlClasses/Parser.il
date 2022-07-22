.class public abstract sealed auto ansi beforefieldinit
  IlClasses.Parser
    extends [mscorlib]System.Object
{
  .method public hidebysig static void
    ParseCalcArguments(
      string[] args,
      [out] float64& val1,
      [out] valuetype IlClasses.CalculatorOperation& operation,
      [out] float64& val2
    ) cil managed
  {
    .maxstack 5
    .locals init (
      [0] valuetype IlClasses.CalculatorOperation V_0,
      [1] float64 V_1,
      [2] bool V_2
    )
    ldarg.1
    ldarg.3
    ldarg.2
    ldc.i4.0
    dup
    stloc.0
    stind.i4
    ldloc.0
    conv.r8
    dup
    stloc.1
    stind.r8
    ldloc.1
    stind.r8

    ldarg.0
    call         bool IlClasses.Parser::IsArgLengthSupported(string[])
    brfalse.s    IL_0001
    ldarg.0
    ldc.i4.0
    ldelem.ref
    ldarg.1
    call         bool [mscorlib]System.Double::TryParse(string, float64&)
    brfalse.s    IL_0001
    ldarg.0
    ldc.i4.2
    ldelem.ref
    ldarg.3
    call         bool [mscorlib]System.Double::TryParse(string, float64&)
    ldc.i4.0
    ceq
    br.s         IL_0002
    IL_0001: 
    ldc.i4.1
    IL_0002: 
    stloc.2

    ldloc.2
    brfalse.s    IL_0003

    newobj       instance void [mscorlib]System.ArgumentException::.ctor()
    throw

    IL_0003: ldarg.2
    ldarg.0
    ldc.i4.1
    ldelem.ref
    call         valuetype IlClasses.CalculatorOperation IlClasses.Parser::ParseOperation(string)
    stind.i4

    ret
    
  }
    .method private hidebysig static bool
    IsArgLengthSupported(
      string[] args
    ) cil managed
  {
    .maxstack 8
    ldarg.0
    ldlen
    conv.i4
    ldc.i4.3
    ceq
    ret

  }
    .method private hidebysig static valuetype IlClasses.CalculatorOperation
    ParseOperation(
      string arg
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] valuetype IlClasses.CalculatorOperation V_0,
      [1] valuetype IlClasses.CalculatorOperation V_1
    )

    ldc.i4.1
    brtrue.s     IL_0001

    IL_0001:
    ldarg.0
    ldstr        "+"
    call         bool [mscorlib]System.String::op_Equality(string, string)
    brtrue.s     IL_0002
    ldarg.0
    ldstr        "-"
    call         bool [mscorlib]System.String::op_Equality(string, string)
    brtrue.s     IL_0003
    ldarg.0
    ldstr        "*"
    call         bool [mscorlib]System.String::op_Equality(string, string)
    brtrue.s     IL_0004
    ldarg.0
    ldstr        "/"
    call         bool [mscorlib]System.String::op_Equality(string, string)
    brtrue.s     IL_0005
    br.s         IL_0006

    IL_0002: 
    ldc.i4.0
    stloc.0
    br.s         IL_0007

    IL_0003: 
    ldc.i4.1
    stloc.0
    br.s         IL_0007

    IL_0004: 
    ldc.i4.2
    stloc.0
    br.s         IL_0007

    IL_0005: 
    ldc.i4.3
    stloc.0
    br.s         IL_0007

    IL_0006: 
    newobj       instance void [mscorlib]System.InvalidOperationException::.ctor()
    throw

    IL_0007: 
    ldc.i4.1
    brtrue.s     IL_0008

    IL_0008: 
    ldloc.0
    stloc.1
    br.s         IL_0009

    IL_0009: 
    ldloc.1
    ret
  }
}


