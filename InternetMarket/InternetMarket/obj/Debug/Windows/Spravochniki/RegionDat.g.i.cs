﻿#pragma checksum "..\..\..\..\Windows\Spravochniki\RegionDat.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B228358AF42AB81767B8D29954CDB814AC8DCEFC"
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
    /// RegionDat
    /// </summary>
    public partial class RegionDat : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\Windows\Spravochniki\RegionDat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegionAddbtn;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Windows\Spravochniki\RegionDat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegionLoad;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Windows\Spravochniki\RegionDat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid regoinDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/InternetMarket;component/windows/spravochniki/regiondat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\Spravochniki\RegionDat.xaml"
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
            this.RegionAddbtn = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Windows\Spravochniki\RegionDat.xaml"
            this.RegionAddbtn.Click += new System.Windows.RoutedEventHandler(this.RegionAddbtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RegionLoad = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Windows\Spravochniki\RegionDat.xaml"
            this.RegionLoad.Click += new System.Windows.RoutedEventHandler(this.RegionLoad_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.regoinDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

