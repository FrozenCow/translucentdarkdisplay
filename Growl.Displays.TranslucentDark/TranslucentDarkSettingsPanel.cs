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
        private CheckBox showTitleBox;
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
        private FontDialog fontDialog;
        private FontComboBox titleFontFamilyBox;
        private FontComboBox descriptionFontFamilyBox;
        private Label descriptionFontSizeLabel;
        private Label descriptionFontFamilyLabel;
        private CheckBox showDescriptionBox;
        private Label titleSizeLabel;
        private Label label1;
        private ComboBox descriptionFontSizeBox;
        private ComboBox titleFontSizeBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private CheckBox FadeAnimationBox;

        object[] fontSizes = new object[]
                {
                    8.0, 9.0, 10.0, 11.0, 12.0,
                    14.0, 16.0, 18.0, 20.0, 22.0, 24.0, 26.0, 28.0,
                    36.0, 48.0, 72.0
                };

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
            this.showTitleBox = new System.Windows.Forms.CheckBox();
            this.screenLabel = new System.Windows.Forms.Label();
            this.screenBox = new System.Windows.Forms.ComboBox();
            this.placementBox = new System.Windows.Forms.GroupBox();
            this.appearanceBox = new System.Windows.Forms.GroupBox();
            this.descriptionFontSizeBox = new System.Windows.Forms.ComboBox();
            this.descriptionFontSizeLabel = new System.Windows.Forms.Label();
            this.descriptionFontFamilyLabel = new System.Windows.Forms.Label();
            this.showDescriptionBox = new System.Windows.Forms.CheckBox();
            this.titleFontSizeBox = new System.Windows.Forms.ComboBox();
            this.titleSizeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.FadeAnimationBox = new System.Windows.Forms.CheckBox();
            this.descriptionFontFamilyBox = new Growl.Displays.TranslucentDark.FontComboBox();
            this.titleFontFamilyBox = new Growl.Displays.TranslucentDark.FontComboBox();
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
            this.textColorBox.Location = new System.Drawing.Point(88, 46);
            this.textColorBox.Name = "textColorBox";
            this.textColorBox.Size = new System.Drawing.Size(34, 21);
            this.textColorBox.TabIndex = 11;
            this.textColorBox.TabStop = false;
            this.textColorBox.Click += new System.EventHandler(this.TextColorBoxClick);
            this.textColorBox.Paint += new System.Windows.Forms.PaintEventHandler(this.TextColorBoxPaint);
            // 
            // showTitleBox
            // 
            this.showTitleBox.AutoSize = true;
            this.showTitleBox.Location = new System.Drawing.Point(9, 129);
            this.showTitleBox.Name = "showTitleBox";
            this.showTitleBox.Size = new System.Drawing.Size(72, 17);
            this.showTitleBox.TabIndex = 2;
            this.showTitleBox.Text = "Show title";
            this.showTitleBox.UseVisualStyleBackColor = true;
            this.showTitleBox.CheckedChanged += new System.EventHandler(this.ShowTitleBoxCheckedChanged);
            // 
            // screenLabel
            // 
            this.screenLabel.AutoSize = true;
            this.screenLabel.Location = new System.Drawing.Point(227, 228);
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
            this.screenBox.Location = new System.Drawing.Point(343, 225);
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
            this.appearanceBox.Controls.Add(this.descriptionFontSizeBox);
            this.appearanceBox.Controls.Add(this.descriptionFontSizeLabel);
            this.appearanceBox.Controls.Add(this.descriptionFontFamilyLabel);
            this.appearanceBox.Controls.Add(this.showDescriptionBox);
            this.appearanceBox.Controls.Add(this.titleFontSizeBox);
            this.appearanceBox.Controls.Add(this.titleSizeLabel);
            this.appearanceBox.Controls.Add(this.label1);
            this.appearanceBox.Controls.Add(this.descriptionFontFamilyBox);
            this.appearanceBox.Controls.Add(this.titleFontFamilyBox);
            this.appearanceBox.Controls.Add(this.containerAlphaBox);
            this.appearanceBox.Controls.Add(this.containerColorBox);
            this.appearanceBox.Controls.Add(this.containerColorLabel);
            this.appearanceBox.Controls.Add(this.textColorLabel);
            this.appearanceBox.Controls.Add(this.iconSizeLabel);
            this.appearanceBox.Controls.Add(this.showIconBox);
            this.appearanceBox.Controls.Add(this.iconSizeBox);
            this.appearanceBox.Controls.Add(this.showTitleBox);
            this.appearanceBox.Controls.Add(this.textColorBox);
            this.appearanceBox.Location = new System.Drawing.Point(3, 3);
            this.appearanceBox.Name = "appearanceBox";
            this.appearanceBox.Size = new System.Drawing.Size(208, 301);
            this.appearanceBox.TabIndex = 18;
            this.appearanceBox.TabStop = false;
            this.appearanceBox.Text = "Appearance";
            // 
            // descriptionFontSizeBox
            // 
            this.descriptionFontSizeBox.FormattingEnabled = true;
            this.descriptionFontSizeBox.Location = new System.Drawing.Point(88, 259);
            this.descriptionFontSizeBox.Name = "descriptionFontSizeBox";
            this.descriptionFontSizeBox.Size = new System.Drawing.Size(58, 21);
            this.descriptionFontSizeBox.TabIndex = 35;
            this.descriptionFontSizeBox.Validating += new System.ComponentModel.CancelEventHandler(this.DescriptionFontSizeBoxValidating);
            this.descriptionFontSizeBox.SelectedIndexChanged += new System.EventHandler(this.DescriptionFontSizeBoxSelectedIndexChanged);
            this.descriptionFontSizeBox.Validated += new System.EventHandler(this.DescriptionFontSizeBoxValidated);
            // 
            // descriptionFontSizeLabel
            // 
            this.descriptionFontSizeLabel.AutoSize = true;
            this.descriptionFontSizeLabel.Location = new System.Drawing.Point(26, 262);
            this.descriptionFontSizeLabel.Name = "descriptionFontSizeLabel";
            this.descriptionFontSizeLabel.Size = new System.Drawing.Size(27, 13);
            this.descriptionFontSizeLabel.TabIndex = 34;
            this.descriptionFontSizeLabel.Text = "Size";
            // 
            // descriptionFontFamilyLabel
            // 
            this.descriptionFontFamilyLabel.AutoSize = true;
            this.descriptionFontFamilyLabel.Location = new System.Drawing.Point(26, 235);
            this.descriptionFontFamilyLabel.Name = "descriptionFontFamilyLabel";
            this.descriptionFontFamilyLabel.Size = new System.Drawing.Size(28, 13);
            this.descriptionFontFamilyLabel.TabIndex = 33;
            this.descriptionFontFamilyLabel.Text = "Font";
            // 
            // showDescriptionBox
            // 
            this.showDescriptionBox.AutoSize = true;
            this.showDescriptionBox.Location = new System.Drawing.Point(9, 209);
            this.showDescriptionBox.Name = "showDescriptionBox";
            this.showDescriptionBox.Size = new System.Drawing.Size(107, 17);
            this.showDescriptionBox.TabIndex = 32;
            this.showDescriptionBox.Text = "Show description";
            this.showDescriptionBox.UseVisualStyleBackColor = true;
            this.showDescriptionBox.CheckedChanged += new System.EventHandler(this.ShowDescriptionBoxCheckedChanged);
            // 
            // titleFontSizeBox
            // 
            this.titleFontSizeBox.FormattingEnabled = true;
            this.titleFontSizeBox.Location = new System.Drawing.Point(88, 180);
            this.titleFontSizeBox.Name = "titleFontSizeBox";
            this.titleFontSizeBox.Size = new System.Drawing.Size(58, 21);
            this.titleFontSizeBox.TabIndex = 31;
            this.titleFontSizeBox.Validating += new System.ComponentModel.CancelEventHandler(this.TitleFontSizeBoxValidating);
            this.titleFontSizeBox.SelectedIndexChanged += new System.EventHandler(this.TitleFontSizeBoxSelectedIndexChanged);
            this.titleFontSizeBox.Validated += new System.EventHandler(this.TitleFontSizeBoxValidated);
            // 
            // titleSizeLabel
            // 
            this.titleSizeLabel.AutoSize = true;
            this.titleSizeLabel.Location = new System.Drawing.Point(26, 182);
            this.titleSizeLabel.Name = "titleSizeLabel";
            this.titleSizeLabel.Size = new System.Drawing.Size(27, 13);
            this.titleSizeLabel.TabIndex = 30;
            this.titleSizeLabel.Text = "Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Font";
            // 
            // containerAlphaBox
            // 
            this.containerAlphaBox.Location = new System.Drawing.Point(129, 19);
            this.containerAlphaBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.containerAlphaBox.Name = "containerAlphaBox";
            this.containerAlphaBox.Size = new System.Drawing.Size(44, 20);
            this.containerAlphaBox.TabIndex = 20;
            this.containerAlphaBox.ValueChanged += new System.EventHandler(this.ContainerAlphaBoxValueChanged);
            // 
            // containerColorBox
            // 
            this.containerColorBox.BackColor = System.Drawing.Color.Transparent;
            this.containerColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.containerColorBox.Location = new System.Drawing.Point(88, 19);
            this.containerColorBox.Name = "containerColorBox";
            this.containerColorBox.Size = new System.Drawing.Size(34, 21);
            this.containerColorBox.TabIndex = 17;
            this.containerColorBox.TabStop = false;
            this.containerColorBox.Click += new System.EventHandler(this.ContainerColorBoxClick);
            this.containerColorBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ContainerColorBoxPaint);
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
            this.textColorLabel.Location = new System.Drawing.Point(6, 50);
            this.textColorLabel.Name = "textColorLabel";
            this.textColorLabel.Size = new System.Drawing.Size(54, 13);
            this.textColorLabel.TabIndex = 16;
            this.textColorLabel.Text = "Text color";
            // 
            // iconSizeLabel
            // 
            this.iconSizeLabel.AutoSize = true;
            this.iconSizeLabel.Location = new System.Drawing.Point(26, 103);
            this.iconSizeLabel.Name = "iconSizeLabel";
            this.iconSizeLabel.Size = new System.Drawing.Size(49, 13);
            this.iconSizeLabel.TabIndex = 15;
            this.iconSizeLabel.Text = "Icon size";
            // 
            // showIconBox
            // 
            this.showIconBox.AutoSize = true;
            this.showIconBox.Location = new System.Drawing.Point(9, 75);
            this.showIconBox.Name = "showIconBox";
            this.showIconBox.Size = new System.Drawing.Size(76, 17);
            this.showIconBox.TabIndex = 0;
            this.showIconBox.Text = "Show icon";
            this.showIconBox.UseVisualStyleBackColor = true;
            this.showIconBox.CheckedChanged += new System.EventHandler(this.ShowIconBoxCheckedChanged);
            // 
            // iconSizeBox
            // 
            this.iconSizeBox.Location = new System.Drawing.Point(88, 101);
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
            this.behaviorBox.Controls.Add(this.FadeAnimationBox);
            this.behaviorBox.Controls.Add(this.PauseOnFullscreenBox);
            this.behaviorBox.Location = new System.Drawing.Point(218, 113);
            this.behaviorBox.Name = "behaviorBox";
            this.behaviorBox.Size = new System.Drawing.Size(232, 70);
            this.behaviorBox.TabIndex = 19;
            this.behaviorBox.TabStop = false;
            this.behaviorBox.Text = "Behavior";
            // 
            // PauseOnFullscreenBox
            // 
            this.PauseOnFullscreenBox.AutoSize = true;
            this.PauseOnFullscreenBox.Location = new System.Drawing.Point(12, 42);
            this.PauseOnFullscreenBox.Name = "PauseOnFullscreenBox";
            this.PauseOnFullscreenBox.Size = new System.Drawing.Size(119, 17);
            this.PauseOnFullscreenBox.TabIndex = 0;
            this.PauseOnFullscreenBox.Text = "Pause on fullscreen";
            this.toolTip.SetToolTip(this.PauseOnFullscreenBox, "When enabled, no notifications will be popped up when another application is runn" +
                    "ing fullscreen. The notifications will be queued until the other application is " +
                    "not running fullscreen anymore.");
            this.PauseOnFullscreenBox.UseVisualStyleBackColor = true;
            this.PauseOnFullscreenBox.CheckedChanged += new System.EventHandler(this.PauseOnFullscreenBoxCheckedChanged);
            // 
            // fontDialog
            // 
            this.fontDialog.ShowEffects = false;
            // 
            // FadeAnimationBox
            // 
            this.FadeAnimationBox.AutoSize = true;
            this.FadeAnimationBox.Location = new System.Drawing.Point(12, 19);
            this.FadeAnimationBox.Name = "FadeAnimationBox";
            this.FadeAnimationBox.Size = new System.Drawing.Size(117, 17);
            this.FadeAnimationBox.TabIndex = 1;
            this.FadeAnimationBox.Text = "Use fade animation";
            this.FadeAnimationBox.UseVisualStyleBackColor = true;
            this.FadeAnimationBox.CheckedChanged += new System.EventHandler(this.FadeAnimationBoxCheckedChanged);
            // 
            // descriptionFontFamilyBox
            // 
            this.descriptionFontFamilyBox.BackColor = System.Drawing.SystemColors.Window;
            this.descriptionFontFamilyBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.descriptionFontFamilyBox.Location = new System.Drawing.Point(88, 232);
            this.descriptionFontFamilyBox.Name = "descriptionFontFamilyBox";
            this.descriptionFontFamilyBox.Size = new System.Drawing.Size(114, 21);
            this.descriptionFontFamilyBox.TabIndex = 27;
            this.descriptionFontFamilyBox.Text = "fontComboBox1";
            this.descriptionFontFamilyBox.SelectedIndexChanged += new System.EventHandler(this.DescriptionFontFamilyBoxSelectedIndexChanged);
            // 
            // titleFontFamilyBox
            // 
            this.titleFontFamilyBox.BackColor = System.Drawing.SystemColors.Window;
            this.titleFontFamilyBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.titleFontFamilyBox.Location = new System.Drawing.Point(88, 152);
            this.titleFontFamilyBox.Name = "titleFontFamilyBox";
            this.titleFontFamilyBox.Size = new System.Drawing.Size(114, 21);
            this.titleFontFamilyBox.TabIndex = 20;
            this.titleFontFamilyBox.SelectedIndexChanged += new System.EventHandler(this.TitleFontFamilySelectedIndexChanged);
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
            this.Size = new System.Drawing.Size(450, 304);
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

            titleFontSizeBox.SelectedIndexChanged -= TitleFontSizeBoxSelectedIndexChanged;
            titleFontSizeBox.DataSource = fontSizes.Clone();
            titleFontSizeBox.SelectedIndexChanged += TitleFontSizeBoxSelectedIndexChanged;

            descriptionFontSizeBox.SelectedIndexChanged -= DescriptionFontSizeBoxSelectedIndexChanged;
            descriptionFontSizeBox.DataSource = fontSizes.Clone();
            descriptionFontSizeBox.SelectedIndexChanged += DescriptionFontSizeBoxSelectedIndexChanged;
        }

        protected override SettingsWrapper CreateSettings(IDictionary<string, object> settings)
        {
            return new TranslucentDarkSettings(settings);
        }

        public override void LoadSettings()
        {
            base.LoadSettings();
            textColorBox.BackColor = Color.FromArgb(Settings.TextColor.A, Settings.TextColor.R, Settings.TextColor.G, Settings.TextColor.B);
            SetSelectedValue(horizontalPlacementBox, Settings.HorizontalPlacement);
            SetSelectedValue(verticalPlacementBox, Settings.VerticalPlacement);
            fixedWidthBox.Checked = Settings.FixedWidth >= 0.0;
            if (fixedWidthBox.Checked)
                widthBox.Value = (decimal)Settings.FixedWidth;
            else
                widthBox.Value = 256;
            iconSizeBox.Value = (decimal)Settings.IconSize;
            showIconBox.Checked = Settings.ShowIcon;

            int screenIndex = Settings.Screen;
            if (screenIndex < 0 || screenIndex >= screenBox.Items.Count)
                screenIndex = 0;
            screenBox.SelectedIndex = screenIndex;

            containerAlphaBox.Value = Settings.ContainerColor.A;

            PauseOnFullscreenBox.Checked = Settings.PauseOnFullscreen;

            FadeAnimationBox.Checked = Settings.UseFadeAnimation;

            showTitleBox.Checked = Settings.ShowTitle;
            showDescriptionBox.Checked = Settings.ShowDescription;

            titleFontFamilyBox.SelectedFontFamily = GetFontFamily(Settings.TitleFontFamily);
            descriptionFontFamilyBox.SelectedFontFamily = GetFontFamily(Settings.DescriptionFontFamily);

            titleFontSizeBox.Text = GetFontSize(Settings.TitleFontSize).ToString();
            descriptionFontSizeBox.Text = GetFontSize(Settings.DescriptionFontSize).ToString();
        }

        private static FontFamily GetFontFamily(string name)
        {
            if (name == null)
                return GetDefaultFontFamily();
            try
            {
                return new FontFamily(name);
            }
            catch (ArgumentException)
            {
                return GetDefaultFontFamily();
            }
        }

        private static double GetFontSize(double size)
        {
            return double.IsNaN(size) ? GetDefaultFontSize() : size;
        }

        private static FontFamily GetDefaultFontFamily()
        {
            string defaultFontFamilyName = System.Windows.SystemFonts.MessageFontFamily.Source;
            return new FontFamily(defaultFontFamilyName);
        }

        private static double GetDefaultFontSize()
        {
            return System.Windows.SystemFonts.MessageFontSize;
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

        private void ScreenBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Screen = screenBox.SelectedIndex;
        }

        private void TextColorBoxPaint(object sender, PaintEventArgs e)
        {
            PaintColorBox(e.Graphics, Settings.TextColor);
        }

        private void ContainerColorBoxPaint(object sender, PaintEventArgs e)
        {
            PaintColorBox(e.Graphics, Settings.ContainerColor);
        }

        TextureBrush _transparencyBrush = null;
        private void PaintColorBox(Graphics g, Color color)
        {
            if (_transparencyBrush == null)
            {
                Brush grayBrush = Brushes.LightGray;
                Bitmap transparencyBitmap = new Bitmap(16, 16);
                using (Graphics r = Graphics.FromImage(transparencyBitmap))
                {
                    r.Clear(Color.White);
                    r.FillRectangle(grayBrush, 0, 0, 8, 8);
                    r.FillRectangle(grayBrush, 8, 8, 8, 8);
                }
                _transparencyBrush = new TextureBrush(transparencyBitmap, System.Drawing.Drawing2D.WrapMode.Tile);
            }

            RectangleF rectangle = new RectangleF(0, 0, g.ClipBounds.X + g.ClipBounds.Width, g.ClipBounds.Y + g.ClipBounds.Height);
            g.FillRectangle(_transparencyBrush, rectangle);
            g.FillRectangle(new SolidBrush(color), rectangle);
        }

        private void TextColorBoxClick(object sender, EventArgs e)
        {
            colorDialog.Color = Color.FromArgb(255, Settings.TextColor);
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                Settings.TextColor = Color.FromArgb(Settings.TextColor.A, colorDialog.Color);
                textColorBox.Invalidate();
            }
        }

        private void ContainerColorBoxClick(object sender, EventArgs e)
        {
            colorDialog.Color = Color.FromArgb(255, Settings.ContainerColor);
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                Settings.ContainerColor = Color.FromArgb(Settings.ContainerColor.A, colorDialog.Color);
                containerColorBox.Invalidate();
            }
        }

        private void ContainerAlphaBoxValueChanged(object sender, EventArgs e)
        {
            Settings.ContainerColor = Color.FromArgb((int)containerAlphaBox.Value, Settings.ContainerColor);
            containerColorBox.Invalidate();
        }

        private void PauseOnFullscreenBoxCheckedChanged(object sender, EventArgs e)
        {
            Settings.PauseOnFullscreen = PauseOnFullscreenBox.Checked;
        }

        private void FadeAnimationBoxCheckedChanged(object sender, EventArgs e)
        {
            Settings.UseFadeAnimation = FadeAnimationBox.Checked;
        }

        private void ShowTitleBoxCheckedChanged(object sender, EventArgs e)
        {
            Settings.ShowTitle = showTitleBox.Checked;
            titleFontFamilyBox.Enabled = showTitleBox.Checked;
            titleFontSizeBox.Enabled = showTitleBox.Checked;
        }

        private void ShowDescriptionBoxCheckedChanged(object sender, EventArgs e)
        {
            Settings.ShowDescription = showDescriptionBox.Checked;
            descriptionFontFamilyBox.Enabled = showDescriptionBox.Checked;
            descriptionFontSizeBox.Enabled = showDescriptionBox.Checked;
        }

        private void TitleFontFamilySelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.TitleFontFamily = titleFontFamilyBox.SelectedFontFamily.Name;
        }

        private void DescriptionFontFamilyBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.DescriptionFontFamily = descriptionFontFamilyBox.SelectedFontFamily.Name;
        }

        private void TitleFontSizeBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.TitleFontSize = (double)titleFontSizeBox.SelectedValue;
        }

        private void DescriptionFontSizeBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.DescriptionFontSize = (double)descriptionFontSizeBox.SelectedValue;
        }

        private void TitleFontSizeBoxValidating(object sender, CancelEventArgs e)
        {
            double fontSize;
            e.Cancel = !double.TryParse(titleFontSizeBox.Text, out fontSize);
        }

        private void DescriptionFontSizeBoxValidating(object sender, CancelEventArgs e)
        {
            double fontSize;
            e.Cancel = !double.TryParse(descriptionFontSizeBox.Text, out fontSize);
        }

        private void DescriptionFontSizeBoxValidated(object sender, EventArgs e)
        {
            double fontSize;
            if (double.TryParse(descriptionFontSizeBox.Text, out fontSize))
                Settings.DescriptionFontSize = fontSize;
        }

        private void TitleFontSizeBoxValidated(object sender, EventArgs e)
        {
            double fontSize;
            if (double.TryParse(titleFontSizeBox.Text, out fontSize))
                Settings.TitleFontSize = fontSize;
        }
    }
}
