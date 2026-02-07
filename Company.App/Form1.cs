using System.Drawing.Drawing2D;

namespace Company.App
{
    public partial class Form1 : Form
    {
        private int[] _years = { 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997 };
        private int[] _revenues = { 150, 170, 180, 175, 200, 250, 210, 240, 280, 14 };
        private Color _lineColor = Color.Blue;

        public Form1()
        {
            InitializeComponent();
            this.Text = "ABC Company Annual Revenue";
            this.Size = new Size(900, 600);

            // Company name
            Label companyLabel = new Label
            {
                Text = "ABC Company",
                Font = new Font("Arial", 18, FontStyle.Bold),
                AutoSize = true,
                Location = new Point((this.ClientSize.Width / 2) - 80, 20)
            };
            this.Controls.Add(companyLabel);

            // Report title
            Label reportLabel = new Label
            {
                Text = "Annual Revenue",
                Font = new Font("Arial", 14, FontStyle.Italic),
                AutoSize = true,
                Location = new Point((this.ClientSize.Width / 2) - 70, 60)
            };
            this.Controls.Add(reportLabel);

            // Table on the right
            InitializeTable();

            // Events
            this.KeyPreview = true;
            this.KeyDown += Form_Key_Color_Event;
            this.MouseClick += Form_Mouse_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle chartArea = new Rectangle(50, 120, 400, 300);

            // Axes
            g.DrawLine(Pens.Black, chartArea.Left, chartArea.Bottom, chartArea.Right, chartArea.Bottom); // X-axis
            g.DrawLine(Pens.Black, chartArea.Left, chartArea.Bottom, chartArea.Left, chartArea.Top);     // Y-axis

            int maxRevenue = 300; // scale
            int barWidth = chartArea.Width / _years.Length - 10;

            Point[] linePoints = new Point[_years.Length];

            for (int i = 0; i < _years.Length; i++)
            {
                int x = chartArea.Left + i * (barWidth + 10);
                int barHeight = (int)((_revenues[i] / (float)maxRevenue) * chartArea.Height);
                int y = chartArea.Bottom - barHeight;

                // Bar (red with hatch)
                using (HatchBrush hatch = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Red, Color.White))
                {
                    g.FillRectangle(hatch, x, y, barWidth, barHeight);
                }
                g.DrawRectangle(Pens.Black, x, y, barWidth, barHeight);

                // Line points
                linePoints[i] = new Point(x + barWidth / 2, y);
            }

            // Line chart
            using (Pen linePen = new Pen(_lineColor, 2))
            {
                g.DrawLines(linePen, linePoints);
            }
        }

        private void InitializeTable()
        {
            Panel tablePanel = new Panel
            {
                Location = new Point(500, 120),
                Size = new Size(350, 300),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Year header
            Label yearHeader = new Label
            {
                Text = "Year",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };
            tablePanel.Controls.Add(yearHeader);
            // Revenue header
            Label revenueHeader = new Label
            {
                Text = "Revenue",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(120, 10),
                AutoSize = true
            };
            tablePanel.Controls.Add(revenueHeader);

            // Add data rows
            for (int i = 0; i < _years.Length; i++)
            {
                Label yearLabel = new Label
                {
                    Text = _years[i].ToString(),
                    Location = new Point(10, 40 + i * 25),
                    AutoSize = true
                };
                tablePanel.Controls.Add(yearLabel);

                Label revenueLabel = new Label
                {
                    Text = _revenues[i].ToString(),
                    Location = new Point(120, 40 + i * 25),
                    AutoSize = true
                };
                tablePanel.Controls.Add(revenueLabel);
            }

            this.Controls.Add(tablePanel);
        }

        private void Form_Key_Color_Event(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.R) _lineColor = Color.Red;
                else if (e.KeyCode == Keys.G) _lineColor = Color.Green;
                else if (e.KeyCode == Keys.B) _lineColor = Color.Blue;

                this.Invalidate(); // redraw chart
            }
        }

        private void Form_Mouse_Click(object sender, MouseEventArgs e)
        {
            Rectangle chartArea = new Rectangle(50, 120, 400, 300);
            if (!chartArea.Contains(e.Location)) return;

            int barWidth = chartArea.Width / _years.Length - 10;
            for (int i = 0; i < _years.Length; i++)
            {
                int x = chartArea.Left + i * (barWidth + 10);
                int barHeight = (int)((_revenues[i] / 300f) * chartArea.Height);
                int y = chartArea.Bottom - barHeight;
                Rectangle barRect = new Rectangle(x, y, barWidth, barHeight);

                if (barRect.Contains(e.Location))
                {
                    MessageBox.Show($"Year: {_years[i]}\nRevenue: {_revenues[i]}", "Data Point Info");
                    break;
                }
            }
        }
    }
}
