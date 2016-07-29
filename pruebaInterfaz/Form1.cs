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
        /// Minimiza o maximiza una fila.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="tamanio">El tamaño original en pixeles al que debe volver el contenedor cuando se maximiza.</param>
        private void minimizarFila(object sender, EventArgs e, int tamanio)
        {
            ToolStripButton boton = sender as ToolStripButton;

            // Obtener el panel padre del botón. El botón es hijo de una barra de herramientas,
            // que a su vez es hija del panel.
            Control panel = boton.GetCurrentParent().Parent as Control;

            // Se obtiene una referencia al controlador de pestañas asociado al botón.
            // El panel padre tiene una lista de controles: el primer elemento es un contenedor,
            // mientrás que el segundo es la barra de herramientas. 
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
                panel.Height = tamanio;
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
        private void minimizarCliente_Click(object sender, EventArgs e)
        {
            minimizarFila(sender, e, 350);
        }

        /// <summary>
        /// Minimiza o maximiza el panel de información de la tarea cuando se hace
        /// click en el botón correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimizarTarea_Click(object sender, EventArgs e)
        {
            minimizarFila(sender, e, 275);     
        }

        /// <summary>
        /// Minimiza o maximiza el panel de información de la tarea cuando se hace
        /// click en el botón correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimizarContacto_Click(object sender, EventArgs e)
        {
            minimizarFila(sender, e, 190);
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
        /// Cambia el borde de los campos de texto de las barras de 
        /// herramientas cuando dejan de ser el componente activo del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_toolstrip_leave(object sender, EventArgs e)
        {
            ToolStripTextBox textbox = sender as ToolStripTextBox;
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
        /// Cambia el borde de los campos de texto de las barras de herramientas cuando 
        /// se convierten en el componente activo del formulario (o se hace click sobre ellos).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textbox_toolstrip_click(object sender, EventArgs e)
        {
            ToolStripTextBox textbox = sender as ToolStripTextBox;
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
            ToolStrip barra = boton.GetCurrentParent();
            
            // Se utiliza un iterador para recorrer la lista de herramientas de la barra de herramientas.
            // El primer elemento es el botón de minimizar, el segundo es un label con el nombre del
            // cliente, contacto o tarea. El tercero es un label donde aparece el estado actual.
            System.Collections.IEnumerator enumer = barra.Items.GetEnumerator();
            enumer.MoveNext();   // Se para sobre el primer elemento.
            enumer.MoveNext();   // Ahora sobre el segundo.
            enumer.MoveNext();   // ... y ahora sobre el tercero.
            ToolStripItem item = enumer.Current as ToolStripItem;

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
                barra.BackColor = Color.Gainsboro;
                boton.BackColor = Color.LightGray;
            }
            else if (boton.Text == "Finalizada")
            {
                barra.BackColor = Color.OliveDrab;
                boton.BackColor = Color.DarkGreen;
            }

            // El iterador esta parado sobre el tercer item de la barra de herramientas,
            // la cual es el label donde aparece el estado de la tarea.
            item.Text ="("+boton.Text+")";
        }

        /// <summary>
        /// Cambia el estado de una tarea según el valor seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CambiarEstado_tarea(object sender, EventArgs e)
        {
            ToolStripButton boton = sender as ToolStripButton;

            // Obtener el panel padre del botón. El botón es hijo de una barra de herramientas,
            // que a su vez es hija del panel.
            Control panel = boton.GetCurrentParent().Parent as Control;

            // El panel padre tiene una lista de controles: el primer elemento es un splitContainer.
            // El textbox que se quiere modificar se encuentra en el 2 panel de ese split container,
            System.Collections.IEnumerator enumer = panel.Controls.GetEnumerator();
            enumer.MoveNext();
            SplitContainer splitContainer = enumer.Current as SplitContainer;

            SplitterPanel splitpanel = splitContainer.Panel2;
            enumer = splitpanel.Controls.GetEnumerator();
            enumer.MoveNext();
            enumer.MoveNext();       // El groupBox donde se encuentra el texbox.
            Control groupBox = enumer.Current as Control;

            // Recorrer el groupBox, el textbox de interés se encuentra en la segunda posición.
            enumer = groupBox.Controls.GetEnumerator();
            enumer.MoveNext();
            TextBox textBox = enumer.Current as TextBox;
            textBox.Text = boton.Text;

            // Ejecuta el método que cambia el color de la barra.
            CambiarEstado_click(sender, e);
            
        }

        /// <summary>
        /// Actualiza el nombre de la barra de cliente cuando cambia
        /// el nombre en el campo correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_CambiarNombre_Cliente(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            
            // PanelCliente -> TabControl -> TableLayoutResumen -> groupControl -> Textbox
            Control panelCliente = textbox.Parent.Parent.Parent.Parent.Parent;

            // El panel padre tiene una lista de controles: el primer elemento es un contenedor,
            // mientrás que el segundo es la barra de herramientas. 
            System.Collections.IEnumerator enumer = panelCliente.Controls.GetEnumerator();
            enumer.MoveNext();
            enumer.MoveNext();
            ToolStrip barra = enumer.Current as ToolStrip;

            // Se utiliza un iterador para recorrer la lista de herramientas de la barra de herramientas.
            // El primer elemento es el botón de minimizar, el segundo es un label con el nombre del
            // cliente, contacto o tarea. El tercero es un label donde aparece el estado actual.
            enumer = barra.Items.GetEnumerator();
            enumer.MoveNext();   // Se para sobre el primer elemento.
            enumer.MoveNext();   // Ahora sobre el segundo.
            ToolStripItem item = enumer.Current as ToolStripItem;
            item.Text = textbox.Text;
        }

        /// <summary>
        /// Actualiza el nombre de la barra de cliente cuando cambia
        /// el nombre en el campo correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_CambiarNombre_Tarea(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;

            // PanelTarea -> SplitContainer -> SplitterPanel -> groupControl -> Textbox
            Control panelTarea = textbox.Parent.Parent.Parent.Parent;

            // El panel padre tiene una lista de controles: el primer elemento es un contenedor,
            // mientrás que el segundo es la barra de herramientas. 
            System.Collections.IEnumerator enumer = panelTarea.Controls.GetEnumerator();
            enumer.MoveNext();
            enumer.MoveNext();
            ToolStrip barra = enumer.Current as ToolStrip;

            // Se utiliza un iterador para recorrer la lista de herramientas de la barra de herramientas.
            // El primer elemento es el botón de minimizar, el segundo es un label con el nombre del
            // cliente, contacto o tarea. El tercero es un label donde aparece el estado actual.
            enumer = barra.Items.GetEnumerator();
            enumer.MoveNext();   // Se para sobre el primer elemento.
            enumer.MoveNext();   // Ahora sobre el segundo.
            ToolStripItem item = enumer.Current as ToolStripItem;
            item.Text = textbox.Text;
        }
    }

}
