using System;
using System.IO;
using System.Windows.Forms;

namespace AppMultifuncional
{
    public class EditorTexto : Form
    {
        private TextBox txtContenido;

        public EditorTexto()
        {
            Text = "Editor de Texto";
            Size = new System.Drawing.Size(600, 400);

            MenuStrip menu = new MenuStrip();
            ToolStripMenuItem archivoMenu = new ToolStripMenuItem("Archivo");
            ToolStripMenuItem abrirItem = new ToolStripMenuItem("Abrir", null, Abrir_Click);
            ToolStripMenuItem guardarItem = new ToolStripMenuItem("Guardar Como...", null, Guardar_Click);

            archivoMenu.DropDownItems.Add(abrirItem);
            archivoMenu.DropDownItems.Add(guardarItem);
            menu.Items.Add(archivoMenu);

            txtContenido = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ScrollBars = ScrollBars.Both
            };

            Controls.Add(txtContenido);
            Controls.Add(menu);
            MainMenuStrip = menu;
        }

        private void Abrir_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    txtContenido.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "Archivos de texto (*.txt)|*.txt" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sfd.FileName, txtContenido.Text);
            }
        }
    }
}