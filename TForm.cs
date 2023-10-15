namespace NaidisForm
{
    public partial class TForm : Form
    {
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtC;

        private int scaledSideA;
        private int scaledSideB;
        private int scaledSideC;

        public TForm()
        {
            this.Height = 800;
            this.Width = 600;

            //Triangle t = new Triangle(3, 3, 3);
            //double P = t.Perimeter();
            //double S = t.Surface();

            //TextboxA
            txtA = new TextBox();
            txtA.Location = new Point(50, 50);
            txtA.Size = new Size(100, 20);
            txtA.Text = "A";
            //TextboxB
            txtB = new TextBox();
            txtB.Location = new Point(50, 80);
            txtB.Size = new Size(100, 20);
            txtB.Text = "B";
            //TextboxC
            txtC = new TextBox();
            txtC.Location = new Point(50, 110);
            txtC.Size = new Size(100, 20);
            txtC.Text = "C";
            //Button
            Button drawButton = new Button();
            drawButton.Text = "Kolmnurk";
            drawButton.Location = new Point(50, 140);
                        
            this.Controls.Add(txtA);
            this.Controls.Add(txtB);
            this.Controls.Add(txtC);
            this.Controls.Add(drawButton);

            drawButton.Click += DrawButton_Click;
            this.Paint += TForm_Paint;
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            //Textbox -> Int a,b,c
            if (double.TryParse(txtA.Text, out double sideA) &&
                double.TryParse(txtB.Text, out double sideB) &&
                double.TryParse(txtC.Text, out double sideC))
            {
                // Int a,b,c * 10px joonistamiseks
                const int ScaleFactor = 10;
                scaledSideA = (int)(sideA * ScaleFactor);
                scaledSideB = (int)(sideB * ScaleFactor);
                scaledSideC = (int)(sideC * ScaleFactor);

                // Kontroll: abc sisestatud && a || b || c  1 suurem 
                Triangle triangle = new Triangle(sideA, sideB, sideC);
                if (triangle.ExistTriangle)
                {
                    // Kehtestab juhtelemendi kindla ala ja põhjustab juhtelemendile loosimisteate saatmise.
                    this.Invalidate();
                }
                else
                {
                    MessageBox.Show("Valed kolmnurkade küljed. Palun sisesta õige küljete suurused."); 
                }
            }
            else
            {
                MessageBox.Show("Vale sisestatud info. Palun sisestage numbrid küljedele.");
            }
        }

        private void TForm_Paint(object sender, PaintEventArgs e)
        {
            // Kontroll: suurem kui 0
            if (scaledSideA > 0 && scaledSideB > 0 && scaledSideC > 0)
            {
                Graphics g = e.Graphics;
                Pen pen = new Pen(Color.Black, 2);

                Point vertex1 = new Point(200, 200);
                Point vertex2 = new Point(200 + scaledSideA, 200);
                Point vertex3 = new Point(200 + scaledSideA / 2, 200 - scaledSideC);

                // Joonistame kolmnurka
                g.DrawLine(pen, vertex1, vertex2);
                g.DrawLine(pen, vertex2, vertex3);
                g.DrawLine(pen, vertex3, vertex1);

                pen.Dispose();
                g.Dispose();
            }
        }
    }
}