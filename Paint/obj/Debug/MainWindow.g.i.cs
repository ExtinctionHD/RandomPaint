#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1C32B74746DB9656D01BE3894B7253733CE0BE28"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Paint;
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


namespace Paint
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 15 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grMain;

#line default
#line hidden


#line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grShapeButtons;

#line default
#line hidden


#line 29 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rectangle;

#line default
#line hidden


#line 38 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton triangleR;

#line default
#line hidden


#line 42 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton triangleI;

#line default
#line hidden


#line 46 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton randomShape;

#line default
#line hidden


#line 52 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Paint;component/mainwindow.xaml", System.UriKind.Relative);

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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 11 "..\..\MainWindow.xaml"
                    ((Paint.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);

#line default
#line hidden

#line 12 "..\..\MainWindow.xaml"
                    ((Paint.MainWindow)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);

#line default
#line hidden

#line 13 "..\..\MainWindow.xaml"
                    ((Paint.MainWindow)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);

#line default
#line hidden
                    return;
                case 2:
                    this.grMain = ((System.Windows.Controls.Grid)(target));
                    return;
                case 3:
                    this.grShapeButtons = ((System.Windows.Controls.Grid)(target));
                    return;
                case 4:
                    this.rectangle = ((System.Windows.Controls.RadioButton)(target));
                    return;
                case 5:
                    this.ellipce = ((System.Windows.Controls.RadioButton)(target));
                    return;
                case 6:
                    this.triangleR = ((System.Windows.Controls.RadioButton)(target));
                    return;
                case 7:
                    this.triangleI = ((System.Windows.Controls.RadioButton)(target));
                    return;
                case 8:
                    this.randomShape = ((System.Windows.Controls.RadioButton)(target));
                    return;
                case 9:
                    this.canvas = ((System.Windows.Controls.Canvas)(target));

#line 55 "..\..\MainWindow.xaml"
                    this.canvas.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.canvas_MouseLeftButtonDown);

#line default
#line hidden

#line 56 "..\..\MainWindow.xaml"
                    this.canvas.MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.canvas_MouseRightButtonDown);

#line default
#line hidden

#line 57 "..\..\MainWindow.xaml"
                    this.canvas.MouseMove += new System.Windows.Input.MouseEventHandler(this.canvas_MouseMove);

#line default
#line hidden

#line 58 "..\..\MainWindow.xaml"
                    this.canvas.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.canvas_MouseButtonUp);

#line default
#line hidden

#line 59 "..\..\MainWindow.xaml"
                    this.canvas.MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.canvas_MouseButtonUp);

#line default
#line hidden

#line 60 "..\..\MainWindow.xaml"
                    this.canvas.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.canvas_MouseWheel);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.RadioButton ellipse;
    }
}

