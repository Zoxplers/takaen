using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krjpen
{
    internal class Controller
    {
        //Variables
        private Form form;
        private MenuStripHandler menuStrip;
        private ResetButtonHandler resetButton;
        private PanelHandler initPanel, mainPanel, examplesPanel;

        //Constructor
        public Controller(Form form)
        {
            this.form = form;
            menuStrip = new MenuStripHandler();
            initPanel = new PanelHandler();
            mainPanel = new PanelHandler();
            examplesPanel = new PanelHandler();
            resetButton = new ResetButtonHandler(this);

            form.Controls.Add(menuStrip.MenuStrip);
            form.Controls.Add(mainPanel.Panel);
            form.Controls.Add(examplesPanel.Panel);
            menuStrip.MenuStrip.Items.Add(resetButton.ToolStripMenuItem);
            resetButton.ToolStripMenuItem.Text = "Reset";
            Resize();
            resetButton.ToolStripMenuItem.PerformClick();
        }

        //Functions
        internal PanelHandler InitPanel => initPanel;

        public void Resize()
        {
            //Size
            initPanel.Panel.Size = new Size(form.ClientRectangle.Width, form.ClientRectangle.Height - menuStrip.MenuStrip.Size.Height);
            mainPanel.Panel.Size = new Size(form.ClientRectangle.Width, (form.ClientRectangle.Height - menuStrip.MenuStrip.Size.Height) * 2 / 3);
            examplesPanel.Panel.Size = new Size(form.ClientRectangle.Width, (form.ClientRectangle.Height - menuStrip.MenuStrip.Size.Height) / 3);

            //Location
            initPanel.Panel.Location = new Point(0, menuStrip.MenuStrip.Size.Height);
            mainPanel.Panel.Location = new Point(0, menuStrip.MenuStrip.Size.Height);
            examplesPanel.Panel.Location = new Point(0, mainPanel.Panel.Location.Y + mainPanel.Panel.Size.Height);
        }

        internal void HidePanels()
        {
            foreach(Control control in form.Controls)
            {
                control.Visible = false;
                control.Enabled = false;
            }
            menuStrip.MenuStrip.Visible = true;
            menuStrip.MenuStrip.Enabled = true;
        }
    }
}
