using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaInterfaz
{
    public partial class Form1 : Form
    {
        // -----------------------------------------------------------------------------
        // Atributos
        // -----------------------------------------------------------------------------

        // -----------------------------------------------------------------------------
        // Constructor
        // -----------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }

        // -----------------------------------------------------------------------------
        // Métodos
        // -----------------------------------------------------------------------------

        /// <summary>
        /// Minimiza o maximiza el panel de información del cliente cuando se hace
        /// click en el botón correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimizarCliente_Click(object sender, EventArgs e)
        {
            ToolStripButton boton = sender as ToolStripButton;
            
            // Obtener el panel padre del botón. El botón es hijo de una barra de herramientas,
            // que a su vez es hija del panel.
            Control panel = boton.GetCurrentParent().Parent as Control;

            // Se obtiene una referencia al controlador de pestañas asociado al botón.
            // El panel padre tiene una lista de controles: el primer elemento es el 
            // controlador de pestañas, mientrás que el segundo es la barra de herramientas. 
            System.Collections.IEnumerator enumer = panel.Controls.GetEnumerator();
            enumer.MoveNext();
            Control controlPestañas = enumer.Current as Control; 

            
            if (controlPestañas.Visible)
            {
                controlPestañas.Visible = false;
                panel.Height = 27;
                boton.Text = "[+]";
                boton.ToolTipText = "Maximizar";
            }
            else
            {
                controlPestañas.Visible = true;
                panel.Height = 350;
                boton.Text = "[-]";
                boton.ToolTipText = "Minimizar";
            }

        }

        /// <summary>
        /// Minimiza o maximiza el panel de información del cliente cuando se hace
        /// click en el botón correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimizarTarea_Click(object sender, EventArgs e)
        {
            ToolStripButton boton = sender as ToolStripButton;

            // Obtener el panel padre del botón. El botón es hijo de una barra de herramientas,
            // que a su vez es hija del panel.
            Control panel = boton.GetCurrentParent().Parent as Control;

            // Se obtiene una referencia al controlador de pestañas asociado al botón.
            // El panel padre tiene una lista de controles: el primer elemento es el 
            // controlador de pestañas, mientrás que el segundo es la barra de herramientas. 
            System.Collections.IEnumerator enumer = panel.Controls.GetEnumerator();
            enumer.MoveNext();
            Control controlPestañas = enumer.Current as Control;
            Console.WriteLine(controlPestañas.Name);

            /**if (controlPestañas.Visible)
            {
                controlPestañas.Visible = false;
                panel.Height = 27;
                boton.Text = "[+]";
                boton.ToolTipText = "Maximizar";
            }
            else
            {
                controlPestañas.Visible = true;
                panel.Height = 350;
                boton.Text = "[-]";
                boton.ToolTipText = "Minimizar";
            }
            */
        }

        /// <summary>
        /// Cambia el borde de los campos de texto cuando dejan de ser
        /// el componente activo del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_leave(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            textbox.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// Cambia el borde de los campos de texto cuando se convierten
        /// en el componente activo del formulario (o se hace click sobre ellos).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textbox_click(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            textbox.BorderStyle = BorderStyle.Fixed3D;
        }

        /// <summary>
        /// Cambia el estado según el valor seleccionado.
        /// De paso cambia el color de la barra donde aparece su nombre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CambiarEstado_changeText(object sender, EventArgs e)
        {
            ToolStripComboBox comboBox = sender as ToolStripComboBox;
            Control barra = comboBox.GetCurrentParent();

            // Hacer los cambios de color correspondientes:
            if (comboBox.Text == "Urgente")
            {
                barra.BackColor = Color.IndianRed;
                comboBox.BackColor = Color.Salmon;

            }
            else if (comboBox.Text == "Atención")
            {
                barra.BackColor = Color.SandyBrown;
                comboBox.BackColor = Color.PeachPuff;
            }
            else if (comboBox.Text == "Normal")
            {
                barra.BackColor = Color.Linen;
                comboBox.BackColor = Color.Linen;
            }
                    

        }

        /// <summary>
        /// Cambia el estado según el valor seleccionado.
        /// De paso cambia el color de la barra donde aparece su nombre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CambiarEstado_click(object sender, EventArgs e)
        {
            ToolStripButton boton = sender as ToolStripButton;
            Control barra = boton.GetCurrentParent();

            // Hacer los cambios de color correspondientes:
            if (boton.Text == "Urgente")
            {
                barra.BackColor = Color.IndianRed;
                boton.BackColor = Color.Firebrick;

            }
            else if (boton.Text == "Atención")
            {
                barra.BackColor = Color.SandyBrown;
                boton.BackColor = Color.DarkOrange;
            }
            else if (boton.Text == "Normal")
            {
                barra.BackColor = Color.Linen;
                boton.BackColor = Color.LightGray;
            }
        }
    }

}
