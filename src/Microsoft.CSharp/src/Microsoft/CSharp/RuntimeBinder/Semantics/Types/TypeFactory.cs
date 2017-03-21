// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using Microsoft.CSharp.RuntimeBinder.Syntax;

namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
    internal sealed class TypeFactory
    {
        // Aggregate
        public AggregateType CreateAggregateType(
            Name name,
            AggregateSymbol parent,
            TypeArray typeArgsThis,
            AggregateType outerType)
        {
            AggregateType type = new AggregateType();

            type.outerType = outerType;
            type.SetOwningAggregate(parent);
            type.SetTypeArgsThis(typeArgsThis);
            type.Name = name;

            type.TypeKind = TypeKind.TK_AggregateType;
            return type;
        }

        // TypeParameter
        public TypeParameterType CreateTypeParameter(TypeParameterSymbol pSymbol)
        {
            TypeParameterType type = new TypeParameterType();
            type.SetTypeParameterSymbol(pSymbol);
            type.SetUnresolved(pSymbol.parent != null && pSymbol.parent.IsAggregateSymbol() && pSymbol.parent.AsAggregateSymbol().IsUnresolved());
            type.Name = pSymbol.name;

#if CSEE
            type.typeRes = type;
            if (!type.IsUnresolved())
            {
                type.tsRes = ktsImportMax;
            }
#endif // CSEE

            Debug.Assert(pSymbol.GetTypeParameterType() == null);
            pSymbol.SetTypeParameterType(type);

            type.TypeKind = TypeKind.TK_TypeParameterType;
            return type;
        }

        // Primitives
        public VoidType CreateVoid()
        {
            VoidType type = new VoidType();
            type.TypeKind = TypeKind.TK_VoidType;
            return type;
        }

        public NullType CreateNull()
        {
            NullType type = new NullType();
            type.TypeKind = TypeKind.TK_NullType;
            return type;
        }

        public OpenTypePlaceholderType CreateUnit()
        {
            OpenTypePlaceholderType type = new OpenTypePlaceholderType();
            type.TypeKind = TypeKind.TK_OpenTypePlaceholderType;
            return type;
        }

        public BoundLambdaType CreateAnonMethod()
        {
            BoundLambdaType type = new BoundLambdaType();
            type.TypeKind = TypeKind.TK_BoundLambdaType;
            return type;
        }

        public MethodGroupType CreateMethodGroup()
        {
            MethodGroupType type = new MethodGroupType();
            type.TypeKind = TypeKind.TK_MethodGroupType;
            return type;
        }

        public ArgumentListType CreateArgList()
        {
            ArgumentListType type = new ArgumentListType();
            type.TypeKind = TypeKind.TK_ArgumentListType;
            return type;
        }

        public ErrorType CreateError(
            Name name,
            CType parent,
            AssemblyQualifiedNamespaceSymbol pParentNS,
            Name nameText,
            TypeArray typeArgs)
        {
            ErrorType e = new ErrorType();
            e.Name = name;
            e.nameText = nameText;
            e.typeArgs = typeArgs;
            e.SetTypeParent(parent);
            e.SetNSParent(pParentNS);

            e.TypeKind = TypeKind.TK_ErrorType;
            return e;
        }

        // Derived types - parent is base type
        public ArrayType CreateArray(Name name, CType pElementType, int rank)
        {
            ArrayType type = new ArrayType();

            type.Name = name;
            type.rank = rank;
            type.SetElementType(pElementType);

            type.TypeKind = TypeKind.TK_ArrayType;
            return type;
        }

        public PointerType CreatePointer(Name name, CType pReferentType)
        {
            PointerType type = new PointerType();
            type.Name = name;
            type.SetReferentType(pReferentType);

            type.TypeKind = TypeKind.TK_PointerType;
            return type;
        }

        public ParameterModifierType CreateParameterModifier(Name name, CType pParameterType)
        {
            ParameterModifierType type = new ParameterModifierType();
            type.Name = name;
            type.SetParameterType(pParameterType);

            type.TypeKind = TypeKind.TK_ParameterModifierType;
            return type;
        }

        public NullableType CreateNullable(Name name, CType pUnderlyingType, BSYMMGR symmgr, TypeManager typeManager)
        {
            NullableType type = new NullableType();
            type.Name = name;
            type.SetUnderlyingType(pUnderlyingType);
            type.symmgr = symmgr;
            type.typeManager = typeManager;

            type.TypeKind = TypeKind.TK_NullableType;
            return type;
        }
    }
}
