// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.Text;

namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
    internal sealed class EXPRCONSTANT : EXPR
    {
        private EXPR OptionalConstructorCall;
        public EXPR GetOptionalConstructorCall() { return OptionalConstructorCall; }
        public void SetOptionalConstructorCall(EXPR value) { OptionalConstructorCall = value; }

        private CONSTVAL _val;

        private bool IsZero
        {
            get
            {
                return Val.IsZero(this.type.ConstValKind());
            }
        }
        public bool isZero() { return IsZero; }
        public CONSTVAL getVal() { return Val; }
        public void setVal(CONSTVAL newValue) { Val = newValue; }
        public CONSTVAL Val
        {
            get
            {
                return _val;
            } 
            private set
            {
                _val = value;
            }
        }

        public ulong getU64Value() { return _val.ulongVal; }
        public long getI64Value() { return I64Value; }
        public long I64Value
        {
            get
            {
                FundType ft = type.FundType();
                switch (ft)
                {
                    case FundType.FT_I8:
                    case FundType.FT_U8:
                        return _val.longVal;
                    case FundType.FT_U4:
                        return _val.uiVal;
                    case FundType.FT_I1:
                    case FundType.FT_I2:
                    case FundType.FT_I4:
                    case FundType.FT_U1:
                    case FundType.FT_U2:
                        return _val.iVal;
                    default:
                        Debug.Assert(false, "Bad fundType in getI64Value");
                        return 0;
                }
            }
        }
    }
}
