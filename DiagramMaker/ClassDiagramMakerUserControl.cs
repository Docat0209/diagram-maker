﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramMaker
{
    public partial class ClassDiagramMakerUserControl : UserControl
    {
        private int _canva_id;
        public ClassDiagramMakerUserControl(int canva_id)
        {
            InitializeComponent();
            _canva_id = canva_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClassForm addClassForm = new AddClassForm(_canva_id);
            addClassForm.ShowDialog();
        }
    }
}
