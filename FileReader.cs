using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordExtraction
{
    public class FileReader
    {
        public string Path { get; set; }

        public StreamReader StreamReader { get; set; }

        public ExcelReader ExcelReader { get; set; }

        public FileReader(string path)
        {
            Path = path;
            StreamReader = new StreamReader(path);
            ExcelReader = new ExcelReader();
        }

        /// <summary>
        /// 讀取檔案
        /// </summary>
        /// <param name="file">檔案的路徑</param>
        public List<string> ReadFileAndDataPreprocessing()
        {           
            List<string> excelContentAfterFilterList = new List<string>();

            excelContentAfterFilterList = ExcelReader.ReadExcel(Path);

            //string customResponseRecord;
            //while ((customResponseRecord = StreamReader.ReadLine()) != null)
            //{
            //    string line = customResponseRecord;
            //    string[] rows = line.Split(',');


            //    customResponseRecordList.Add(line);
            //}
            return excelContentAfterFilterList;
        }
    }
}
