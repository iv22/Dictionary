using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class View_ChartDict : Form
    {
        public View_ChartDict()
        {
            InitializeComponent();
        }

        public void SetChart(double allCount, double studiedCount, double knowingCount, double less2testCount, double less05coeffCount)
        {
            foreach (var s in chartDictStat.Series)
                s.Points.Clear();

            chartDictStat.Series[0].Points.AddXY(0.7, allCount);
            chartDictStat.Series[1].Points.AddXY(1, studiedCount);
            chartDictStat.Series[2].Points.AddXY(1.3, knowingCount);
            chartDictStat.Series[3].Points.AddXY(1.6, less2testCount);
            chartDictStat.Series[4].Points.AddXY(1.9, less05coeffCount);

            //chartDictStat.Series[0].Points[0].YValues[0] = allCount;
            //chartDictStat.Series[1].Points[0].YValues[0] = studiedCount;
            //chartDictStat.Series[2].Points[0].YValues[0] = firstCount;
        }
    }
}
