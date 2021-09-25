// Copyright (c) DotSpatial Team. All rights reserved.
// Licensed under the MIT license. See License.txt file in the project root for full license information.

using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;
using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace LayerSymbolDemo
{
    /// <summary>
    /// This is the main window of the DemoMap program.
    /// </summary>
    public partial class MainForm : Form
    {
        [Export("Shell", typeof(ContainerControl))]
        private static ContainerControl shell;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            if (DesignMode) return;
            shell = this;
            //appManager.LoadExtensions();
        }

        private void addDataToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            string Filename = @"d:\temp\430104\block.shp";

            IMapLayer lay=appManager.Map.AddLayer(Filename);
            lay.ShowProperties += Lay_ShowProperties; ;

        }

        private void Lay_ShowProperties(object sender, System.ComponentModel.HandledEventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            appManager.Map = this.map1;
            appManager.Legend = this.legend1;
            
        }
    }
}