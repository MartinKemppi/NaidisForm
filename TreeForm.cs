﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaidisForm
{
    public partial class TreeForm : Form
    {
        TreeView tree;
        Button btn, btn1;
        Label lbl, lbl1;
        TextBox txt_box, txt_box1;
        RadioButton r1, r2;
        CheckBox c1, c2;
        PictureBox pb;
        ListBox lb;

        bool isBTNVIS = false;
        bool isBTN1VIS = false;
        bool isLBLVIS = false;
        bool isTXTBOXVIS = false;
        bool isRADIOVIS = false;
        bool isCHCVIS = false;
        bool isPBVIS = false;
        bool isLBL1VIS = false;
        bool isLBVIS = false;
        bool isTXTBOX1VIS = false;

        public TreeForm()
        {
            this.Height = 720;
            this.Width = 1280;
            this.Text = "Vorm põhielementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.BorderStyle = BorderStyle.Fixed3D;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode treeNode = new TreeNode("Elemendid");
            //Button
            treeNode.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Height = 50;
            btn.Width = 50;
            btn.Text = "Click";
            btn.Location = new Point(150, 150);
            //this.Controls.Add(btn);
            btn.Click += Btn_Click;
            //Label
            treeNode.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label();
            lbl.Text = "Pealkiri";
            lbl.Location = new Point(tree.Width, 0);
            lbl.Size = new Size(this.Width, btn.Location.Y);
            lbl.BackColor = Color.White;
            lbl.BorderStyle = BorderStyle.Fixed3D;
            lbl.Font = new Font("Tahoma", 24);
            //Label1
            lbl1 = new Label();
            lbl1.Text = "";
            lbl1.Location = new Point(this.Width - 250,this.Height - 200);
            lbl1.Size = new Size(200,50);
            lbl1.BackColor = Color.White;
            lbl1.BorderStyle = BorderStyle.Fixed3D;
            lbl1.Font = new Font("Times New Roman", 12);
            //Tekstkast
            treeNode.Nodes.Add(new TreeNode("Tekstkast-Textbox"));
            txt_box= new TextBox();
            txt_box.BorderStyle = BorderStyle.Fixed3D;
            txt_box.Height = 50;
            txt_box.Width = 100;
            txt_box.Text = "...";
            txt_box.Location = new Point(tree.Width, btn.Top + btn.Height);           
            //Radiobutton
            treeNode.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            r1= new RadioButton();
            r1.Text= "Valik 1";
            r1.Location = new Point(tree.Width, txt_box.Location.Y + txt_box.Height);
            r2= new RadioButton();
            r2.Text = "Valik 2";
            r2.Location = new Point(r1.Location.X+r1.Width, r1.Location.Y);
            //CheckBox
            treeNode.Nodes.Add(new TreeNode("CheckBoxnupp-CheckBox"));
            c1= new CheckBox();            
            c1.Text = "Valik 1";
            c1.Location = new Point(tree.Width, r2.Location.Y+ r1.Height);
            c2 = new CheckBox();
            c2.Text = "Valik 2";
            c2.Location = new Point(tree.Width + c1.Width, r1.Location.Y+r1.Height);
            //PicutreBox
            treeNode.Nodes.Add(new TreeNode("PictureBoxnupp-PictureBox"));
            pb = new PictureBox();
            pb.Location = new Point(tree.Width, c2.Location.Y + c2.Height);
            pb.Image =new Bitmap("../../../duck.png");
            pb.Size = new Size(100,100);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle= BorderStyle.Fixed3D;
            //Loetelu
            treeNode.Nodes.Add(new TreeNode("ListBoxnupp-ListBox"));
            lb = new ListBox();
            lb.Items.Add("Roheline");
            lb.Items.Add("Sinine");
            lb.Items.Add("Hall");
            lb.Items.Add("Kollane");
            lb.Location = new Point(tree.Width, pb.Location.Y + pb.Height);
            this.Controls.Add(lb);
            //Tekstkast1
            treeNode.Nodes.Add(new TreeNode("Tekstkast_ListboxLisamisele-Textbox"));
            txt_box1 = new TextBox();
            txt_box1.BorderStyle = BorderStyle.Fixed3D;
            txt_box1.Height = 50;
            txt_box1.Width = 100;
            txt_box1.Text = "...";
            txt_box1.Location = new Point(tree.Width, lb.Location.Y + lb.Height);
            //Button1
            treeNode.Nodes.Add(new TreeNode("Nupp-Button1"));
            btn1 = new Button();
            btn1.Height = 50;
            btn1.Width = 80;
            btn1.Text = "Kustuta";
            btn1.Location = new Point(tree.Width, txt_box1.Location.Y + txt_box1.Height);
            btn1.Click += Btn_Click1;
            //Data
            treeNode.Nodes.Add(new TreeNode("DataGridView"));
            DataSet ds = new DataSet("XML fail. Menyy");
            ds.ReadXml(@"..\..\..\breakfast.xml");
            DataGridView dg = new DataGridView();
            dg.Location = new Point(tree.Width + pb.Width + 50, pb.Location.Y);
            //dg.Height = 200;
            //dg.Width = 820;
            dg.DataSource = ds;
            dg.AutoGenerateColumns= true;
            dg.DataMember= "food";
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dg.AutoSize = true;

            treeNode.Nodes.Add(new TreeNode("Kolmnurk"));


            btn.Visible = false;
            lbl.Visible = false;
            txt_box.Visible = false;
            r1.Visible = false;
            r2.Visible = false;
            c1.Visible = false;
            c2.Visible = false;
            pb.Visible = false;
            lbl1.Visible = false;
            lb.Visible = false;
            txt_box1.Visible = false;
            btn1.Visible = false;

            tree.Nodes.Add(treeNode);
            this.Controls.Add(lbl);
            this.Controls.Add(lbl1);
            this.Controls.Add(btn);
            this.Controls.Add(tree);
            this.Controls.Add(txt_box);
            this.Controls.Add(r1);
            this.Controls.Add(r2);
            this.Controls.Add(c1);
            this.Controls.Add(c2);
            this.Controls.Add(pb);
            this.Controls.Add(txt_box1);
            this.Controls.Add(btn1);
            this.Controls.Add(dg);

            r1.CheckedChanged += new EventHandler(RadioButtons_Changed);
            r2.CheckedChanged += new EventHandler(RadioButtons_Changed);

            c1.CheckedChanged += new EventHandler(CheckboxButtons_Changed);
            c2.CheckedChanged += new EventHandler(CheckboxButtons_Changed);

            txt_box.KeyDown += new KeyEventHandler(Txt_box_KeyDown);
            txt_box1.KeyDown += new KeyEventHandler(Txt_box1_KeyDown);
        }

        private void Txt_box_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                DialogResult result = MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    txt_box.Enabled = false;
                    isLBL1VIS = !isLBL1VIS;
                    lbl1.Visible = isBTNVIS;
                    lbl1.Text = txt_box.Text;
                } 
                else
                {
                    string tekst = Interaction.InputBox("Sisesta pealkiri", "Pealkiri Muutmine", "Uus pealkiri");
                    if (tekst.Length > 0)
                    {
                        txt_box.Enabled = false;
                        isLBL1VIS = !isLBL1VIS;
                        lbl1.Visible = isBTNVIS;
                        lbl1.Text = txt_box.Text;
                    }
                }
            }
        }

        private void Txt_box1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult result = MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes && !lb.Items.Contains(result))
                {
                    lb.Items.Add(txt_box1.Text);
                }
                else if(result == DialogResult.No)
                {
                    txt_box1.Text = null;
                }                                   
                else
                {
                    string tekst = Interaction.InputBox("Sisesta pealkiri", "Pealkiri Muutmine", "Uus pealkiri");
                    if (tekst.Length > 0 && !lb.Items.Contains(tekst))
                    {
                        lb.Items.Add(txt_box1.Text);
                    }
                }
            }
        }

        private void RadioButtons_Changed(object? sender, EventArgs e)
        {
            if(r1.Checked)
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
                btn.ForeColor= Color.Black;
                lbl.ForeColor = Color.Black;
                
            }
            else if(r2.Checked)
            {
                this.BackColor = Color.Black;
                this.ForeColor = Color.White;
                btn.ForeColor = Color.White;
                lbl.ForeColor = Color.Black;
            }
        }

        private void Btn_Click1(object? sender, EventArgs e)
        {
            if (lb.SelectedItem != null)
            {
                lb.Items.Remove(lb.SelectedItem);
            }
        }

        private void CheckboxButtons_Changed(object? sender, EventArgs e)
        {
            if(c1.Checked)
            {
                this.BackColor = Color.Orange;
            }
            else if(c2.Checked)
            {
                this.BackColor = Color.Cyan;
            }
            else if(c1.Checked && c2.Checked)
            {
                this.BackColor = Color.Gold;
            }
        }
        
        private void Btn_MouseLeave(object? sender, EventArgs e)
        {
            this.BackColor = Color.CornflowerBlue;
        }

        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                tree.SelectedNode = null;
                isBTNVIS = !isBTNVIS;
                btn.Visible = isBTNVIS;                    

            }
            else if(e.Node.Text == "Silt-Label")
            {
                tree.SelectedNode = null;
                isLBLVIS = !isLBLVIS;
                lbl.Visible = isLBLVIS;
            }
            else if (e.Node.Text == "Tekstkast-Textbox")
            {
                tree.SelectedNode = null;
                isTXTBOXVIS = !isTXTBOXVIS;
                txt_box.Visible = isTXTBOXVIS;
            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                tree.SelectedNode = null;
                isRADIOVIS = !isRADIOVIS;
                r1.Visible = isRADIOVIS;
                r2.Visible = isRADIOVIS;
            }
            else if (e.Node.Text == "CheckBoxnupp-CheckBox")
            {
                tree.SelectedNode = null;
                isCHCVIS = !isCHCVIS;
                c1.Visible = isCHCVIS;
                c2.Visible = isCHCVIS;
            }
            else if (e.Node.Text == "PictureBoxnupp-PictureBox")
            {
                tree.SelectedNode = null;
                isPBVIS = !isPBVIS;
                pb.Visible = isPBVIS;
            }
            else if (e.Node.Text == "ListBoxnupp-ListBox")
            {
                tree.SelectedNode = null;
                isLBVIS = !isLBVIS;
                lb.Visible = isLBVIS;
            }
            else if (e.Node.Text == "Tekstkast_ListboxLisamisele-Textbox")
            {
                tree.SelectedNode = null;
                isTXTBOX1VIS = !isTXTBOX1VIS;
                txt_box1.Visible = isTXTBOX1VIS;
            }
            if (e.Node.Text == "Nupp-Button1")
            {
                tree.SelectedNode = null;
                isBTN1VIS = !isBTN1VIS;
                btn1.Visible = isBTN1VIS;

            }
            if (e.Node.Text == "Kolmnurk")
            {
                tree.SelectedNode = null;
                TForm form = new TForm();
                form.Show(); // or form.ShowDialog(this);
            }           
        }

        private void Btn_Click(object? sender, EventArgs e)
        {            
            if(btn.BackColor == Color.Aqua)
            {
                btn.BackColor = Color.Crimson;
            }
            else
            {
                btn.BackColor = Color.Aqua;
            }           
        }        
    }
}
