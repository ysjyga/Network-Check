﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Check
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Initializedataitem();
        }
        public string[] Initializedataitem()
        {
            string[] url_item;
            string file = INIOperation.IniFilePath("Setting.ini");

            // INIOperation.INIWriteItems(file, "Menu", "File=文件\0View=视图\0Edit=编辑");
           string[] url_item1 = INIOperation.INIGetAllItems(file, "Url_list");
           if (url_item1.Length>0) { 
                url_item = url_item1;
            }
            else {
                //string[] url_item = { "http://shenbao.sc-n-tax.gov.cn", "http://shenbao2.sc-n-tax.gov.cn", "http://118.190.70.105:11110", "http://118.190.88.24:11110", "http://121.42.252.78:11110", "http://115.25.252.255:11110", "http://t0004.shujet.com:11110", "http://118.190.70.105:58176", "http://118.190.88.24:58176", "http://121.42.252.78:58176", "http://115.25.252.255:58176", "http://t0004.shujet.com:58176" };
                string[] url_item2 = { "http://shenbao.sc-n-tax.gov.cn", "http://shenbao2.sc-n-tax.gov.cn", "http://118.190.70.105:11110", "http://121.42.252.78:11110", "http://t0004.shujet.com:11110", "http://118.190.88.24:58176", "http://t0004.shujet.com:58176" };
                url_item = url_item2;
            }            
            for (int i = 0; i < url_item.Length; i++)
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = url_item[i];
            }
            return url_item;
        }
        private void Button1_Click(object sender, EventArgs e)
        {            
            button1.Text= "正在检测";
            button1.Enabled = false;
            string host, hostitem;
            string[] url_item = Initializedataitem();
            dataGridView1.Rows.Clear();
            int port = 80;
            for (int i=0;i< url_item.Length; i++) {
               if (url_item[i]!="") {
                    hostitem = url_item[i].Replace("http://", "");
                    string[] hostitem_ = hostitem.Split(':');
                    host = hostitem_[0];        
                    if (hostitem_.Length>1)
                    {
                        port = int.Parse(hostitem_[1]);
                    }
                    Call_Ping cp = new Call_Ping();
                    string RoundtripTime=cp.CallPing(host);

                    Call_Telnet ct = new Call_Telnet();
                    string r_tel= ct.CallTelnet(host, port);

                    int  index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = url_item[i];                    
                    this.dataGridView1.Rows[index].Cells[1].Value = RoundtripTime;
                    if ("超时".Equals(RoundtripTime))
                    {
                        this.dataGridView1.Rows[index].Cells[1].Style.ForeColor = Color.Red;
                    }
                    else {
                        this.dataGridView1.Rows[index].Cells[1].Style.ForeColor = Color.Green;
                    }
                    this.dataGridView1.Rows[index].Cells[2].Value = r_tel;
                    if ("通畅".Equals(r_tel))
                    {
                        this.dataGridView1.Rows[index].Cells[2].Style.ForeColor = Color.Green;
                    }
                    else {
                        this.dataGridView1.Rows[index].Cells[2].Style.ForeColor = Color.Red;
                    }
               }
                dataGridView1.Refresh();
            }
            button1.Text = "开始检测";
            button1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
