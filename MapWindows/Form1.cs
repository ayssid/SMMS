using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapWinGIS;
using System.Diagnostics;

namespace MapWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2MinSize = 0;
            axMap1.Projection = tkMapProjection.PROJECTION_NONE;
            axMap1.TileProvider = tkTileProvider.ProviderNone;

            string fileName = @"C:\Users\Yogi\Documents\Visual Studio 2015\Projects\MapWindows\MapWindows\Semarang\BandaraSMG.shp";
            var sf = new Shapefile();
            bool exists = File.Exists(fileName);
            //test
          

            if(sf.Open(fileName, null))
            {
                int layerHandle = axMap1.AddLayer(sf, true);
            }
            else
            {
                Debug.WriteLine("Failed to open shapefile: " + sf.get_ErrorMsg(sf.LastErrorCode));
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                if(splitContainer1.Panel2Collapsed)
                {
                    splitContainer1.Panel2Collapsed = false;
                } else
                {
                    splitContainer1.Panel2Collapsed = true;
                }
                
                
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
    }
}
