using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IPChanger.SubForms
{
    public partial class frmMdiDoc : Telerik.WinControls.UI.RadForm
    {
        public frmMdiDoc()
        {
            InitializeComponent();
            this.radDock1.AutoDetectMdiChildren = true;
            this.radDock1.DockStateChanging += new DockStateChangingEventHandler(radDock1_DockStateChanging);
            this.radDock1.DockStateChanged += new DockWindowEventHandler(radDock1_DockStateChanged);
            this.radDock1.ActiveWindowChanging += new DockWindowCancelEventHandler(radDock1_ActiveWindowChanging);
            this.radDock1.ActiveWindowChanged += new DockWindowEventHandler(radDock1_ActiveWindowChanged);
            this.documentContainer1.SendToBack();
            this.radDock1.DockWindow(this.toolWindow2, DockPosition.Bottom);
        }
    }
}
