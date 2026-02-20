using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Company.App
{
    public partial class CompanyNameDialog : Form
    {
        private RadioButton rbTimes, rbArial, rbCourier;
        private RadioButton rb16, rb20, rb24;
        private Button colorButton;
        private TextBox oldTextBox, newTextBox;
        private Color selectedColor;
        private Font selectedFont;
        private string newText;

        public Font SelectedFont => selectedFont;
        public Color SelectedColor => selectedColor;
        public string NewText => newText;

        public CompanyNameDialog(Label companyLabel)
        {
            InitializeComponent();
            this.Text = "Format Company Name";
            this.Size = new Size(400, 300);

            TabControl tabControl = new TabControl { Dock = DockStyle.Top, Height = 200 };

            // Font Tab
            TabPage fontPage = new TabPage("Font");
            rbTimes = new RadioButton { Text = "Times New Roman", Location = new Point(20, 20) };
            rbArial = new RadioButton { Text = "Arial", Location = new Point(20, 50) };
            rbCourier = new RadioButton { Text = "Courier", Location = new Point(20, 80) };
            fontPage.Controls.AddRange(new Control[] { rbTimes, rbArial, rbCourier });

            // Size Tab
            TabPage sizePage = new TabPage("Size");
            rb16 = new RadioButton { Text = "16", Location = new Point(20, 20) };
            rb20 = new RadioButton { Text = "20", Location = new Point(20, 50) };
            rb24 = new RadioButton { Text = "24", Location = new Point(20, 80) };
            sizePage.Controls.AddRange(new Control[] { rb16, rb20, rb24 });

            // Color Tab
            TabPage colorPage = new TabPage("Color");
            colorButton = new Button { Text = "Choose Color", Location = new Point(20, 20) };
            colorButton.Click += (s, e) =>
            {
                using (ColorDialog cd = new ColorDialog())
                {
                    if (cd.ShowDialog() == DialogResult.OK)
                        selectedColor = cd.Color;
                }
            };
            colorPage.Controls.Add(colorButton);

            // Text Tab
            TabPage textPage = new TabPage("Text");
            oldTextBox = new TextBox { Text = companyLabel.Text, Location = new Point(20, 20), ReadOnly = true };
            newTextBox = new TextBox { Location = new Point(20, 60) };
            textPage.Controls.AddRange(new Control[] { oldTextBox, newTextBox });

            tabControl.TabPages.AddRange(new TabPage[] { fontPage, sizePage, colorPage, textPage });
            this.Controls.Add(tabControl);

            // OK / Cancel buttons
            Button okButton = new Button { Text = "OK", Location = new Point(200, 220) };
            Button cancelButton = new Button { Text = "Cancel", Location = new Point(280, 220) };

            okButton.Click += (s, e) =>
            {
                string fontName = rbTimes.Checked ? "Times New Roman" :
                                  rbArial.Checked ? "Arial" :
                                  rbCourier.Checked ? "Courier New" : companyLabel.Font.Name;

                float fontSize = rb16.Checked ? 16 :
                                 rb20.Checked ? 20 :
                                 rb24.Checked ? 24 : companyLabel.Font.Size;

                selectedFont = new Font(fontName, fontSize, companyLabel.Font.Style);
                newText = string.IsNullOrWhiteSpace(newTextBox.Text) ? companyLabel.Text : newTextBox.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            cancelButton.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            this.Controls.Add(okButton);
            this.Controls.Add(cancelButton);

            // Initialize selections to current label state
            if (companyLabel.Font.Name.Contains("Times")) rbTimes.Checked = true;
            else if (companyLabel.Font.Name.Contains("Arial")) rbArial.Checked = true;
            else rbCourier.Checked = true;

            if (companyLabel.Font.Size == 16) rb16.Checked = true;
            else if (companyLabel.Font.Size == 20) rb20.Checked = true;
            else rb24.Checked = true;

            selectedColor = companyLabel.ForeColor;
        }

        private void CompanyNameDialog_Load(object sender, EventArgs e)
        {

        }
    }

}
