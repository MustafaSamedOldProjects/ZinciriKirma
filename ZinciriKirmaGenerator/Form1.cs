using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ZinciriKirmaGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtpEnd.Value<dtpStart.Value)
            {
                MessageBox.Show("BitişTarihi Başlangıç tarihinden daha erken olamaz. Ve ya aynı olamaz.");
                return;
            }
            var path = folderBrowserDialog1.ShowDialog();
            var fullpath = folderBrowserDialog1.SelectedPath + "\\ZinciriKırma.html";
            var html = "<!DOCTYPE html><html lang=\"en\"><head>    <meta charset=\"UTF-8\">    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">    <title>Document</title></head><body>    <table style=\"margin: auto auto;border: 3px solid rgba(33, 77, 158, 0.472);border-collapse: collapse;  \"> ";
            var günFark =(dtpEnd.Value - dtpStart.Value).Days+1;
            var ustLoop = günFark / 15;
            var günce = dtpStart.Value;

            for (int i = 0; i < ustLoop; i++)
            {
                html += "<tr  style=\"border: 1px solid red;\">";
                for (int K = 0; K < 15; K++)
                {
                    html += " <th style=\"border: 2px solid red;\">";
                    html += "<div class=\"tarih\" onclick=\"tikle(this)\" style=\"min-height: 37px; min-width: 42px; position: relative ;\">";
                    var gün = günce.Day;
                    var ayy = günce.Month;
                    var yıl = günce.Year;
                    html += "<span style=\"color: red; font-size: 10px; position: absolute;top: 0;right: 0; \">"+gün+"</span>";
                    html += "<span style=\"color: turquoise; font-size: 10px;  position: absolute; bottom: 0; left: 0;\">" + ayy + "</span>";
                    html += "<span style=\"color: #53354a; font-size: 10px; position: absolute; bottom: 0; right: 0; \">" + yıl + "</span>";
                    günce = günce.AddDays(1);
                    

                    html += "</div>";
                }
                html += "</tr>";

            }

            for (int i = 0; i < günFark % 15; i++)
            {
                    html += " <th style=\"border: 2px solid red;\">";
                    html += "<div class=\"tarih\" onclick=\"tikle(this)\" style=\"min-height: 45px; min-width: 49px; position: relative ;\">";
                    var gün = günce.Day;
                    var ayy = günce.Month;
                    var yıl = günce.Year;
                    html += "<span style=\"color: red; font-size: 10px; position: absolute;top: 0;right: 0; \">" + gün + "</span>";
                    html += "<span style=\"color: turquoise; font-size: 10px;  position: absolute; bottom: 0; left: 0;\">" + ayy + "</span>";
                    html += "<span style=\"color: #53354a; font-size: 10px; position: absolute; bottom: 0; right: 0; \">" + yıl + "</span>";
                    günce = günce.AddDays(1);
                    html += "</div>";
                
            }
            html += "<script>";
            html += "  function tikle(a) {";
            html += "if (!a.innerHTML.includes('<em style=\"font-size:35px;\">✓</em>')) {";
            html += "a.innerHTML += '<em style=\"font-size:35px;\">✓</em>';";
            html += "}";
            html += "else {";
            html += "var yenisi = a.innerHTML.replace(\"<em style=\"font-size:35px;\" >✓</ em >\", \"\");";
            html += " a.innerHTML = yenisi;";
            html += "}        }    </script>";
            html += "</table></body></html>";
          
            File.WriteAllText(fullpath, html);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var path = folderBrowserDialog1.ShowDialog();
            var fullpath = folderBrowserDialog1.SelectedPath + "\\ZinciriKırma.html";
            // Create a PDF from an existing HTML using C#
            var Renderer = new IronPdf.HtmlToPdf();
            var PDF = Renderer.RenderHTMLFileAsPdf(fullpath);
            var OutputPath = folderBrowserDialog1.SelectedPath + "\\ZinciriKırma.pdf";
            PDF.SaveAs(OutputPath);
           
        }
    }
}
