﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FlatTabControl1 = New SpaceEngineersBPManagerGUI.FlatTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ListBox4 = New System.Windows.Forms.ListBox()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.OpemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsStatusBarMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsStatusBarBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenModManagerStatusBarBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenBPManagerStatusBarBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpStatusBarBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateStatusBarBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlatContextMenuStrip1 = New SpaceEngineersBPManagerGUI.FlatContextMenuStrip()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsContextMenuBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModManagerContextMenuBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlueprintManagerContextMenuBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpContextMenuBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateContextMenuBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlatTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.FlatContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(2, 2)
        Me.FlowLayoutPanel1.MinimumSize = New System.Drawing.Size(624, 489)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(624, 489)
        Me.FlowLayoutPanel1.TabIndex = 35
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.White
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 17
        Me.ListBox1.Location = New System.Drawing.Point(2, 2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.ListBox1.Size = New System.Drawing.Size(601, 412)
        Me.ListBox1.TabIndex = 36
        '
        'FlatTabControl1
        '
        Me.FlatTabControl1.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.FlatTabControl1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.FlatTabControl1.Controls.Add(Me.TabPage1)
        Me.FlatTabControl1.Controls.Add(Me.TabPage2)
        Me.FlatTabControl1.Controls.Add(Me.TabPage3)
        Me.FlatTabControl1.Controls.Add(Me.TabPage4)
        Me.FlatTabControl1.Controls.Add(Me.TabPage5)
        Me.FlatTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlatTabControl1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.FlatTabControl1.ItemSize = New System.Drawing.Size(120, 40)
        Me.FlatTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlatTabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.FlatTabControl1.Name = "FlatTabControl1"
        Me.FlatTabControl1.SelectedIndex = 0
        Me.FlatTabControl1.Size = New System.Drawing.Size(613, 464)
        Me.FlatTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.FlatTabControl1.TabIndex = 39
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.FlowLayoutPanel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 44)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Size = New System.Drawing.Size(605, 416)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Block Overlay"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.ListBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 44)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Size = New System.Drawing.Size(605, 416)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Block Type List"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.ListBox2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 44)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage3.Size = New System.Drawing.Size(605, 416)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Component List"
        '
        'ListBox2
        '
        Me.ListBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ListBox2.ForeColor = System.Drawing.Color.White
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 17
        Me.ListBox2.Location = New System.Drawing.Point(2, 2)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.ListBox2.Size = New System.Drawing.Size(601, 412)
        Me.ListBox2.TabIndex = 39
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.ListBox4)
        Me.TabPage4.Controls.Add(Me.ListBox3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 44)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage4.Size = New System.Drawing.Size(605, 416)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Materials List"
        '
        'ListBox4
        '
        Me.ListBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ListBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListBox4.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ListBox4.ForeColor = System.Drawing.Color.White
        Me.ListBox4.FormattingEnabled = True
        Me.ListBox4.ItemHeight = 17
        Me.ListBox4.Location = New System.Drawing.Point(2, 176)
        Me.ListBox4.Name = "ListBox4"
        Me.ListBox4.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.ListBox4.Size = New System.Drawing.Size(601, 238)
        Me.ListBox4.TabIndex = 42
        '
        'ListBox3
        '
        Me.ListBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ListBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ListBox3.ForeColor = System.Drawing.Color.White
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.ItemHeight = 17
        Me.ListBox3.Location = New System.Drawing.Point(2, 2)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.ListBox3.Size = New System.Drawing.Size(601, 412)
        Me.ListBox3.TabIndex = 40
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.PictureBox1)
        Me.TabPage5.Location = New System.Drawing.Point(4, 44)
        Me.TabPage5.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage5.Size = New System.Drawing.Size(605, 416)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Blueprint Image"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(601, 412)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 444)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(613, 20)
        Me.Panel1.TabIndex = 40
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = CType(resources.GetObject("StatusStrip1.BackgroundImage"), System.Drawing.Image)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, -2)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 9, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(613, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpemToolStripMenuItem, Me.ResetToolStripMenuItem1, Me.SettingsStatusBarMenu, Me.ToolsStatusBarBtn})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 20)
        Me.ToolStripDropDownButton1.Text = "Tools"
        '
        'OpemToolStripMenuItem
        '
        Me.OpemToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.OpemToolStripMenuItem.BackgroundImage = CType(resources.GetObject("OpemToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.OpemToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.OpemToolStripMenuItem.Name = "OpemToolStripMenuItem"
        Me.OpemToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpemToolStripMenuItem.Text = "Open"
        '
        'ResetToolStripMenuItem1
        '
        Me.ResetToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ResetToolStripMenuItem1.BackgroundImage = CType(resources.GetObject("ResetToolStripMenuItem1.BackgroundImage"), System.Drawing.Image)
        Me.ResetToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Control
        Me.ResetToolStripMenuItem1.Name = "ResetToolStripMenuItem1"
        Me.ResetToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.ResetToolStripMenuItem1.Text = "Reset"
        '
        'SettingsStatusBarMenu
        '
        Me.SettingsStatusBarMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.SettingsStatusBarMenu.BackgroundImage = CType(resources.GetObject("SettingsStatusBarMenu.BackgroundImage"), System.Drawing.Image)
        Me.SettingsStatusBarMenu.ForeColor = System.Drawing.SystemColors.Control
        Me.SettingsStatusBarMenu.Name = "SettingsStatusBarMenu"
        Me.SettingsStatusBarMenu.Size = New System.Drawing.Size(180, 22)
        Me.SettingsStatusBarMenu.Text = "Settings"
        '
        'ToolsStatusBarBtn
        '
        Me.ToolsStatusBarBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolsStatusBarBtn.BackgroundImage = CType(resources.GetObject("ToolsStatusBarBtn.BackgroundImage"), System.Drawing.Image)
        Me.ToolsStatusBarBtn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenModManagerStatusBarBtn, Me.OpenBPManagerStatusBarBtn, Me.HelpStatusBarBtn, Me.UpdateStatusBarBtn})
        Me.ToolsStatusBarBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.ToolsStatusBarBtn.Name = "ToolsStatusBarBtn"
        Me.ToolsStatusBarBtn.Size = New System.Drawing.Size(180, 22)
        Me.ToolsStatusBarBtn.Text = "Tools"
        '
        'OpenModManagerStatusBarBtn
        '
        Me.OpenModManagerStatusBarBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.OpenModManagerStatusBarBtn.BackgroundImage = CType(resources.GetObject("OpenModManagerStatusBarBtn.BackgroundImage"), System.Drawing.Image)
        Me.OpenModManagerStatusBarBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.OpenModManagerStatusBarBtn.Name = "OpenModManagerStatusBarBtn"
        Me.OpenModManagerStatusBarBtn.Size = New System.Drawing.Size(173, 22)
        Me.OpenModManagerStatusBarBtn.Text = "Mod Manager"
        '
        'OpenBPManagerStatusBarBtn
        '
        Me.OpenBPManagerStatusBarBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.OpenBPManagerStatusBarBtn.BackgroundImage = CType(resources.GetObject("OpenBPManagerStatusBarBtn.BackgroundImage"), System.Drawing.Image)
        Me.OpenBPManagerStatusBarBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.OpenBPManagerStatusBarBtn.Name = "OpenBPManagerStatusBarBtn"
        Me.OpenBPManagerStatusBarBtn.Size = New System.Drawing.Size(173, 22)
        Me.OpenBPManagerStatusBarBtn.Text = "Blueprint Manager"
        '
        'HelpStatusBarBtn
        '
        Me.HelpStatusBarBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.HelpStatusBarBtn.BackgroundImage = CType(resources.GetObject("HelpStatusBarBtn.BackgroundImage"), System.Drawing.Image)
        Me.HelpStatusBarBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.HelpStatusBarBtn.Name = "HelpStatusBarBtn"
        Me.HelpStatusBarBtn.Size = New System.Drawing.Size(173, 22)
        Me.HelpStatusBarBtn.Text = "Help"
        '
        'UpdateStatusBarBtn
        '
        Me.UpdateStatusBarBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.UpdateStatusBarBtn.BackgroundImage = CType(resources.GetObject("UpdateStatusBarBtn.BackgroundImage"), System.Drawing.Image)
        Me.UpdateStatusBarBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.UpdateStatusBarBtn.Name = "UpdateStatusBarBtn"
        Me.UpdateStatusBarBtn.Size = New System.Drawing.Size(173, 22)
        Me.UpdateStatusBarBtn.Text = "Check For Updates"
        '
        'FlatContextMenuStrip1
        '
        Me.FlatContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatContextMenuStrip1.ForeColor = System.Drawing.Color.White
        Me.FlatContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ResetToolStripMenuItem, Me.SettingsContextMenuItem, Me.ToolsContextMenuBtn})
        Me.FlatContextMenuStrip1.Name = "FlatContextMenuStrip1"
        Me.FlatContextMenuStrip1.ShowImageMargin = False
        Me.FlatContextMenuStrip1.Size = New System.Drawing.Size(92, 92)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(91, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'ResetToolStripMenuItem
        '
        Me.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem"
        Me.ResetToolStripMenuItem.Size = New System.Drawing.Size(91, 22)
        Me.ResetToolStripMenuItem.Text = "Reset"
        '
        'SettingsContextMenuItem
        '
        Me.SettingsContextMenuItem.Name = "SettingsContextMenuItem"
        Me.SettingsContextMenuItem.Size = New System.Drawing.Size(91, 22)
        Me.SettingsContextMenuItem.Text = "Settings"
        '
        'ToolsContextMenuBtn
        '
        Me.ToolsContextMenuBtn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModManagerContextMenuBtn, Me.BlueprintManagerContextMenuBtn, Me.HelpContextMenuBtn, Me.UpdateContextMenuBtn})
        Me.ToolsContextMenuBtn.Name = "ToolsContextMenuBtn"
        Me.ToolsContextMenuBtn.Size = New System.Drawing.Size(91, 22)
        Me.ToolsContextMenuBtn.Text = "Tools"
        '
        'ModManagerContextMenuBtn
        '
        Me.ModManagerContextMenuBtn.ForeColor = System.Drawing.Color.White
        Me.ModManagerContextMenuBtn.Name = "ModManagerContextMenuBtn"
        Me.ModManagerContextMenuBtn.Size = New System.Drawing.Size(171, 22)
        Me.ModManagerContextMenuBtn.Text = "Mod Manager"
        '
        'BlueprintManagerContextMenuBtn
        '
        Me.BlueprintManagerContextMenuBtn.ForeColor = System.Drawing.Color.White
        Me.BlueprintManagerContextMenuBtn.Name = "BlueprintManagerContextMenuBtn"
        Me.BlueprintManagerContextMenuBtn.Size = New System.Drawing.Size(171, 22)
        Me.BlueprintManagerContextMenuBtn.Text = "Blueprint Manager"
        '
        'HelpContextMenuBtn
        '
        Me.HelpContextMenuBtn.ForeColor = System.Drawing.Color.White
        Me.HelpContextMenuBtn.Name = "HelpContextMenuBtn"
        Me.HelpContextMenuBtn.Size = New System.Drawing.Size(171, 22)
        Me.HelpContextMenuBtn.Text = "Help"
        '
        'UpdateContextMenuBtn
        '
        Me.UpdateContextMenuBtn.ForeColor = System.Drawing.Color.White
        Me.UpdateContextMenuBtn.Name = "UpdateContextMenuBtn"
        Me.UpdateContextMenuBtn.Size = New System.Drawing.Size(171, 22)
        Me.UpdateContextMenuBtn.Text = "Check For Updates"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(613, 464)
        Me.ContextMenuStrip = Me.FlatContextMenuStrip1
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FlatTabControl1)
        Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(629, 503)
        Me.Name = "Main"
        Me.Text = "Space Engineers Blueprint Manager"
        Me.FlatTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.FlatContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents FlatTabControl1 As FlatTabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents ListBox3 As ListBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FlatContextMenuStrip1 As FlatContextMenuStrip
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListBox4 As ListBox
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents OpemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ResetToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SettingsStatusBarMenu As ToolStripMenuItem
    Friend WithEvents SettingsContextMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsContextMenuBtn As ToolStripMenuItem
    Friend WithEvents ToolsStatusBarBtn As ToolStripMenuItem
    Friend WithEvents OpenModManagerStatusBarBtn As ToolStripMenuItem
    Friend WithEvents OpenBPManagerStatusBarBtn As ToolStripMenuItem
    Friend WithEvents HelpStatusBarBtn As ToolStripMenuItem
    Friend WithEvents UpdateStatusBarBtn As ToolStripMenuItem
    Friend WithEvents ModManagerContextMenuBtn As ToolStripMenuItem
    Friend WithEvents BlueprintManagerContextMenuBtn As ToolStripMenuItem
    Friend WithEvents HelpContextMenuBtn As ToolStripMenuItem
    Friend WithEvents UpdateContextMenuBtn As ToolStripMenuItem
End Class
