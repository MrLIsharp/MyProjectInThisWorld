using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ModifytTheDesktopClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        /// <summary>
        /// 上傳文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadImage_Click(object sender, EventArgs e)
        {
            //初始化openFileDialog
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择要上传的图片";
            ofd.Filter = "图像文件(*.jpg;*.gif;*.png)|*.jpg;*.gif;*.png";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string oldFilePath = ofd.FileName;
                int position = oldFilePath.LastIndexOf("\\");
                string OldfileName = oldFilePath.Substring(position + 1);
                string[] splitName = oldFilePath.Split('.');
                string ext = splitName[splitName.Length - 1];

                //string newName = DateTime.Now.ToString("yyyyMMddhhmmss") + ".bmp";// + ext;
                var index = 1;
            cc: string newName = index + ".bmp";// + ext;

                //判断根目录下是否含有指定文件夹，若没有则创建一个新的
                string path = AppDomain.CurrentDomain.BaseDirectory + "/UpLoadImages";
                DirectoryInfo di = new DirectoryInfo(path);
                if (!di.Exists)
                {
                    di.Create();
                }
                string newFilePath = AppDomain.CurrentDomain.BaseDirectory + "/UpLoadImages/" + newName;
                if (File.Exists(newFilePath))
                {
                    index = index + 1;
                    goto cc;
                }
                File.Copy(oldFilePath, newFilePath, false);
                Image img = Image.FromFile(newFilePath);
                //tureBox1.Image = img;
                MessageBox.Show("上传成功", "Tip");
            }
        }
        /// <summary>
        /// 設置隨機壁紙
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomMTD_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();
                var FileName = AppDomain.CurrentDomain.BaseDirectory + "/UpLoadImages";
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(FileName);
                UpdateWindowsDesk(random.Next(1,GetFilesCount(dirInfo)+1));
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        /// <summary>
        /// 讀取文件夾下文件數量
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <returns></returns>
        public static int GetFilesCount(DirectoryInfo dirInfo)
        {

            int totalFile = 0;
            //totalFile += dirInfo.GetFiles().Length;//获取全部文件
            totalFile += dirInfo.GetFiles("*.bmp").Length;//获取某种格式
            foreach (System.IO.DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                totalFile += GetFilesCount(subdir);
            }
            return totalFile;
        }
        //引用Userdll
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(
          int uAction,
          int uParam,
          string lpvParam,
          int fuWinIni
          );
        /// <summary>
        /// 設置圖片桌面
        /// </summary>
        /// <param name="randomFileName"></param>
        public static void UpdateWindowsDesk(int randomFileName)
        {
            //Image image = Image.FromFile("E:\\新建文件夹\\test.jpg");
            //var PicName = "E:\\新建文件夹\\" + DateTime.Now.ToShortTimeString() + ".bmp";
            var PicName = AppDomain.CurrentDomain.BaseDirectory + @"UpLoadImages\"+ randomFileName+".bmp";
            //image.Save(PicName, System.Drawing.Imaging.ImageFormat.Bmp);
            SystemParametersInfo(20, 0, PicName, 0x2);
           // MessageBox.Show(PicName);
        }
        /// <summary>
        /// 設置圖片桌面
        /// </summary>
        /// <param name="randomFileName"></param>
        /// <param name="towFileName"></param>
        public static void UpdateWindowsDesk(int randomFileName,int towFileName)
        {
            var PicName = AppDomain.CurrentDomain.BaseDirectory + @"UpLoadImages\" + randomFileName + ".bmp";
            var PicName2 = AppDomain.CurrentDomain.BaseDirectory + @"UpLoadImages\" + towFileName + ".bmp";
            SystemParametersInfo(20, 0, PicName, 0x2);
            SystemParametersInfo(20, 0, PicName2, 0x2);
        }
        /// <summary>
        /// 推出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {               
                this.Close();   //关闭程序
            }
        }      
    }
}
