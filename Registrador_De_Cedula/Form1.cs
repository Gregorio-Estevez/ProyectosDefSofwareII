using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registrador_De_Cedula
{
    public partial class indexForm : Form
    {
        List<model> lista = new List<model>();
        public indexForm()
        {
            InitializeComponent();
        }

        private void crearBTN_Click(object sender, EventArgs e)
        {
            dataVIEW.Visible = false;
            dataVIEW.Enabled = false;

            cajaBOX.Enabled = true;
            cajaBOX.Visible = true;
            guardarBTN.Enabled = true;


        }

        private void limpiarBTN_Click(object sender, EventArgs e)
        {
            nombreTXT.Clear();
            masculinoBTN.Checked = false;
            femeninoBTN.Checked = false;
            nacionalidadTXT.Clear();
            lugarNaciTXT.Clear();
            estadoCB.Text = "";
            sangreCB.Text = "";
            IDTXT.Clear();
            fotoPC.Image = null;
        }

        private void limpiar()
        {
            nombreTXT.Clear();
            masculinoBTN.Checked = false;
            femeninoBTN.Checked = false;
            nacionalidadTXT.Clear();
            lugarNaciTXT.Clear();
            estadoCB.Text = "";
            sangreCB.Text = "";
            IDTXT.Clear();
            fotoPC.Image = null;
        }

        private void fotoBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fotoPC.Image = new Bitmap(ofd.FileName);
            }
                
        }

        private void verBTN_Click(object sender, EventArgs e)
        {
            cajaBOX.Visible = false;
            cajaBOX.Enabled = false;
            guardarBTN.Enabled = false;

            dataVIEW.Location = new Point(16, 215);
            dataVIEW.Visible = true;
            dataVIEW.Enabled = true;
            
        }

        public void guardar()
        {
            
            var models = new model { 
            
                nombre = nombreTXT.Text,
                genero = masculinoBTN.Checked ? "Masculino" : "Femenino",
                fechaNacimiento = nacimientoDP.Value,
                nacionaliadad = nacionalidadTXT.Text,
                id = IDTXT.Text,
                lugarNacimiento = lugarNaciTXT.Text,
                estado = estadoCB.Text,
                sangre = sangreCB.Text,
                fechaExpiracion = expiracionDP.Value,
            };

            lista.Add(models);

            MessageBox.Show("Se guardo la cedula");
            
            cajaBOX.Visible = false;
            cajaBOX.Enabled = false;

            limpiar();
            guardarBTN.Enabled = false;
            agregados();
        }

        public void agregados()
        {
            dataVIEW.DataSource = null;
            dataVIEW.DataSource = lista;
        }

        public class model
        {
            public string nombre { get; set; }
            public string genero { get; set; }
            public string id { get; set; }
            public string lugarNacimiento { get; set; }
            public string nacionaliadad { get; set; }
            public DateTime fechaNacimiento { get; set; }
            public string sangre { get; set; }
            public string estado { get; set; }
            public DateTime fechaExpiracion { get; set; }      

        }

        private void guardarBTN_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void fotoPC_Click(object sender, EventArgs e)
        {

        }
    }
}
