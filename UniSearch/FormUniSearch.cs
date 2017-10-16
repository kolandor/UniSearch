using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniSearch
{
    public partial class FormUniSearch : Form
    {
        private ValidationHandler _validator;
        
        public FormUniSearch()
        {
            InitializeComponent();
        }

        private void FormUniSearch_Load(object sender, EventArgs e)
        {
            RegisterValidationControls();
        }

        private void RegisterValidationControls()
        {
            _validator = new ValidationHandler(buttonStartStop, textBoxUrl.BackColor, Color.IndianRed);
            _validator.Registration(textBoxUrl, ValidationHandler.ValidationMethod.Url);
            _validator.Registration(textBoxSearchCount, ValidationHandler.ValidationMethod.CurrentDigits);
            _validator.Registration(textBoxThreadsCount, ValidationHandler.ValidationMethod.ThreadsCount);
            _validator.Registration(textBoxSearchString, ValidationHandler.ValidationMethod.NotEmpty);
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {

        }
    }
}
