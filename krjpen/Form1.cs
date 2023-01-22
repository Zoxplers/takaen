namespace krjpen
{
    public partial class Form1 : Form
    {
        //Variables
        private Controller controller;

        public Form1() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "KRJPEN";
            controller = new Controller(this);
        }

        private void Form1_Resize(object sender, EventArgs e) => controller.Resize();
    }
}