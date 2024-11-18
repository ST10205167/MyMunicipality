﻿#pragma checksum "..\..\ServiceRequest.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "168256C6B643928F626C61087B24C1F3FD4E8EA14FBB3877AB4C548563089083"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyMunicipality;
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


namespace MyMunicipality {
    
    
    /// <summary>
    /// ServiceRequest
    /// </summary>
    public partial class ServiceRequest : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\ServiceRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ErrorMessage;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\ServiceRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLocation;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\ServiceRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txtCategory;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\ServiceRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\ServiceRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AttachButton;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\ServiceRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image AttachmentPreview;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\ServiceRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AttachmentName;
        
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
            System.Uri resourceLocater = new System.Uri("/MyMunicipality;component/servicerequest.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ServiceRequest.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.ErrorMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txtLocation = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtCategory = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AttachButton = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\ServiceRequest.xaml"
            this.AttachButton.Click += new System.Windows.RoutedEventHandler(this.AttachButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AttachmentPreview = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.AttachmentName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            
            #line 69 "..\..\ServiceRequest.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SubmitRequest_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 70 "..\..\ServiceRequest.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Done_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
