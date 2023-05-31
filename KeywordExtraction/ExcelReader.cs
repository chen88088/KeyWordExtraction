using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace KeywordExtraction
{
    public class ExcelReader
    {
        public List<string> ReadExcel(string filePath)
        {
            List<string> lines = new List<string>();

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
            //讀取第一個工作表
            Excel.Worksheet worksheet = workbook.Sheets[1]; 

            int rowCount = worksheet.UsedRange.Rows.Count;
            int columnCount = worksheet.UsedRange.Columns.Count;

            // 跳掉第一列不讀
            for (int row = 2; row <= rowCount; row++)
            {
                StringBuilder line = new StringBuilder();

                Excel.Range customMessageCell = worksheet.Cells[row, 4];
                string customMessageCellValue = customMessageCell.Value2?.ToString() ?? string.Empty;

                // 挑出要問ai的問題 所在的行
                if (IsQuestionNeedToAskAI(customMessageCellValue))
                {
                    for (int col = 2; col <= columnCount-1; col++)
                    {
                        Excel.Range cell = worksheet.Cells[row, col];
                        string cellValue = cell.Value2?.ToString() ?? string.Empty;

                        if(col== 4)
                        {
                            cellValue = FilterCustomerConfidentilalData(cellValue);
                        } 
                        
                        line.Append(cellValue); // 使用制表符分隔每個儲存格的值
                        line.Append('^');

                    }
                    string lineToDeal = line.ToString();
                    lines.Add(lineToDeal.TrimEnd('^')); // 移除最後一個制表符
                    
                }
                
                
            }

            // 關閉 Excel 相關物件
            workbook.Close();
            excelApp.Quit();

            // 釋放資源
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            return lines;
        }

        /// <summary>
        /// 方法--確認問題是否值得問ai
        /// </summary>
        /// <param name="question">待處理的問題</param>
        /// <returns>是否值得問</returns>
        public bool IsQuestionNeedToAskAI(string question)
        {
            if (question == string.Empty)
            {
                return false ;
            }
            else if (question == "好,")
            {
                return false;
            }
            else if (GetCharacterCount(question) == 1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// 方法--回傳字串長度
        /// </summary>
        /// <param name="question">顧客的問題字串</param>
        /// <returns>字串長度</returns>
        private int GetCharacterCount(string question)
        {
            return question.Length;
        }


        /// <summary>
        /// 方法--過濾掉機密資料
        /// </summary>
        /// <param name="inputString">讀取字串</param>
        /// <returns>過濾完的字串</returns>
        private string FilterCustomerConfidentilalData(string inputString)
        {
            string filterString = inputString;
            // 使用正则表达式提取邮箱地址和手机号码
            string pattern = @"(?<phone>09[\d-]{8,12})|(?<email>[\w.-]+@[\w.-]+\.[\w.-]+)";

            MatchCollection matches = Regex.Matches(filterString, pattern);

            foreach (Match match in matches)
            {
                if (match.Groups["phone"].Success)
                {
                    string phoneNumber = match.Groups["phone"].Value;
                    filterString = filterString.Replace(phoneNumber, string.Empty);
                    
                }

                if (match.Groups["email"].Success)
                {
                    string email = match.Groups["email"].Value;
                    filterString = filterString.Replace(email, string.Empty);
                }
            }

            return filterString;

        }
    }
}
