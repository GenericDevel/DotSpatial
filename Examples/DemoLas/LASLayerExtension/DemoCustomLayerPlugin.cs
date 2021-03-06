using System;
using DotSpatial.Controls;
using DotSpatial.Controls.Header;

namespace LASLayer.LASLayerExtension
{
    public class LASLayerPlugin : Extension
    {
        public override void Activate()
        {
            App.HeaderControl.Add(new SimpleActionItem("Add Lidar Layer", ButtonClick));
            base.Activate();
        }

        public override void Deactivate()
        {
            App.HeaderControl.RemoveAll();
            base.Deactivate();
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            MyCustomLayer2 lay = new MyCustomLayer2();
            lay.LegendText = "My Custom Layer";
            App.Map.Layers.Add(lay);
        }
    }
}
