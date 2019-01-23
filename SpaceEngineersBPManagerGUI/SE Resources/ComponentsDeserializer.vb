Option Strict Off
Option Explicit On

Imports System.Xml.Serialization

Public Class ComponentsDeserializer
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),
     System.SerializableAttribute(),
     System.Diagnostics.DebuggerStepThroughAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Partial Public Class Definitions

        Private componentsField() As DefinitionsComponent

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Component", IsNullable:=False)>
        Public Property Components() As DefinitionsComponent()
            Get
                Return Me.componentsField
            End Get
            Set
                Me.componentsField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),
    System.SerializableAttribute(),
    System.Diagnostics.DebuggerStepThroughAttribute(),
    System.ComponentModel.DesignerCategoryAttribute("code"),
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class DefinitionsComponent
        Private idField As DefinitionsComponentID
        Private displayNameField As String
        Private iconField As String
        Private sizeField As DefinitionsComponentSize
        Private massField As Integer
        Private volumeField As Integer
        Private modelField As String
        Private physicalMaterialField As String
        Private maxIntegrityField As Integer
        Private dropProbabilityField As Double
        Private healthField As Integer

        Public Property Id() As DefinitionsComponentID
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

        Public Property Size() As DefinitionsComponentSize
            Get
                Return Me.sizeField
            End Get
            Set
                Me.sizeField = Value
            End Set
        End Property

        Public Property Mass() As Integer
            Get
                Return Me.massField
            End Get
            Set
                Me.massField = Value
            End Set
        End Property

        Public Property Volume() As Integer
            Get
                Return Me.volumeField
            End Get
            Set
                Me.volumeField = Value
            End Set
        End Property

        Public Property Model() As String
            Get
                Return Me.modelField
            End Get
            Set
                Me.modelField = Value
            End Set
        End Property

        Public Property PhysicalMaterial() As String
            Get
                Return Me.physicalMaterialField
            End Get
            Set
                Me.physicalMaterialField = Value
            End Set
        End Property

        Public Property MaxIntegrity() As Integer
            Get
                Return Me.maxIntegrityField
            End Get
            Set
                Me.maxIntegrityField = Value
            End Set
        End Property

        Public Property DropProbability() As Double
            Get
                Return Me.dropProbabilityField
            End Get
            Set
                Me.dropProbabilityField = Value
            End Set
        End Property

        Public Property Health() As Integer
            Get
                Return Me.healthField
            End Get
            Set
                Me.healthField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),
    System.SerializableAttribute(),
    System.Diagnostics.DebuggerStepThroughAttribute(),
    System.ComponentModel.DesignerCategoryAttribute("code"),
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class DefinitionsComponentID
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

    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),
    System.SerializableAttribute(),
    System.Diagnostics.DebuggerStepThroughAttribute(),
    System.ComponentModel.DesignerCategoryAttribute("code"),
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class DefinitionsComponentSize
        Private xField As Double
        Private yField As Double
        Private zField As Double

        Public Property X() As Double
            Get
                Return Me.xField
            End Get
            Set
                Me.xField = Value
            End Set
        End Property

        Public Property Y() As Double
            Get
                Return Me.yField
            End Get
            Set
                Me.yField = Value
            End Set
        End Property

        Public Property Z() As Double
            Get
                Return Me.zField
            End Get
            Set
                Me.zField = Value
            End Set
        End Property
    End Class
End Class
