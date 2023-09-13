using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Pokemones
{
    public partial class frmAltaPokemon : Form
    {
        private Pokemon pokemon = null;
        public frmAltaPokemon()
        {
            InitializeComponent();
        }
        public frmAltaPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Pokemon poke = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                poke.Numero = int.Parse(txtNumero.Text);
                poke.Nombre = txtNombre.Text;
                poke.UrlImagen = txtUrlImagen.Text;
                poke.Descripcion = txtDescripcion.Text;
                poke.Tipo = (Elemento)cbxTipo.SelectedItem;
                poke.Debilidad = (Elemento)cbxDebilidad.SelectedItem;

                negocio.agregar(poke);
                MessageBox.Show("Agregado exitosamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            try
            {
                cbxTipo.DataSource = elementoNegocio.listar();
                cbxDebilidad.DataSource = elementoNegocio.listar();

                if(pokemon != null)
                {
                    txtNumero.Text = pokemon.Numero.ToString();
                    txtNombre.Text = pokemon.Nombre;                   
                    txtUrlImagen.Text = pokemon.UrlImagen;
                    txtDescripcion.Text = pokemon.Descripcion;
                    cargarImagen(pokemon.UrlImagen);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void tbxUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxUrlImagen.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxUrlImagen.Load("https://c8.alamy.com/compes/2d4r0t4/icono-de-marco-de-fotos-foto-vacia-en-blanco-vector-sobre-fondo-transparente-aislado-eps-10-2d4r0t4.jpg");
            }
        }
    }
}
