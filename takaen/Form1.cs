namespace takaen
{
    public partial class Form1 : Form
    {
        //Constants
        internal const String TITLE = "TAKAEN";

        //Variables
        private Controller controller;

        //Constructor
        public Form1()
        {
            InitializeComponent();
            controller = new Controller();
        }

        //Functions
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = TITLE;
            controller.Init(this);
        }
    }
}