using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace Step3_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 첫번째 TreeView 아이템 - 서버
            TreeNode svrNode = new TreeNode("서버");
            svrNode.Nodes.Add("SE", "서울 서버", 0, 0);
            svrNode.Nodes.Add("DJ", "대전 서버", 0, 0);
            svrNode.Nodes.Add("BS", "부산 서버", 0, 0);

            // 두번째 TreeView 아이템 - 네트웍
            TreeNode netNode = new TreeNode("네트웍");
            netNode.Nodes.Add("T1", "T1 케이블", 1, 1);
            netNode.Nodes.Add("T1", "56K 모뎀", 1, 1);
            netNode.Nodes.Add("3G", "3G 무선", 1, 1);

            foreach (TreeNode node in netNode.Nodes.Find("T1", true))
                Console.WriteLine(node);

            // 2개의 노드를 TreeView에 추가
            treeView1.Nodes.Add(svrNode);
            treeView1.Nodes.Add(netNode);

            // 모든 트리 노드를 보여준다
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodeKey = e.Node.Name;
            if (!string.IsNullOrEmpty(nodeKey))
            {
                MessageBox.Show("선택된 노드 키 : " + nodeKey);
            }
        }
    }
}
