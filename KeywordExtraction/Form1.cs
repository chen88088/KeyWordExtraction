using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeywordExtraction
{
    public partial class ProgessTitleLabel : Form
    {
        public ProgessTitleLabel()
        {
            InitializeComponent();
        }
        /// <summary>
        /// EXCEL讀取欄位資訊編號
        /// </summary>
        public enum QuestionInfoSignature
        {
            
            服務紀錄編號 = 0,
            服務備註 = 1,
            客戶留言 = 2,
            回應 = 3
        }

        /// <summary>
        /// 用來存放待請ai處理的list
        /// </summary>
        private static List<string> CustomServiceResponseList = new List<string>();

        /// <summary>
        /// 用來存放待ai處理完的字串的list
        /// </summary>
        private static List<string> ResponseList = new List<string>();

        private void FileReadBnt_Click(object sender, EventArgs e)
        {
            // 清空1.更改路徑檔案清單list 
            CustomServiceResponseList.Clear();
            ResponseList.Clear();

            // 顯示讀檔路徑並且存到變數filePath
            string filePath = ReadFileShowPathOnTextBox();

            if (filePath == string.Empty)
            {
                // 使用者防呆: 點選"讀取檔案"按鈕，卻沒有選擇檔案讀取
                // 對策: 啥都不做
            }
            else
            {
                // 讀取檔案清單
                FileReader fileReader = new FileReader(filePath);
                CustomServiceResponseList = fileReader.ReadFileAndDataPreprocessing();
            }

            string completeMsg = "讀取檔案完成";
            MessageBox.Show(completeMsg);

        }

        /// <summary>
        /// 讀取檔案對話視窗抓取檔案路徑並顯示出來
        /// </summary>
        /// <returns>檔案路徑名稱</returns>
        public string ReadFileShowPathOnTextBox()
        {
            OpenFileDialog openReadFileDialog = new OpenFileDialog();

            openReadFileDialog.Title = "請開啟(.csv)檔案";
            string fileName = string.Empty;

            if (openReadFileDialog.ShowDialog() == DialogResult.OK)
            {
                //顯示路徑
                fileName = openReadFileDialog.FileName;
                FilePathTextBox.Text = fileName;
            }
            return fileName;
        }


        private async void AskAiBnt_ClickAsync(object sender, EventArgs e)
        {

            string uri = "http://192.168.10.87/AiSocialApp.AI/ChatGpt/SimpleAsk";
            AiAsker aiAsker = new AiAsker(uri);

            int listCount = CustomServiceResponseList.Count();

            int failCount = 0;

            Queue<(AskAiRequest, string)> resendQueue = new Queue<(AskAiRequest, string)>();

            for (int index = 0; index< listCount; index++)
            {
                (AskAiRequest, string) tuple ;
                try
                {
                    tuple = MakeAskAiRequest(CustomServiceResponseList[index]);

                    string aiResponse = await aiAsker.GetAiResponse(tuple.Item1);
                    
                    string csvRecordLine = string.Format("{0}{1}", tuple.Item2, aiResponse);

                    ResponseList.Add(csvRecordLine);
                }
                catch (Exception exception)
                {
                    failCount++;
                    FailCountLabel.Text = failCount.ToString();

                    (AskAiRequest, string) resendTuple = MakeAskAiRequest(CustomServiceResponseList[index]);
                    resendQueue.Enqueue(resendTuple);
                }

                int count = index + 1;
                ProgressLabel.Text = string.Format("{0}/{1}", count.ToString(), listCount.ToString());
                await Task.Delay(TimeSpan.FromSeconds(20));
            }

            while (resendQueue.Count()!=0)
            {
                ResendLabel.Text = string.Format("{0}/{1}", resendQueue.Count().ToString(), failCount.ToString());

                (AskAiRequest request, string line) = resendQueue.Dequeue();
                try
                {
                    string aiResendResponse = await aiAsker.GetAiResponse(request);

                    string csvRecordLine = string.Format("{0}{1}", line, aiResendResponse);

                    ResponseList.Add(csvRecordLine);
                }
                catch (Exception exception)
                {

                    (AskAiRequest, string) resendTuple = (request,line);
                    resendQueue.Enqueue(resendTuple);
                }
                await Task.Delay(TimeSpan.FromSeconds(15));
            }
            ResendLabel.Text = "全部完成";
            ProgressLabel.Text = "全部完成";
        }

        
        public (AskAiRequest, string )MakeAskAiRequest(string line)
        {
            string[] rows = line.Split('^');
            AskAiRequest askAiRequest = new AskAiRequest()
            {
                Prompt = "你是客服人員，請分別幫我彙整客戶問題重點，幫我列出比較接近這群關鍵字中哪些，並請列出數值比重。關鍵字群：取消訂閱、更換信用卡、無法綁定手機(刪除帳號)、已購買沒有權限、忘記密碼、庫存匯入、找不到股票、MAC版本、討論區相關、影音課程怎麼看、優惠活動、遠端、籌碼選股、分價量",
                Message = rows[(int)QuestionInfoSignature.客戶留言],
                Temperature = 0,
                Max_Tokens = 0,
                Presence_Penalty = 0
            };

            string csvLine = string.Format("{0}^{1}^", rows[(int)QuestionInfoSignature.服務紀錄編號], rows[(int)QuestionInfoSignature.客戶留言]);

            return (askAiRequest, csvLine);
        }

        private void csvCreatBnt_Click(object sender, EventArgs e)
        {
            if (ResponseList.Count() == 0)
            {
                string checkRemindMsg = "請確認是否完成前面步驟";
                MessageBox.Show(checkRemindMsg);
            }
            else
            {
                FileMaker fileMaker = new FileMaker(ResponseList);
                fileMaker.MakeFile();
                string reportMsg = "已產出清單";
                MessageBox.Show(reportMsg);
            }
        }
    }
}
