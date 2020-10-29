﻿using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormNet48
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            this.InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var work = Program.ServiceProvider.GetRequiredService<Worker>();
            Console.WriteLine(work.Get());
        }
    }
}