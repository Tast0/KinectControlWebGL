﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A8F78C8020115E83BFE9450DB4F669AD"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace KinectV2MouseControl {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider MouseSensitivity;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider PauseToClickTime;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTimeRequired;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMouseSensitivity;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider PauseThresold;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPauseThresold;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDefault;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkNoClick;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdiGrip;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdiPause;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider CursorSmoothing;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCursorSmoothing;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KinectV2MouseControl;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\MainWindow.xaml"
            ((KinectV2MouseControl.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 6 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.txtMouseSensitivity_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MouseSensitivity = ((System.Windows.Controls.Slider)(target));
            
            #line 7 "..\..\MainWindow.xaml"
            this.MouseSensitivity.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.MouseSensitivity_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PauseToClickTime = ((System.Windows.Controls.Slider)(target));
            
            #line 9 "..\..\MainWindow.xaml"
            this.PauseToClickTime.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.PauseToClickTime_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtTimeRequired = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\MainWindow.xaml"
            this.txtTimeRequired.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtTimeRequired_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtMouseSensitivity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.PauseThresold = ((System.Windows.Controls.Slider)(target));
            
            #line 13 "..\..\MainWindow.xaml"
            this.PauseThresold.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.PauseThresold_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtPauseThresold = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\MainWindow.xaml"
            this.txtPauseThresold.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtPauseThresold_KeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnDefault = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\MainWindow.xaml"
            this.btnDefault.Click += new System.Windows.RoutedEventHandler(this.btnDefault_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.chkNoClick = ((System.Windows.Controls.CheckBox)(target));
            
            #line 17 "..\..\MainWindow.xaml"
            this.chkNoClick.Checked += new System.Windows.RoutedEventHandler(this.chkNoClick_Checked);
            
            #line default
            #line hidden
            
            #line 17 "..\..\MainWindow.xaml"
            this.chkNoClick.Unchecked += new System.Windows.RoutedEventHandler(this.chkNoClick_Unchecked);
            
            #line default
            #line hidden
            return;
            case 11:
            this.rdiGrip = ((System.Windows.Controls.RadioButton)(target));
            
            #line 18 "..\..\MainWindow.xaml"
            this.rdiGrip.Checked += new System.Windows.RoutedEventHandler(this.rdiGrip_Checked);
            
            #line default
            #line hidden
            return;
            case 12:
            this.rdiPause = ((System.Windows.Controls.RadioButton)(target));
            
            #line 19 "..\..\MainWindow.xaml"
            this.rdiPause.Checked += new System.Windows.RoutedEventHandler(this.rdiPause_Checked);
            
            #line default
            #line hidden
            return;
            case 13:
            this.CursorSmoothing = ((System.Windows.Controls.Slider)(target));
            
            #line 20 "..\..\MainWindow.xaml"
            this.CursorSmoothing.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.CursorSmoothing_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            this.txtCursorSmoothing = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\MainWindow.xaml"
            this.txtCursorSmoothing.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtPauseThresold_KeyDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

