namespace takaen
{
    internal class ControlBox
    {
        //Constants
        internal const float PIXELTOEMRATIO = 2.8f;

        //Variables
        private Button closeButton, minimizeButton;

        //Constructor
        internal ControlBox()
        {
            closeButton = new Button();
            minimizeButton = new Button();
        }

        //Functions
        internal void Init(Form1 form, int topBarSize)
        {
            form.Font = new Font(FontFamily.GenericSansSerif, topBarSize / PIXELTOEMRATIO);

            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeButton.BackColor = Color.Azure;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font(FontFamily.GenericSerif, topBarSize / PIXELTOEMRATIO);
            closeButton.Location = new Point(form.Width-topBarSize, 0);
            closeButton.Size = new Size(topBarSize, topBarSize);
            closeButton.TextAlign = ContentAlignment.MiddleCenter;
            closeButton.Text = "🗙";
            closeButton.Click += CloseButton_Click;

            minimizeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            minimizeButton.BackColor = Color.Azure;
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.Font = new Font(FontFamily.GenericSerif, topBarSize / PIXELTOEMRATIO);
            minimizeButton.Location = new Point(form.Width - topBarSize * 2, 0);
            minimizeButton.Size = new Size(topBarSize, topBarSize);
            minimizeButton.TextAlign = ContentAlignment.MiddleCenter;
            minimizeButton.Text = "🗕";
            minimizeButton.Click += MinimizeButton_Click;

            form.Controls.Add(closeButton);
            form.Controls.Add(minimizeButton);
        }

        private void CloseButton_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeButton_Click(object? sender, EventArgs e)
        {
            closeButton.FindForm()!.WindowState = FormWindowState.Minimized;
        }
    }
}