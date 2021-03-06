﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            raisePropChkbox.Checked = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var length = textBox1.Lines.Count();
                MessageBox.Show(length.ToString() + " Properties need to created");
                string PrivatePropertyString = string.Empty;
                string PublicPropertyString = string.Empty;
                for (int i = 0; i < length; i++)
                {
                    var currertLine = textBox1.Lines[i].Trim();
                    if (!string.IsNullOrEmpty(currertLine))
                    {
                        if (!currertLine.Contains(":") || !currertLine.Contains("\""))
                        {
                            if (currertLine.Contains("public") || currertLine.Contains("private"))
                            {
                                string[] ssize = currertLine.Split(new char[0]);
                                string propertyName = "_" + ssize[2].Replace(ssize[2][0], ssize[2][0].ToString().ToLower()[0]);
                                PrivatePropertyString += "private " + ssize[1] + " " + propertyName + "; \r\n";
                                PublicPropertyString += "\r\n public " + ssize[1] + " " + ssize[2] + "\r\n";
                                PublicPropertyString += "{ \r\n" + "get { return " + propertyName + " ;}" + "\r\n";
                                PublicPropertyString += "set \r\n {" + "\r\n";
                                if (NullCheckBox.Checked)
                                {
                                    PublicPropertyString += " if (" + propertyName + "!= value)" + "\r\n {";
                                }
                                PublicPropertyString += propertyName + "= value;" + "\r\n" + (raisePropChkbox.Checked ? "RaisePropertyChanged();" + "\r\n" : "");
                                if (NullCheckBox.Checked)
                                {
                                    PublicPropertyString += "} \r\n ";
                                }
                                PublicPropertyString += "} \r\n }";
                            }
                            else
                            {
                                string[] ssize = currertLine.Split(new char[0]);
                                string propertyName = "_" + ssize[1].Replace(ssize[1][0], ssize[1][0].ToString().ToLower()[0]);
                                PrivatePropertyString += "private " + ssize[0] + " " + propertyName + "; \r\n";
                                PublicPropertyString += "\r\n public " + ssize[0] + " " + ssize[1] + "\r\n";
                                PublicPropertyString += "{ \r\n" + "get { return " + propertyName + " ;}" + "\r\n";
                                PublicPropertyString += "set \r\n {" + "\r\n";
                                if (NullCheckBox.Checked)
                                {
                                    PublicPropertyString += " if (" + propertyName + "!= value)" + "\r\n {";
                                }
                                PublicPropertyString += propertyName + "= value;" + "\r\n" + (raisePropChkbox.Checked ? "RaisePropertyChanged();" + "\r\n" : "");
                                if (NullCheckBox.Checked)
                                {
                                    PublicPropertyString += "} \r\n ";
                                }
                                PublicPropertyString += "} \r\n }";
                            }
                        }
                    }
                }
                var finalString = PrivatePropertyString + "\r\n" + "/////////////////////////////////public properties by Avnish's property generator utility////////////////////////" + "\r\n" + PublicPropertyString;
                textBox2.Text = finalString;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Encounter some error " + ex.Message);
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
