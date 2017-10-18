using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniSearch
{
    public partial class FormUniSearch : Form
    {
        private ValidationHandler _validator;

        private UniSearchCore _searchCore;

        private bool _isStart;

        private bool _isPaused;

        public FormUniSearch()
        {
            InitializeComponent();
        }

        private void FormUniSearch_Load(object sender, EventArgs e)
        {
            try
            {
                _isStart = false;

                _isPaused = false;

                _searchCore = new UniSearchCore(this, listViewSearchInfo, progressBar);

                _searchCore.FinishScan += () => { Invoke((MethodInvoker) Stop); };

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
                if (!_isStart)
                {
                    Start();
                }
                else
                {
                    Stop();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error: {exception.Message}", @"Error");
            }
        }

        private void Start()
        {
            try
            {
                listViewSearchInfo.Items.Clear();

                int targetDeep = int.Parse(textBoxSearchCount.Text);

                progressBar.Maximum = targetDeep;

                _searchCore.Start(textBoxUrl.Text, targetDeep,
                    int.Parse(textBoxThreadsCount.Text), textBoxSearchString.Text);

                TextBoxesEnabler(false);

                buttonStartStop.Text = @"STOP";

                buttonPauseResume.Enabled = true;

                _isStart = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error: {exception.Message}", @"Error");
            }
        }

        private void Stop()
        {
            try
            {
                _searchCore.Stop();

                TextBoxesEnabler(true);

                buttonStartStop.Text = @"START";

                progressBar.Value = 0;

                _isStart = false;

                buttonPauseResume.Enabled = false;
                _isPaused = false;
                _searchCore.Resume();
                buttonPauseResume.Text = @"PAUSE";
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error: {exception.Message}", @"Error");
            }
        }

        private void TextBoxesEnabler(bool state)
        {
            textBoxSearchCount.Enabled = state;
            textBoxUrl.Enabled = state;
            textBoxSearchString.Enabled = state;
            textBoxThreadsCount.Enabled = state;
        }

        private void buttonPauseResume_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isPaused)
                {
                    _searchCore.Pause();
                    buttonPauseResume.Text = @"RESUME";
                }
                else
                {
                    _searchCore.Resume();
                    buttonPauseResume.Text = @"PAUSE";
                }
                _isPaused = !_isPaused;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error: {exception.Message}", @"Error");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"This App search string on web site. Use async Breadth-first search");
        }
    }
}
