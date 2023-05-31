using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeywordExtraction
{
    public class FileMaker
    {
        public List<string> ReportList { get; set; }

        

        public FileMaker(List<string> reportAiResponseList)
        {
            ReportList = reportAiResponseList;
            
        }

        public void MakeFile()
        {
           
            // 使用 SaveFileDialog 讓使用者指定存放位置與檔名
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV 檔 (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string csvPath = saveFileDialog.FileName;

                // 建立 StreamWriter 物件
                using (StreamWriter writer = new StreamWriter(csvPath))
                {
                    // 寫入標題行
                    writer.WriteLine("服務紀錄編號^客戶留言^Ai回應");

                    // 寫入每一行資料
                    foreach (string line in ReportList)
                    {
                        writer.WriteLine($"{line}");
                        writer.WriteLine($"\n");
                    }
                }
            }
        }

    }
}
