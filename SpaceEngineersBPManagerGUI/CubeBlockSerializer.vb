Option Strict Off
Option Explicit On

Imports System.Xml.Serialization

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class Definitions
    Private cubeBlocksField() As DefinitionsDefinition
    <System.Xml.Serialization.XmlArrayItemAttribute("Definition", IsNullable:=False)>
    Public Property CubeBlocks() As DefinitionsDefinition()
        Get
            Return Me.cubeBlocksField
        End Get
        Set
            Me.cubeBlocksField = Value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class DefinitionsDefinition
    Private idField As DefinitionsDefinitionID
    Private displayNameField As String
    Private iconField As String
    Private cubeSizeField As String
    Private componentsField() As DefinitionsDefinitionComponent
    Private blockPairNameField As String
    Private buildTimeSecondsField As Integer

    Public Property Id() As DefinitionsDefinitionID
        Get
            Return Me.idField
        End Get
        Set
            Me.idField = Value
        End Set
    End Property

    Public Property DisplayName() As String
        Get
            Return Me.displayNameField
        End Get
        Set
            Me.displayNameField = Value
        End Set
    End Property

    Public Property Icon() As String
        Get
            Return Me.iconField
        End Get
        Set
            Me.iconField = Value
        End Set
    End Property

    Public Property CubeSize() As String
        Get
            Return Me.cubeSizeField
        End Get
        Set
            Me.cubeSizeField = Value
        End Set
    End Property

    <System.Xml.Serialization.XmlArrayItemAttribute("Component", IsNullable:=False)>
    Public Property Components() As DefinitionsDefinitionComponent()
        Get
            Return Me.componentsField
        End Get
        Set
            Me.componentsField = Value
        End Set
    End Property

    Public Property BlockPairName() As String
        Get
            Return Me.blockPairNameField
        End Get
        Set
            Me.blockPairNameField = Value
        End Set
    End Property

    Public Property BuildTimeSeconds() As Integer
        Get
            Return Me.buildTimeSecondsField
        End Get
        Set
            Me.buildTimeSecondsField = Value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class DefinitionsDefinitionID
    Private typeIdField As String
    Private subtypeIdField As String

    Public Property TypeId() As String
        Get
            Return Me.typeIdField
        End Get
        Set
            Me.typeIdField = Value
        End Set
    End Property

    Public Property SubtypeId() As String
        Get
            Return Me.subtypeIdField
        End Get
        Set
            Me.subtypeIdField = Value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class DefinitionsDefinitionComponent
    Private subtypeField As String
    Private countField As Integer
    Private countFieldSpecified As Boolean

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Subtype() As String
        Get
            Return Me.subtypeField
        End Get
        Set
            Me.subtypeField = Value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Count() As Integer
        Get
            Return Me.countField
        End Get
        Set
            Me.countField = Value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property CountSpecified() As Boolean
        Get
            Return Me.countFieldSpecified
        End Get
        Set
            Me.countFieldSpecified = Value
        End Set
    End Property
End Class