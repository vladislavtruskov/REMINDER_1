﻿#pragma checksum "..\..\AddRemind.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7C528AF28BD297F0737CF9504BEA4CE8C5FF6215"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Reminder;
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


namespace Reminder {
    
    
    /// <summary>
    /// AddRemind
    /// </summary>
    public partial class AddRemind : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\AddRemind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox remind_title;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\AddRemind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox remind_discription;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\AddRemind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_picker;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\AddRemind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox hour_value;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\AddRemind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox minute_value;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\AddRemind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_ok;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\AddRemind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cancel;
        
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
            System.Uri resourceLocater = new System.Uri("/Reminder;component/addremind.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddRemind.xaml"
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
            this.remind_title = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.remind_discription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.date_picker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.hour_value = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.minute_value = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btn_ok = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\AddRemind.xaml"
            this.btn_ok.Click += new System.Windows.RoutedEventHandler(this.btn_ok_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_cancel = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\AddRemind.xaml"
            this.btn_cancel.Click += new System.Windows.RoutedEventHandler(this.btn_cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

