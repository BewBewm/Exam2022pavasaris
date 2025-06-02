using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private IWebDriver driver;
        private string ebayLink = "https://www.ebay.com";
    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(ebayLink);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var searchWord = textBox1.Text;
            var searchInput = driver.FindElement(By.Id("gh-ac"));

            searchInput.Clear();
            searchInput.SendKeys(searchWord);

            driver.FindElement(By.Id("gh-search-btn")).Click(); //Nomainīju uz gh-search-btn, jo ebay šobrīd tāds ir aktuāls pogas "Search" ID
            
            string searchLink = driver.Url;
            textBox2.Text = searchLink;
            richTextBox1.AppendText(searchLink + Environment.NewLine);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            driver.Navigate().Back();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            driver.Quit();
        }
    }
}
