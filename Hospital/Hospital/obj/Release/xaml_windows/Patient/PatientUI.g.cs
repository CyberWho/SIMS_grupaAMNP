﻿#pragma checksum "..\..\..\..\xaml_windows\Patient\PatientUI.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7908DE23A53F0B4C31C00B82B8BA8660037BCFCD03394A64F8A1C7F10433FA5F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Hospital.xaml_windows.Patient;
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


namespace Hospital.xaml_windows.Patient {
    
    
    /// <summary>
    /// PatientUI
    /// </summary>
    public partial class PatientUI : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\xaml_windows\Patient\PatientUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem PocetnaStranica;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\xaml_windows\Patient\PatientUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MojProfil;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\xaml_windows\Patient\PatientUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MojiPregledi;
        
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
            System.Uri resourceLocater = new System.Uri("/Hospital;component/xaml_windows/patient/patientui.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\xaml_windows\Patient\PatientUI.xaml"
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
            this.PocetnaStranica = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\..\..\xaml_windows\Patient\PatientUI.xaml"
            this.PocetnaStranica.Click += new System.Windows.RoutedEventHandler(this.PocetnaStranica_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MojProfil = ((System.Windows.Controls.MenuItem)(target));
            
            #line 16 "..\..\..\..\xaml_windows\Patient\PatientUI.xaml"
            this.MojProfil.Click += new System.Windows.RoutedEventHandler(this.MojProfil_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MojiPregledi = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\..\..\xaml_windows\Patient\PatientUI.xaml"
            this.MojiPregledi.Click += new System.Windows.RoutedEventHandler(this.MojiPregledi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
