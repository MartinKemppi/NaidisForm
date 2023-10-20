using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaidisForm
{
    public partial class KolmnurkForm : Form
    {
        Label lbl;
        ListView listView1;
        TextBox txtA, txtB, txtC, txtK1, txtK2;
        Button btn1, clearBtn, Ebtn, btnAA;
        PictureBox pictureBox1;
        Graphics graphics;
        Pen pen;

        public KolmnurkForm()
        {
            this.Height = 720;
            this.Width = 1280;

            // ListView
            listView1 = new ListView();
            listView1.View = View.Details;
            listView1.Columns.Add("Tüübid", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Andmed", -2, HorizontalAlignment.Left);
            listView1.Height = 250;
            listView1.Width = 350;
            listView1.Location = new Point(50, 250);

            // Button
            btn1 = new Button();
            btn1.Height = 72;
            btn1.Width = 50;
            btn1.Text = "Click";
            btn1.Location = new Point(150, 50);
            btn1.Click += Run_button_Click;

            //Label
            lbl = new Label();
            lbl.Text = "Kolmnurka joonistamine";
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Location = new Point(0, 0);
            lbl.Size = new Size(this.Width, btn1.Location.Y);
            lbl.BackColor = Color.White;
            lbl.BorderStyle = BorderStyle.Fixed3D;
            lbl.Font = new Font("Times New Roman", 24);

            // TextBox A
            txtA = new TextBox();
            txtA.BorderStyle = BorderStyle.Fixed3D;
            txtA.Height = 50;
            txtA.Width = 100;
            txtA.Location = new Point(50, 50);
            txtA.PlaceholderText = "Sisesta A külje";

            // TextBox B
            txtB = new TextBox();
            txtB.BorderStyle = BorderStyle.Fixed3D;
            txtB.Height = 50;
            txtB.Width = 100;
            txtB.Location = new Point(50,txtA.Location.Y + txtA.Height);
            txtB.PlaceholderText = "Sisesta B külje";

            // TextBox C
            txtC = new TextBox();
            txtC.BorderStyle = BorderStyle.Fixed3D;
            txtC.Height = 50;
            txtC.Width = 100;
            txtC.Location = new Point(50, txtB.Location.Y + txtB.Height);
            txtC.PlaceholderText = "Sisesta C külje";

            // TextBox 1K
            txtK1 = new TextBox();
            txtK1.BorderStyle = BorderStyle.Fixed3D;
            txtK1.Height = 50;
            txtK1.Width = 150;
            txtK1.Location = new Point(50, txtC.Location.Y + txtC.Height + 50);
            txtK1.PlaceholderText = "Esimene külje suurus";

            // TextBox 2K
            txtK2 = new TextBox();
            txtK2.BorderStyle = BorderStyle.Fixed3D;
            txtK2.Height = 50;
            txtK2.Width = 150;
            txtK2.Location = new Point(50, txtK1.Location.Y + txtK1.Height + txtK1.Height);
            txtK2.PlaceholderText = "Teine külje suurus";

            // Arvuta Button
            btnAA = new Button();
            btnAA.Height = 72;
            btnAA.Width = 50;
            btnAA.Text = "Arvuta";
            btnAA.Location = new Point(txtK1.Location.X + txtK1.Width, txtK1.Location.Y);
            btnAA.Click += ArvutaButton_Click;

            // Clear Button
            clearBtn = new Button();
            clearBtn.Height = 72;
            clearBtn.Width = 50;
            clearBtn.Text = "Clear";
            clearBtn.Location = new Point(btn1.Location.X + btn1.Width, btn1.Top);
            clearBtn.Click += ClearButton_Click;

            // Exit Button
            Ebtn = new Button();
            Ebtn.Height = 72;
            Ebtn.Width = 50;
            Ebtn.Text = "Välja";
            Ebtn.Location = new Point(clearBtn.Location.X + clearBtn.Width, clearBtn.Top);
            Ebtn.Click += ExitButton_Click;

            this.Controls.Add(lbl);
            this.Controls.Add(btn1);
            this.Controls.Add(clearBtn);
            this.Controls.Add(txtA);
            this.Controls.Add(txtB);
            this.Controls.Add(txtC);
            this.Controls.Add(listView1);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(Ebtn);
            this.Controls.Add(txtK1);
            this.Controls.Add(txtK2);
            this.Controls.Add(btnAA);

            this.BackColor = System.Drawing.Color.Turquoise;
        }

        private void Run_button_Click(object sender, EventArgs e)
        {
            double a, b, c;
            a = Convert.ToDouble(txtA.Text);
            b = Convert.ToDouble(txtB.Text);
            c = Convert.ToDouble(txtC.Text);

            Triangle triangle = new Triangle(a, b, c);
            AddListViewItem("A külg", triangle.outputA());
            AddListViewItem("B külg", triangle.outputB());
            AddListViewItem("C külg", triangle.outputC());
            AddListViewItem("Ümbermõõt", triangle.Perimeter().ToString());
            AddListViewItem("Pindala", triangle.Surface().ToString());
            AddListViewItem("Mediaan", triangle.Median().ToString());
            AddListViewItem("Kõrgus", triangle.Height().ToString());
            AddListViewItem("Joonistatud?", triangle.ExistTriangle ? "Jah" : "Ei");
            AddListViewItem("Tüüp", triangle.CheckTriangleType());            

            double pointA, pointB, pointC;
            if (double.TryParse(txtA.Text, out pointA) && double.TryParse(txtB.Text, out pointB) && double.TryParse(txtC.Text, out pointC))
            {
                if (pointA + pointB > pointC && pointA + pointC > pointB && pointB + pointC > pointA)
                {
                    double centerX = 500;
                    double centerY = 250;

                    double angleA = 0;
                    double angleB = Math.Acos((pointA * pointA + pointC * pointC - pointB * pointB) / (2 * pointA * pointC));
                    double angleC = Math.Acos((pointA * pointA + pointB * pointB - pointC * pointC) / (2 * pointA * pointB));

                    double xA = centerX + pointA * Math.Cos(angleA);
                    double yA = centerY - pointA * Math.Sin(angleA);

                    double xB = centerX + pointB * Math.Cos(Math.PI - angleB);
                    double yB = centerY - pointB * Math.Sin(Math.PI - angleB);

                    double xC = centerX + pointC * Math.Cos(Math.PI - angleC);
                    double yC = centerY - pointC * Math.Sin(Math.PI - angleC);

                    graphics = CreateGraphics();
                    pen = new Pen(Color.Black);
                    graphics.DrawLine(pen, (float)xA, (float)yA, (float)xB, (float)yB);
                    graphics.DrawLine(pen, (float)xB, (float)yB, (float)xC, (float)yC);
                    graphics.DrawLine(pen, (float)xC, (float)yC, (float)xA, (float)yA);
                }
                else
                {
                    MessageBox.Show("Sisestatud andmetega pole sellist kolmnurka");
                }
            }
            else
            {
                MessageBox.Show("Palun sisestage õiged andmed kolmkurkadele");
            }
        }

        private void AddListViewItem(string attribute, string value)
        {
            ListViewItem item = new ListViewItem(attribute);
            item.SubItems.Add(value);
            listView1.Items.Add(item);
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                listView1.Items.Clear();
                Invalidate();
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ArvutaButton_Click(object sender, EventArgs e)
        {
            double a, b, c;

            a = Convert.ToDouble(txtK1.Text);
            b = Convert.ToDouble(txtK2.Text);
            c.GetKolm();
        }
    }
}