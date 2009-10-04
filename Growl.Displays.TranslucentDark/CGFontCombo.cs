// This is a modified version of the Managed Font Combobox by Martin Cook that
// was released here:
// http://www.codeproject.com/KB/combobox/CGFontCombo.aspx
/*****************************************************************************
  Copyright © 2004 - 2005 by Martin Cook. All rights are reserved. If you like
  this code then feel free to go ahead and use it. The only thing I ask is 
  that you don't remove or alter my copyright notice. Your use of this 
  software is entirely at your own risk. I make no claims about the 
  reliability or fitness of this code for any particular purpose. If you 
  make changes or additions to this code then please clearly mark your code 
  as yours. If you have questions or comments then please contact me at: 
  martin@codegator.com
  
  Have Fun! :o)
*****************************************************************************/

#region Using directives

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Growl.Displays.TranslucentDark
{
    /// <summary>
    /// A control that produces a selectable list of fonts.
    /// </summary>
    public class FontComboBox : Control
    {
        // ******************************************************************
        // Events.
        // ******************************************************************

        #region Events

        /// <summary>
        /// Occurs whenever the 'SelectedIndex' property for this control changes.
        /// </summary>
        public event EventHandler SelectedIndexChanged;

        #endregion

        // ******************************************************************
        // Attributes.
        // ******************************************************************

        #region Attributes

        /// <summary>
        /// The actual combobox.
        /// </summary>
        private ComboBox _comboBox;

        #endregion

        // ******************************************************************
        // Properties.
        // ******************************************************************

        #region Properties

        /// <summary>
        /// Gets and sets the background color.
        /// </summary>
        [DefaultValue("Window")]
        public override Color BackColor
        {
            get { return _comboBox.BackColor; }

            set
            {
                // If nothing has changed then simply exit.
                if (_comboBox.BackColor == value)
                    return;

                // Save the value.
                _comboBox.BackColor = value;
            } // End set
        } // End BackColor

        // ******************************************************************

        /// <summary>
        /// Gets and sets the foreground color.
        /// </summary>
        [DefaultValue("WindowText")]
        public override Color ForeColor
        {
            get { return _comboBox.ForeColor; }

            set
            {
                // If nothing has changed then simply exit.
                if (_comboBox.ForeColor == value)
                    return;

                // Save the value.
                _comboBox.ForeColor = value;
            } // End set
        } // End ForeColor

        // ******************************************************************

        private FontFamily selectedFontFamily;

        /// <summary>
        /// Gets and sets the selected font family.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FontFamily SelectedFontFamily
        {
            get
            {
                // Sanity check the combobox before attempting to use it.
                if (_comboBox != null)
                    return _comboBox.SelectedItem as FontFamily;
                return selectedFontFamily;
            }

            set
            {
                selectedFontFamily = value;

                if (_comboBox != null)
                    _comboBox.SelectedItem = value;
            }
        } // End SelectedFontFamily

        // ******************************************************************

        /// <summary>
        /// Gets and sets the index of the currently selected item.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return _comboBox.SelectedIndex; }
            set { _comboBox.SelectedIndex = value; }
        } // End SelectedIndex

        #endregion

        // ******************************************************************
        // Constructors.
        // ******************************************************************

        #region Constructors

        /// <summary>
        /// Creates a new instance of the CGFontCombo class.
        /// </summary>
        public FontComboBox()
        {
            // Required by the designer.
            InitializeComponent();

            // Create the combobox.
            _comboBox = new ComboBox();
            _comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _comboBox.Dock = DockStyle.Fill;
            _comboBox.DrawMode = DrawMode.OwnerDrawFixed;
            _comboBox.BackColor = SystemColors.Window;
            _comboBox.ForeColor = SystemColors.WindowText;
            _comboBox.DisplayMember = "Name";
            _comboBox.DrawItem += m_comboBox_DrawItem;
            _comboBox.SelectedIndexChanged += m_comboBox_SelectedIndexChanged;
            _comboBox.FontChanged += m_comboBox_FontChanged;
            Controls.Add(_comboBox);

            // Fixup the styles.
            SetStyle(ControlStyles.StandardClick, false);
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.UserPaint, false);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, false);
        } // End CGFontCombo()

        #endregion

        // ******************************************************************
        // Overrides.
        // ******************************************************************

        #region Overrides

        /// <summary>
        /// Raises the System.Windows.Forms.Control.HandleCreated event.  
        /// </summary>
        /// <param name="e">An System.EventArgs that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Populate the combobox.
            CreateSampleFonts();
            _comboBox.SelectedItem = selectedFontFamily;
        } // End OnHandleCreated()

        // ******************************************************************

        #endregion

        // ******************************************************************
        // Component Designer generated code.
        // ******************************************************************

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }

        #endregion

        // ******************************************************************
        // Combobox event handlers.
        // ******************************************************************

        #region Combobox event handlers

        /// <summary>
        /// Called whenever the combobox needs to draw an item.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void m_comboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // If the index is invalid then simply exit.
            if (e.Index == -1 || e.Index >= _comboBox.Items.Count)
                return;

            // Draw the background of the item.
            e.DrawBackground();

            // Should we draw the focus rectangle?
            if ((e.State & DrawItemState.Focus) != 0)
                e.DrawFocusRectangle();

            // Create a new background brush.
            FontFamily fontFamily = (FontFamily)_comboBox.Items[e.Index];
            if (fontFamily.IsStyleAvailable(FontStyle.Regular))
            {
                using (Brush b = new SolidBrush(e.ForeColor))
                {
                    using (Font font = new Font(fontFamily, Font.Size))
                    {
                        // Draw the item.
                        e.Graphics.DrawString(
                            fontFamily.Name,
                            font,
                            Enabled ? b : SystemBrushes.ControlDarkDark,
                            e.Bounds
                            );
                    }
                }
            }
            else
            {
                using (Brush b = new SolidBrush(Color.DimGray))
                {
                    e.Graphics.DrawString(
                        fontFamily.Name,
                        Font,
                        b,
                        e.Bounds
                        );
                }
            }
        } // End m_comboBox_DrawItem()

        // ******************************************************************

        /// <summary>
        /// Called whenever the selected item in the combobox is changed.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void m_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedIndexChanged();
        } // End m_comboBox_SelectedIndexChanged()

        // ******************************************************************

        /// <summary>
        /// Called whenever the combobox font is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_comboBox_FontChanged(object sender, EventArgs e)
        {
            CreateSampleFonts();
        }

        #endregion

        // ******************************************************************
        // Protected.
        // ******************************************************************

        #region Protected methods

        /// <summary>
        /// Raises the SelectedIndexChanged event.
        /// </summary>
        protected virtual void OnSelectedIndexChanged()
        {
            // Should we fire the event?
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this, EventArgs.Empty);
        } // End OnSelectedIndexChanged()

        #endregion

        // ******************************************************************
        // Private methods.
        // ******************************************************************

        #region Private methods.

        /// <summary>
        /// Creates the array of sample fonts.
        /// </summary>
        private void CreateSampleFonts()
        {
            // Should we simply exit?
            if (!IsHandleCreated || DesignMode)
                return;

            // Should we destroy any existing sample fonts?
            if (_comboBox.Items.Count > 0)
                _comboBox.Items.Clear();

            // Gets the list of installed fonts.
            FontFamily[] ff = FontFamily.Families;
            for (int i = 0; i < ff.Length; i++)
                _comboBox.Items.Add(ff[i]);
        }

        #endregion
    } // End class CGFontCombo
} // End namespace CG.FontCombo