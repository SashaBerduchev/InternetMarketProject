﻿#pragma checksum "..\..\..\..\Windows\Spravochniki\Region.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DD19A1D91ED6F7A5173D9B37930C1DF5841B75AC20EE59B56B9D55EFBD6DB4F9"
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
    /// Region
    /// </summary>
    public partial class Region : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Windows\Spravochniki\Region.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox regname;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Windows\Spravochniki\Region.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox oblastname;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Windows\Spravochniki\Region.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox countrycombo;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Windows\Spravochniki\Region.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox citycombo;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Windows\Spravochniki\Region.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSet;
        
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
            System.Uri resourceLocater = new System.Uri("/InternetMarket;component/windows/spravochniki/region.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\Spravochniki\Region.xaml"
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
            this.regname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.oblastname = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.countrycombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.citycombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.btnSet = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Windows\Spravochniki\Region.xaml"
            this.btnSet.Click += new System.Windows.RoutedEventHandler(this.btnSet_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

