using System;
using DotSpatial.Controls;
using DotSpatial.Controls.Header;

namespace DemoCustomLayer.DemoCustomLayerExtension
{
    public class LasLayerPlugin : Extension
    {
        public override void Activate()
        {
            App.HeaderControl.Add(new SimpleActionItem("Add Las Layer", ButtonClick));
            base.Activate();
        }

        public override void Deactivate()
        {
            App.HeaderControl.RemoveAll();
            base.Deactivate();
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            DotSpatial.Plugins.LiDAR.LiDarLayer lay = new DotSpatial.Plugins.LiDAR.LiDarLayer();
            lay.LegendText = "Las Layer";
            App.Map.Layers.Add(lay);
            //System.Diagnostics.Debug.WriteLine("OKOK");
        }
    }
}
