﻿#pragma checksum "..\..\..\Windows\MailWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "010CDD50CD479A9A693219CA2BE38E8AFF36EAD5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using InternetMarket.Windows;
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


namespace InternetMarket.Windows {
    
    
    /// <summary>
    /// MailWindow
    /// </summary>
    public partial class MailWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Windows\MailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox mailfrom;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Windows\MailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passfrom;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Windows\MailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox mailto;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Windows\MailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Send;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Windows\MailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddEmail;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Windows\MailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAttach;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Windows\MailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox server;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Windows\MailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox port;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Windows\MailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkbox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Windows\MailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox subject;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Windows\MailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listbox;
        
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
            System.Uri resourceLocater = new System.Uri("/InternetMarket;component/windows/mailwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\MailWindow.xaml"
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
            this.mailfrom = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.passfrom = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.mailto = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Send = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Windows\MailWindow.xaml"
            this.Send.Click += new System.Windows.RoutedEventHandler(this.Send_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddEmail = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Windows\MailWindow.xaml"
            this.AddEmail.Click += new System.Windows.RoutedEventHandler(this.AddEmail_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnAttach = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Windows\MailWindow.xaml"
            this.btnAttach.Click += new System.Windows.RoutedEventHandler(this.BtnAttach_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.server = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.port = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.checkbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 10:
            this.subject = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.listbox = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

