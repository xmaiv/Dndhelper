
﻿using System;
using System.Windows.Forms;

namespace BlockChain
{
    public partial class Form1 : Form
    {
        private Chain chain;

        public Form1()
        {
            InitializeComponent();

            chain = new Chain();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            blocksListBox.Items.Clear();

            chain.Add(dataTextBox.Text, userTextBox.Text);
            blocksListBox.Items.AddRange(chain.Blocks.ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            blocksListBox.Items.AddRange(chain.Blocks.ToArray());
        }
    }
}