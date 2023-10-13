namespace NaidisForm
{
    public partial class TForm : Form
    {

        public TForm()
        {
            this.Height = 800;
            this.Width = 600;
            Triangle t = new Triangle(3, 3, 3);
            double P = t.Perimeter();
            double S = t.Surface();
        }        
    }
}