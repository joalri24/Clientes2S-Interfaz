﻿using System;
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
        private void minimizarFila_Click(object sender, EventArgs e)
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
                panel.Height = 300;
                boton.Text = "[-]";
                boton.ToolTipText = "Minimizar";
            }

        }

        private void textBox_leave(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            textbox.BorderStyle = BorderStyle.None;
        }

        private void textbox_click(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            textbox.BorderStyle = BorderStyle.Fixed3D;
        }
    }

}
