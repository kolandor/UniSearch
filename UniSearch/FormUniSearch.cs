using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniSearch
{
    public partial class FormUniSearch : Form
    {
        private ValidationHandler _validator;

        private UniSearchCore _searchCore;

        public FormUniSearch()
        {
            InitializeComponent();
        }

        private void FormUniSearch_Load(object sender, EventArgs e)
        {
            try
            {
                _searchCore = new UniSearchCore(this, listViewSearchInfo, progressBar);

                RegisterValidationControls();
            }
            catch (Exception exception)
            {
                DialogResult result = MessageBox.Show($"Critical error: {exception.Message}\nRestart App?", @"Error", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
            }
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
            try
            {
                Start();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error: {exception.Message}", @"Error");
            }
        }

        private void Start()
        {
            listViewSearchInfo.Items.Clear();

            int targetDeep = int.Parse(textBoxSearchCount.Text);

            progressBar.Maximum = targetDeep;

            _searchCore.Start(textBoxUrl.Text, targetDeep,
                int.Parse(textBoxThreadsCount.Text), textBoxSearchString.Text);
        }

    }
}
