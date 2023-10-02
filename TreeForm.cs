using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaidisForm
{
    public partial class TreeForm : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        bool isBTNVIS = false;
        bool isLBLVIS = false;
        public TreeForm()
        {
            this.Height = 600;
            this.Width = 800;
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
            btn.Visible = false;
            lbl.Visible = false;

            tree.Nodes.Add(treeNode);
            this.Controls.Add(lbl);
            this.Controls.Add(btn);
            this.Controls.Add(tree);
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
