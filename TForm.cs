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
    public partial class TForm : Form
    {
        ListView listView1;
        TextBox txtA, txtB, txtC;
        Button btn1, clearBtn;
        PictureBox pictureBox1;
        Graphics graphics;
        Pen pen;

        public TForm()
        {
            this.Height = 720;
            this.Width = 1280;

            // Initialize ListView
            listView1 = new ListView();
            listView1.View = View.Details;
            listView1.Columns.Add("Attribute", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Value", -2, HorizontalAlignment.Left);

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

            // Clear Button
            clearBtn = new Button();
            clearBtn.Height = 72;
            clearBtn.Width = 50;
            clearBtn.Text = "Clear";
            clearBtn.Location = new Point(btn1.Location.X + btn1.Width, btn1.Top);
            clearBtn.Click += ClearButton_Click;

            this.Controls.Add(btn1);
            this.Controls.Add(clearBtn);
            this.Controls.Add(txtA);
            this.Controls.Add(txtB);
            this.Controls.Add(txtC);
            this.Controls.Add(listView1);
            this.Controls.Add(pictureBox1);
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
    }
}