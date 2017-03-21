// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
    internal enum FundType
    {
        FT_None,         // No fundamental type
        FT_I1,
        FT_I2,
        FT_I4,
        FT_U1,
        FT_U2,
        FT_U4,
        FT_LastNonLong = FT_U4,   // Last one that fits in a int.
        FT_I8,
        FT_U8,           // integral types
        FT_LastIntergral = FT_U8,
        FT_R4,
        FT_R8,           // floating types
        FT_LastNumeric = FT_R8,
        FT_Reference,    // reference type
        FT_Struct,       // structure type
        FT_Pointer,      // pointer to unmanaged memory
        FT_Var,          // polymorphic, unbounded, not yet committed
        FT_Count         // number of enumerators.
    }
}
