namespace Arboles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Dato = 0;
        int cont = 0;

        Arbol_Binario mi_Arbol = new Arbol_Binario(null);

        Graphics g;

        private void Form1_Paint(object sender, PaintEventArgs en)
        {
            en.Graphics.Clear(this.BackColor);
            en.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            en.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g = en.Graphics;
            mi_Arbol.DibujarArbol(g, this.Font, Brushes.Blue, Brushes.White, Pens.Black, Brushes.White);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtDato.Text == "")
            {
                MessageBox.Show("Ingresa un valor");
            }
            else
            {
                Dato = int.Parse(txtDato.Text);
                if (Dato <= 0 || Dato >= 100)
                    MessageBox.Show("Solo se recibe valores desde 1 hasta 99");
                else
                {
                    mi_Arbol.insertar(Dato);
                    txtDato.Clear();
                    txtDato.Focus();

                    cont++;

                    Refresh();
                    Refresh();
                }

            }
        }
    }
}
