namespace DemoCustomLayer
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorBox1 = new DotSpatial.Symbology.Forms.ColorBox();
            this.rampSlider1 = new DotSpatial.Symbology.Forms.RampSlider();
            this.colorLever1 = new DotSpatial.Symbology.Forms.ColorLever();
            this.SuspendLayout();
            // 
            // colorBox1
            // 
            this.colorBox1.LabelText = "Color:";
            this.colorBox1.Location = new System.Drawing.Point(384, 36);
            this.colorBox1.Name = "colorBox1";
            this.colorBox1.Size = new System.Drawing.Size(370, 21);
            this.colorBox1.TabIndex = 0;
            this.colorBox1.Value = System.Drawing.Color.Empty;
            // 
            // rampSlider1
            // 
            this.rampSlider1.ColorButton = null;
            this.rampSlider1.FlipRamp = false;
            this.rampSlider1.FlipText = false;
            this.rampSlider1.InvertRamp = false;
            this.rampSlider1.Location = new System.Drawing.Point(741, 261);
            this.rampSlider1.Maximum = 1D;
            this.rampSlider1.MaximumColor = System.Drawing.Color.Green;
            this.rampSlider1.Minimum = 0D;
            this.rampSlider1.MinimumColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rampSlider1.Name = "rampSlider1";
            this.rampSlider1.NumberFormat = "#.00";
            this.rampSlider1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.rampSlider1.RampRadius = 10F;
            this.rampSlider1.RampText = null;
            this.rampSlider1.RampTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rampSlider1.RampTextBehindRamp = false;
            this.rampSlider1.RampTextColor = System.Drawing.Color.Black;
            this.rampSlider1.RampTextFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rampSlider1.ShowMaximum = true;
            this.rampSlider1.ShowMinimum = true;
            this.rampSlider1.ShowTicks = false;
            this.rampSlider1.ShowValue = true;
            this.rampSlider1.Size = new System.Drawing.Size(151, 23);
            this.rampSlider1.SliderColor = System.Drawing.Color.Blue;
            this.rampSlider1.SliderRadius = 4F;
            this.rampSlider1.TabIndex = 1;
            this.rampSlider1.Text = "rampSlider1";
            this.rampSlider1.TickColor = System.Drawing.Color.DarkGray;
            this.rampSlider1.TickSpacing = 5F;
            this.rampSlider1.Value = 1D;
            // 
            // colorLever1
            // 
            this.colorLever1.Angle = 0D;
            this.colorLever1.BarLength = 5;
            this.colorLever1.BarWidth = 5;
            this.colorLever1.BorderWidth = 5;
            this.colorLever1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(229)))), ((int)(((byte)(183)))));
            this.colorLever1.Flip = false;
            this.colorLever1.KnobColor = System.Drawing.Color.SteelBlue;
            this.colorLever1.KnobRadius = 7;
            this.colorLever1.Location = new System.Drawing.Point(168, 13);
            this.colorLever1.Name = "colorLever1";
            this.colorLever1.Opacity = 1F;
            this.colorLever1.Size = new System.Drawing.Size(75, 23);
            this.colorLever1.TabIndex = 3;
            this.colorLever1.Text = "colorLever1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 530);
            this.Controls.Add(this.colorLever1);
            this.Controls.Add(this.rampSlider1);
            this.Controls.Add(this.colorBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private DotSpatial.Symbology.Forms.ColorBox colorBox1;
        private DotSpatial.Symbology.Forms.RampSlider rampSlider1;
        private DotSpatial.Symbology.Forms.ColorLever colorLever1;
    }
}