﻿#pragma checksum "..\..\Window7.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A90715D60A46700FC0AC557080CAE3726DF9B033680AC5F8BF1ED5D981D18EEC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ChatAppClient;
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


namespace ChatAppClient {
    
    
    /// <summary>
    /// Window7
    /// </summary>
    public partial class Window7 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\Window7.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button directMsgBut;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Window7.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ChatRoomNameTextBlock;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Window7.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox ChatBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Window7.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox userBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Window7.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MessageTextBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Window7.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DMButton;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Window7.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DMButton2;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Window7.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DMButton3;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Window7.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DMButton4;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Window7.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DMButton5;
        
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
            System.Uri resourceLocater = new System.Uri("/ChatAppClient;component/window7.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window7.xaml"
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
            this.directMsgBut = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Window7.xaml"
            this.directMsgBut.Click += new System.Windows.RoutedEventHandler(this.DirectMessageButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ChatRoomNameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            
            #line 18 "..\..\Window7.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LeaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ChatBox = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 5:
            this.userBox = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 6:
            this.MessageTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 41 "..\..\Window7.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SendMessageButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 42 "..\..\Window7.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AttachFileButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.DMButton = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\Window7.xaml"
            this.DMButton.Click += new System.Windows.RoutedEventHandler(this.DMButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.DMButton2 = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\Window7.xaml"
            this.DMButton2.Click += new System.Windows.RoutedEventHandler(this.DMButton2_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.DMButton3 = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\Window7.xaml"
            this.DMButton3.Click += new System.Windows.RoutedEventHandler(this.DMButton3_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.DMButton4 = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\Window7.xaml"
            this.DMButton4.Click += new System.Windows.RoutedEventHandler(this.DMButton4_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.DMButton5 = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\Window7.xaml"
            this.DMButton5.Click += new System.Windows.RoutedEventHandler(this.DMButton5_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

