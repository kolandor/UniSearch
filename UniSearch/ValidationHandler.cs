using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UniSearch
{
    /// <summary>
    /// TextBox validator
    /// </summary>
    public class ValidationHandler
    {
        private const int MaxThreadsCount = 1024;
        
        private readonly Color _colorValid;
        
        private readonly Color _colorNotValid;

        /// <summary>
        /// Witch validation method use
        /// </summary>
        public enum ValidationMethod
        {
            /// <summary>
            /// The URL
            /// </summary>
            Url,
            /// <summary>
            /// The current digits
            /// </summary>
            CurrentDigits,
            /// <summary>
            /// The threads count
            /// </summary>
            ThreadsCount,
            /// <summary>
            /// The not empty
            /// </summary>
            NotEmpty
        }


        private readonly Dictionary<TextBox, bool> _registeredToValidationControls;


        private readonly Button _staButton;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationHandler"/> class.
        /// </summary>
        /// <param name="startButton">The start button. To enable or disable after validate</param>
        /// <param name="validTextBox">The valid text box.</param>
        /// <param name="notValidTextBox">The not valid text box.</param>
        public ValidationHandler(Button startButton, Color validTextBox, Color notValidTextBox)
        {
            _colorValid = validTextBox;
            _colorNotValid = notValidTextBox;
            _staButton = startButton;
            _registeredToValidationControls = new Dictionary<TextBox, bool>();
        }

        /// <summary>
        /// Registrations the specified text box to valid.
        /// </summary>
        /// <param name="textBoxToValid">The text box to valid.</param>
        /// <param name="method">The method.</param>
        public void Registration(TextBox textBoxToValid, ValidationMethod method)
        {
            switch (method)
            {
                case ValidationMethod.Url:
                    textBoxToValid.TextChanged += textBoxUrl_TextChanged;
                    _registeredToValidationControls.Add(textBoxToValid, false);
                    break;
                case ValidationMethod.CurrentDigits:
                    textBoxToValid.TextChanged += textBoxCurrentDigits_TextChanged;
                    _registeredToValidationControls.Add(textBoxToValid, false);
                    break;
                case ValidationMethod.ThreadsCount:
                    textBoxToValid.TextChanged += textBoxThreadsCount_TextChanged;
                    _registeredToValidationControls.Add(textBoxToValid, false);
                    break;
                case ValidationMethod.NotEmpty:
                    textBoxToValid.TextChanged += textBoxNotEmpty_TextChanged;
                    _registeredToValidationControls.Add(textBoxToValid, false);
                    break;
            }
        }

        #region Validation Methods

        private void textBoxNotEmpty_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == null)
            {
                return;
            }

            try
            {
                string text = textBox.Text;

                if (string.IsNullOrEmpty(text))
                {
                    SetValidStateTextBox(textBox, false);
                    return;
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            SetValidStateTextBox(textBox, true);
        }

        private void textBoxUrl_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == null)
            {
                return;
            }

            try
            {
                string text = textBox.Text;

                if (string.IsNullOrEmpty(text))
                {
                    SetValidStateTextBox(textBox, false);
                    return;
                }
                
                if (!Regex.IsMatch(text, @"https?://[\w\d\-_]+(\.[\w\d\-_]+)+[\w\d\-\.,@?^=%&amp;:/~\+#]*"))
                {
                    SetValidStateTextBox(textBox, false);
                    return;
                }

            }
            catch(Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            SetValidStateTextBox(textBox, true);
        }
        
        private void textBoxCurrentDigits_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == null)
            {
                return;
            }

            try
            {
                string text = textBox.Text;

                if (string.IsNullOrEmpty(text))
                {
                    SetValidStateTextBox(textBox, false);
                    return;
                }

                int parsedNumber;
                if (!int.TryParse(text, out parsedNumber) || parsedNumber <= 0)
                {
                    textBox.Text = $"{parsedNumber}";
                    SetValidStateTextBox(textBox, false);
                    return;
                }
                textBox.Text = $"{parsedNumber}";
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            SetValidStateTextBox(textBox, true);
        }
        
        private void textBoxThreadsCount_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == null)
            {
                return;
            }

            try
            {
                string text = textBox.Text;

                if (string.IsNullOrEmpty(text))
                {
                    SetValidStateTextBox(textBox, false);
                    return;
                }

                int parsedNumber;
                if (!int.TryParse(text, out parsedNumber) || parsedNumber <= 0 || parsedNumber > MaxThreadsCount)
                {
                    textBox.Text = $"{parsedNumber}";
                    SetValidStateTextBox(textBox, false);
                    return;
                }
                textBox.Text = $"{parsedNumber}";
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            SetValidStateTextBox(textBox, true);
        }

        #endregion
        
        private void SetValidStateTextBox(TextBox textBox, bool state)
        {
            if (state)
            {
                _registeredToValidationControls[textBox] = true;
                textBox.BackColor = _colorValid;
                
            }
            else
            {
                _registeredToValidationControls[textBox] = false;
                textBox.BackColor = _colorNotValid;
            }
            IsValidate();
        }
        
        private void IsValidate()
        {
            _staButton.Enabled = _registeredToValidationControls.All(element => element.Value);
        }
    }
}
