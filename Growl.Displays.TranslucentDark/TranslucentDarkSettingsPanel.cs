using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;
using Growl.Displays.Wpf;
using Growl.DisplayStyle;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Drawing;
namespace Growl.Displays.TranslucentDark
{
    public class TranslucentDarkSettingsPanel : WpfSettingsPanelBase
    {
        #region Designer generated

        private System.Windows.Forms.ComboBox horizontalPlacementBox;
        private System.Windows.Forms.Label horizontalPlacementLabel;
        private System.Windows.Forms.ComboBox verticalPlacementBox;
        private System.Windows.Forms.Label verticalPlacementLabel;
        private NumericUpDown widthBox;
        private CheckBox fixedWidthBox;
        private PictureBox textColorBox;
        private CheckBox showTextBox;
        private Label screenLabel;
        private ComboBox screenBox;
        private GroupBox placementBox;
        private GroupBox appearanceBox;
        private CheckBox showIconBox;
        private NumericUpDown iconSizeBox;
        private Label iconSizeLabel;
        private Label textColorLabel;
        private Label containerColorLabel;
        private PictureBox containerColorBox;
        private NumericUpDown containerAlphaBox;
        private GroupBox behaviorBox;
        private CheckBox PauseOnFullscreenBox;
        private ToolTip toolTip;
        private IContainer components;
        private System.Windows.Forms.ColorDialog colorDialog;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.horizontalPlacementBox = new System.Windows.Forms.ComboBox();
            this.horizontalPlacementLabel = new System.Windows.Forms.Label();
            this.verticalPlacementBox = new System.Windows.Forms.ComboBox();
            this.verticalPlacementLabel = new System.Windows.Forms.Label();
            this.widthBox = new System.Windows.Forms.NumericUpDown();
            this.fixedWidthBox = new System.Windows.Forms.CheckBox();
            this.textColorBox = new System.Windows.Forms.PictureBox();
            this.showTextBox = new System.Windows.Forms.CheckBox();
            this.screenLabel = new System.Windows.Forms.Label();
            this.screenBox = new System.Windows.Forms.ComboBox();
            this.placementBox = new System.Windows.Forms.GroupBox();
            this.appearanceBox = new System.Windows.Forms.GroupBox();
            this.containerAlphaBox = new System.Windows.Forms.NumericUpDown();
            this.containerColorBox = new System.Windows.Forms.PictureBox();
            this.containerColorLabel = new System.Windows.Forms.Label();
            this.textColorLabel = new System.Windows.Forms.Label();
            this.iconSizeLabel = new System.Windows.Forms.Label();
            this.showIconBox = new System.Windows.Forms.CheckBox();
            this.iconSizeBox = new System.Windows.Forms.NumericUpDown();
            this.behaviorBox = new System.Windows.Forms.GroupBox();
            this.PauseOnFullscreenBox = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColorBox)).BeginInit();
            this.placementBox.SuspendLayout();
            this.appearanceBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.containerAlphaBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSizeBox)).BeginInit();
            this.behaviorBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // horizontalPlacementBox
            // 
            this.horizontalPlacementBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.horizontalPlacementBox.FormattingEnabled = true;
            this.horizontalPlacementBox.Location = new System.Drawing.Point(125, 19);
            this.horizontalPlacementBox.Name = "horizontalPlacementBox";
            this.horizontalPlacementBox.Size = new System.Drawing.Size(98, 21);
            this.horizontalPlacementBox.TabIndex = 3;
            this.horizontalPlacementBox.SelectedIndexChanged += new System.EventHandler(this.HorizontalPlacementBoxSelectedIndexChanged);
            // 
            // horizontalPlacementLabel
            // 
            this.horizontalPlacementLabel.AutoSize = true;
            this.horizontalPlacementLabel.Location = new System.Drawing.Point(9, 22);
            this.horizontalPlacementLabel.Name = "horizontalPlacementLabel";
            this.horizontalPlacementLabel.Size = new System.Drawing.Size(106, 13);
            this.horizontalPlacementLabel.TabIndex = 3;
            this.horizontalPlacementLabel.Text = "Horizontal placement";
            // 
            // verticalPlacementBox
            // 
            this.verticalPlacementBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.verticalPlacementBox.FormattingEnabled = true;
            this.verticalPlacementBox.Location = new System.Drawing.Point(125, 47);
            this.verticalPlacementBox.Name = "verticalPlacementBox";
            this.verticalPlacementBox.Size = new System.Drawing.Size(98, 21);
            this.verticalPlacementBox.TabIndex = 4;
            this.verticalPlacementBox.SelectedIndexChanged += new System.EventHandler(this.VerticalPlacementBoxSelectedIndexChanged);
            // 
            // verticalPlacementLabel
            // 
            this.verticalPlacementLabel.AutoSize = true;
            this.verticalPlacementLabel.Location = new System.Drawing.Point(9, 50);
            this.verticalPlacementLabel.Name = "verticalPlacementLabel";
            this.verticalPlacementLabel.Size = new System.Drawing.Size(94, 13);
            this.verticalPlacementLabel.TabIndex = 5;
            this.verticalPlacementLabel.Text = "Vertical placement";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(125, 74);
            this.widthBox.Maximum = new decimal(new int[] {
            10240,
            0,
            0,
            0});
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(58, 20);
            this.widthBox.TabIndex = 6;
            this.widthBox.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.widthBox.ValueChanged += new System.EventHandler(this.WidthBoxValueChanged);
            // 
            // fixedWidthBox
            // 
            this.fixedWidthBox.AutoSize = true;
            this.fixedWidthBox.Checked = true;
            this.fixedWidthBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fixedWidthBox.Location = new System.Drawing.Point(12, 75);
            this.fixedWidthBox.Name = "fixedWidthBox";
            this.fixedWidthBox.Size = new System.Drawing.Size(79, 17);
            this.fixedWidthBox.TabIndex = 5;
            this.fixedWidthBox.Text = "Fixed width";
            this.fixedWidthBox.UseVisualStyleBackColor = true;
            this.fixedWidthBox.CheckedChanged += new System.EventHandler(this.FixedWidthBoxCheckedChanged);
            // 
            // textColorBox
            // 
            this.textColorBox.BackColor = System.Drawing.Color.Transparent;
            this.textColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textColorBox.Location = new System.Drawing.Point(117, 127);
            this.textColorBox.Name = "textColorBox";
            this.textColorBox.Size = new System.Drawing.Size(34, 21);
            this.textColorBox.TabIndex = 11;
            this.textColorBox.TabStop = false;
            this.textColorBox.Click += new System.EventHandler(this.textColorBox_Click);
            this.textColorBox.Paint += new System.Windows.Forms.PaintEventHandler(this.textColorBox_Paint);
            // 
            // showTextBox
            // 
            this.showTextBox.AutoSize = true;
            this.showTextBox.Location = new System.Drawing.Point(9, 102);
            this.showTextBox.Name = "showTextBox";
            this.showTextBox.Size = new System.Drawing.Size(73, 17);
            this.showTextBox.TabIndex = 2;
            this.showTextBox.Text = "Show text";
            this.showTextBox.UseVisualStyleBackColor = true;
            this.showTextBox.CheckedChanged += new System.EventHandler(this.ShowTextBoxCheckedChanged);
            // 
            // screenLabel
            // 
            this.screenLabel.AutoSize = true;
            this.screenLabel.Location = new System.Drawing.Point(228, 224);
            this.screenLabel.Name = "screenLabel";
            this.screenLabel.Size = new System.Drawing.Size(41, 13);
            this.screenLabel.TabIndex = 15;
            this.screenLabel.Text = "Screen";
            this.screenLabel.Visible = false;
            // 
            // screenBox
            // 
            this.screenBox.DisplayMember = "DeviceName";
            this.screenBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screenBox.FormattingEnabled = true;
            this.screenBox.Location = new System.Drawing.Point(343, 221);
            this.screenBox.Name = "screenBox";
            this.screenBox.Size = new System.Drawing.Size(98, 21);
            this.screenBox.TabIndex = 16;
            this.screenBox.Visible = false;
            this.screenBox.SelectedIndexChanged += new System.EventHandler(this.ScreenBoxSelectedIndexChanged);
            // 
            // placementBox
            // 
            this.placementBox.Controls.Add(this.widthBox);
            this.placementBox.Controls.Add(this.horizontalPlacementBox);
            this.placementBox.Controls.Add(this.horizontalPlacementLabel);
            this.placementBox.Controls.Add(this.verticalPlacementBox);
            this.placementBox.Controls.Add(this.verticalPlacementLabel);
            this.placementBox.Controls.Add(this.fixedWidthBox);
            this.placementBox.Location = new System.Drawing.Point(218, 3);
            this.placementBox.Name = "placementBox";
            this.placementBox.Size = new System.Drawing.Size(232, 103);
            this.placementBox.TabIndex = 17;
            this.placementBox.TabStop = false;
            this.placementBox.Text = "Placement";
            // 
            // appearanceBox
            // 
            this.appearanceBox.Controls.Add(this.containerAlphaBox);
            this.appearanceBox.Controls.Add(this.containerColorBox);
            this.appearanceBox.Controls.Add(this.containerColorLabel);
            this.appearanceBox.Controls.Add(this.textColorLabel);
            this.appearanceBox.Controls.Add(this.iconSizeLabel);
            this.appearanceBox.Controls.Add(this.showIconBox);
            this.appearanceBox.Controls.Add(this.iconSizeBox);
            this.appearanceBox.Controls.Add(this.showTextBox);
            this.appearanceBox.Controls.Add(this.textColorBox);
            this.appearanceBox.Location = new System.Drawing.Point(3, 3);
            this.appearanceBox.Name = "appearanceBox";
            this.appearanceBox.Size = new System.Drawing.Size(208, 155);
            this.appearanceBox.TabIndex = 18;
            this.appearanceBox.TabStop = false;
            this.appearanceBox.Text = "Appearance";
            // 
            // containerAlphaBox
            // 
            this.containerAlphaBox.Location = new System.Drawing.Point(158, 19);
            this.containerAlphaBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.containerAlphaBox.Name = "containerAlphaBox";
            this.containerAlphaBox.Size = new System.Drawing.Size(44, 20);
            this.containerAlphaBox.TabIndex = 20;
            this.containerAlphaBox.ValueChanged += new System.EventHandler(this.containerAlphaBox_ValueChanged);
            // 
            // containerColorBox
            // 
            this.containerColorBox.BackColor = System.Drawing.Color.Transparent;
            this.containerColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.containerColorBox.Location = new System.Drawing.Point(117, 19);
            this.containerColorBox.Name = "containerColorBox";
            this.containerColorBox.Size = new System.Drawing.Size(34, 21);
            this.containerColorBox.TabIndex = 17;
            this.containerColorBox.TabStop = false;
            this.containerColorBox.Click += new System.EventHandler(this.containerColorBox_Click);
            this.containerColorBox.Paint += new System.Windows.Forms.PaintEventHandler(this.containerColorBox_Paint);
            // 
            // containerColorLabel
            // 
            this.containerColorLabel.AutoSize = true;
            this.containerColorLabel.Location = new System.Drawing.Point(6, 21);
            this.containerColorLabel.Name = "containerColorLabel";
            this.containerColorLabel.Size = new System.Drawing.Size(78, 13);
            this.containerColorLabel.TabIndex = 19;
            this.containerColorLabel.Text = "Container color";
            // 
            // textColorLabel
            // 
            this.textColorLabel.AutoSize = true;
            this.textColorLabel.Location = new System.Drawing.Point(26, 130);
            this.textColorLabel.Name = "textColorLabel";
            this.textColorLabel.Size = new System.Drawing.Size(54, 13);
            this.textColorLabel.TabIndex = 16;
            this.textColorLabel.Text = "Text color";
            // 
            // iconSizeLabel
            // 
            this.iconSizeLabel.AutoSize = true;
            this.iconSizeLabel.Location = new System.Drawing.Point(26, 76);
            this.iconSizeLabel.Name = "iconSizeLabel";
            this.iconSizeLabel.Size = new System.Drawing.Size(49, 13);
            this.iconSizeLabel.TabIndex = 15;
            this.iconSizeLabel.Text = "Icon size";
            // 
            // showIconBox
            // 
            this.showIconBox.AutoSize = true;
            this.showIconBox.Location = new System.Drawing.Point(9, 48);
            this.showIconBox.Name = "showIconBox";
            this.showIconBox.Size = new System.Drawing.Size(76, 17);
            this.showIconBox.TabIndex = 0;
            this.showIconBox.Text = "Show icon";
            this.showIconBox.UseVisualStyleBackColor = true;
            this.showIconBox.CheckedChanged += new System.EventHandler(this.ShowIconBoxCheckedChanged);
            // 
            // iconSizeBox
            // 
            this.iconSizeBox.Location = new System.Drawing.Point(117, 74);
            this.iconSizeBox.Maximum = new decimal(new int[] {
            10240,
            0,
            0,
            0});
            this.iconSizeBox.Name = "iconSizeBox";
            this.iconSizeBox.Size = new System.Drawing.Size(58, 20);
            this.iconSizeBox.TabIndex = 1;
            this.iconSizeBox.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.iconSizeBox.ValueChanged += new System.EventHandler(this.IconSizeBoxValueChanged);
            // 
            // behaviorBox
            // 
            this.behaviorBox.Controls.Add(this.PauseOnFullscreenBox);
            this.behaviorBox.Location = new System.Drawing.Point(218, 113);
            this.behaviorBox.Name = "behaviorBox";
            this.behaviorBox.Size = new System.Drawing.Size(232, 45);
            this.behaviorBox.TabIndex = 19;
            this.behaviorBox.TabStop = false;
            this.behaviorBox.Text = "Behavior";
            // 
            // PauseOnFullscreenBox
            // 
            this.PauseOnFullscreenBox.AutoSize = true;
            this.PauseOnFullscreenBox.Location = new System.Drawing.Point(7, 20);
            this.PauseOnFullscreenBox.Name = "PauseOnFullscreenBox";
            this.PauseOnFullscreenBox.Size = new System.Drawing.Size(119, 17);
            this.PauseOnFullscreenBox.TabIndex = 0;
            this.PauseOnFullscreenBox.Text = "Pause on fullscreen";
            this.toolTip.SetToolTip(this.PauseOnFullscreenBox, "When enabled, no notifications will be popped up when another application is runn" +
                    "ing fullscreen. The notifications will be queued until the other application is " +
                    "not running fullscreen anymore.");
            this.PauseOnFullscreenBox.UseVisualStyleBackColor = true;
            this.PauseOnFullscreenBox.CheckedChanged += new System.EventHandler(this.PauseOnFullscreenBox_CheckedChanged);
            // 
            // TranslucentDarkSettingsPanel
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.behaviorBox);
            this.Controls.Add(this.screenLabel);
            this.Controls.Add(this.appearanceBox);
            this.Controls.Add(this.placementBox);
            this.Controls.Add(this.screenBox);
            this.Name = "TranslucentDarkSettingsPanel";
            this.Size = new System.Drawing.Size(450, 242);
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textColorBox)).EndInit();
            this.placementBox.ResumeLayout(false);
            this.placementBox.PerformLayout();
            this.appearanceBox.ResumeLayout(false);
            this.appearanceBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.containerAlphaBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSizeBox)).EndInit();
            this.behaviorBox.ResumeLayout(false);
            this.behaviorBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public TranslucentDarkSettings Settings
        {
            get { return SettingsWrapper as TranslucentDarkSettings; }
        }

        public TranslucentDarkSettingsPanel()
        {
            if (!DesignMode)
                InitializeComponent();
            horizontalPlacementBox.Items.AddRange(Enum.GetValues(typeof(System.Windows.HorizontalAlignment)).OfType<object>().ToArray());
            verticalPlacementBox.Items.AddRange(Enum.GetValues(typeof(System.Windows.VerticalAlignment)).OfType<object>().ToArray());
            screenBox.Items.AddRange(Screen.AllScreens);
            if (screenBox.Items.Count == 0)
                screenBox.Items.Add("Default");
            LoadSettings();
        }

        protected override SettingsWrapper CreateSettings(IDictionary<string, object> settings)
        {
            return new TranslucentDarkSettings(settings);
        }

        private void LoadSettings()
        {
            textColorBox.BackColor = Color.FromArgb(Settings.TextColor.A, Settings.TextColor.R, Settings.TextColor.G, Settings.TextColor.B);
            //notificationColorBox.BackColor = Color.FromArgb(Settings.ContainerColor.A, Settings.ContainerColor.R, Settings.ContainerColor.G, Settings.ContainerColor.B);
            SetSelectedValue(horizontalPlacementBox, Settings.HorizontalPlacement);
            SetSelectedValue(verticalPlacementBox, Settings.VerticalPlacement);
            fixedWidthBox.Checked = Settings.FixedWidth >= 0.0;
            if (fixedWidthBox.Checked)
                widthBox.Value = (decimal)Settings.FixedWidth;
            else
                widthBox.Value = 256;
            iconSizeBox.Value = (decimal)Settings.IconSize;
            showTextBox.Checked = Settings.ShowText;
            showIconBox.Checked = Settings.ShowIcon;

            int screenIndex = Settings.Screen;
            if (screenIndex < 0 || screenIndex >= screenBox.Items.Count)
                screenIndex = 0;
            screenBox.SelectedIndex = screenIndex;

            //textAlphaBox.Value = Settings.TextColor.A;
            containerAlphaBox.Value = Settings.ContainerColor.A;
            //notificationAlphaBox.Value = Settings.NotificationColor.A;

            PauseOnFullscreenBox.Checked = Settings.PauseOnFullscreen;
        }

        private static void SetSelectedValue<T>(ComboBox box, T value)
        {
            int selectedIndex = -1;
            for (int i = 0; i < box.Items.Count; i++)
            {
                object itemObj = box.Items[i];
                if (itemObj == null)
                    continue;
                T item = (T)itemObj;
                if (EqualityComparer<T>.Default.Equals(value, item))
                {
                    selectedIndex = i;
                    break;
                }
            }
            box.SelectedIndex = selectedIndex;
        }

        private void HorizontalPlacementBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.HorizontalPlacement = (System.Windows.HorizontalAlignment)horizontalPlacementBox.SelectedItem;
        }

        private void VerticalPlacementBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.VerticalPlacement = (System.Windows.VerticalAlignment)verticalPlacementBox.SelectedItem;
        }

        private void FixedWidthBoxCheckedChanged(object sender, EventArgs e)
        {
            UpdateFixedWidth();
        }

        private void WidthBoxValueChanged(object sender, EventArgs e)
        {
            UpdateFixedWidth();
        }

        private void UpdateFixedWidth()
        {
            Settings.FixedWidth = !fixedWidthBox.Checked ? -1.0 : (double)widthBox.Value;
            widthBox.Enabled = fixedWidthBox.Checked;
        }

        private void IconSizeBoxValueChanged(object sender, EventArgs e)
        {
            Settings.IconSize = (double)iconSizeBox.Value;
        }

        private void ShowIconBoxCheckedChanged(object sender, EventArgs e)
        {
            Settings.ShowIcon = showIconBox.Checked;
            iconSizeBox.Enabled = showIconBox.Checked;
        }

        private void ShowTextBoxCheckedChanged(object sender, EventArgs e)
        {
            Settings.ShowText = showTextBox.Checked;
        }

        private void ScreenBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Screen = screenBox.SelectedIndex;
        }

        private void textColorBox_Paint(object sender, PaintEventArgs e)
        {
            PaintColorBox(e.Graphics, Settings.TextColor);
        }

        /*private void notificationColorBox_Paint(object sender, PaintEventArgs e)
        {
            PaintColorBox(e.Graphics, Settings.NotificationColor);
        }*/

        private void containerColorBox_Paint(object sender, PaintEventArgs e)
        {
            PaintColorBox(e.Graphics, Settings.ContainerColor);
        }

        TextureBrush transparencyBrush = null;
        private void PaintColorBox(Graphics g, Color color)
        {
            if (transparencyBrush == null)
            {
                Brush grayBrush = Brushes.LightGray;
                Bitmap transparencyBitmap = new Bitmap(16, 16);
                using (Graphics r = Graphics.FromImage(transparencyBitmap))
                {
                    r.Clear(Color.White);
                    r.FillRectangle(grayBrush, 0, 0, 8, 8);
                    r.FillRectangle(grayBrush, 8, 8, 8, 8);
                }
                transparencyBrush = new TextureBrush(transparencyBitmap, System.Drawing.Drawing2D.WrapMode.Tile);
            }

            RectangleF rectangle = new RectangleF(0, 0, g.ClipBounds.X + g.ClipBounds.Width, g.ClipBounds.Y + g.ClipBounds.Height);
            g.FillRectangle(transparencyBrush, rectangle);
            g.FillRectangle(new SolidBrush(color), rectangle);
        }

        private void textColorBox_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Color.FromArgb(255, Settings.TextColor);
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                Settings.TextColor = Color.FromArgb(Settings.TextColor.A, colorDialog.Color);
                textColorBox.Invalidate();
            }
        }

        private void containerColorBox_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Color.FromArgb(255, Settings.ContainerColor);
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                Settings.ContainerColor = Color.FromArgb(Settings.ContainerColor.A, colorDialog.Color);
                containerColorBox.Invalidate();
            }
        }

        /*private void notificationColorBox_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Color.FromArgb(255, Settings.NotificationColor);
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                Settings.NotificationColor = Color.FromArgb((int)notificationAlphaBox.Value, colorDialog.Color);
                notificationColorBox.Invalidate();
            }
        }*/

        /*private void textAlphaBox_ValueChanged(object sender, EventArgs e)
        {
            Settings.TextColor = Color.FromArgb((int)textAlphaBox.Value, Settings.TextColor);
            textColorBox.Invalidate();
        }*/

        private void containerAlphaBox_ValueChanged(object sender, EventArgs e)
        {
            Settings.ContainerColor = Color.FromArgb((int)containerAlphaBox.Value, Settings.ContainerColor);
            containerColorBox.Invalidate();
        }

        private void PauseOnFullscreenBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.PauseOnFullscreen = PauseOnFullscreenBox.Checked;
        }

        /*private void notificationAlphaBox_ValueChanged(object sender, EventArgs e)
        {
            Settings.NotificationColor = Color.FromArgb((int)notificationAlphaBox.Value, Settings.NotificationColor);
            notificationColorBox.Invalidate();
        }*/
    }
}
