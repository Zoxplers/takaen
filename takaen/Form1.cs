namespace takaen
{
    public partial class Form1 : Form
    {
        //Constants
        private const double RESIZEGRIPSIZE = 0.03, TOPBARSIZE = 0.065;
        internal const string TITLE = "TAKAEN";

        //Variables
        private ControlBox controlBox;
        private Controller controller;
        private Rectangle topBar, resizeGrip;
        private Panel mainPanel;
        private int topBarSize;

        //Constructor
        public Form1()
        {
            InitializeComponent();
            controlBox = new ControlBox();
            controller = new Controller();
            mainPanel = new Panel();
        }

        //Functions
        internal int TopBarSize { get => topBarSize; }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form and Control Box
            this.BackColor = Color.AliceBlue;
            this.Size = Screen.FromControl(this).Bounds.Size / 2;
            this.CenterToScreen();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            topBarSize = (int)(this.Height * TOPBARSIZE);
            controlBox.Init(this, topBarSize);

            //Main Panel
            this.Controls.Add(mainPanel);
            controller.Init(mainPanel);
        }

        /// <summary>
        ///  Raises the Paint event.
        ///  Taken from System.Windows.Forms.Form
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            //Variables
            int gripSize = (int)(this.Height * RESIZEGRIPSIZE);
            resizeGrip = new Rectangle(this.Width - gripSize, this.Height - gripSize, gripSize, gripSize);
            topBar = new Rectangle(0, 0, this.Width, topBarSize);
            StringFormat centeredStringFormat = new StringFormat();
            centeredStringFormat.Alignment = StringAlignment.Center;

            //Function
            mainPanel.Location = new Point(gripSize, topBarSize + gripSize);
            mainPanel.Size = new Size(this.Width - gripSize * 2, this.Height - (topBarSize + gripSize * 2));
            e.Graphics.FillRectangle(Brushes.PowderBlue, topBar);
            e.Graphics.DrawString(TITLE, this.Font, Brushes.Black, this.Width / 2, topBarSize * .25f, centeredStringFormat);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, resizeGrip);
            controller.ResizeControls();
        }

        /// <summary>
        ///  Base wndProc encapsulation.
        ///  Taken from System.Windows.Forms.Form
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            //Variables
            bool overriden = false;
            const int WM_NCHITTEST = 0x84;
            const nint HT_BOTTOMRIGHT = 17, HT_CAPTION = 2;

            //Function
            if (m.Msg == WM_NCHITTEST)
            {
                var mouseLoc = this.PointToClient(new Point(m.LParam.ToInt32()));
                if (resizeGrip.Contains(mouseLoc))
                {
                    m.Result = HT_BOTTOMRIGHT;
                    overriden = true;
                }
                else if (topBar.Contains(mouseLoc))
                {
                    m.Result = HT_CAPTION;
                    overriden = true;
                }
            }

            if (!overriden)
            {
                base.WndProc(ref m);
            }
        }
    }
}