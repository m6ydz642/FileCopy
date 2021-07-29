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

namespace FileCopy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public string SourceDir { get; set; }
        public string TargetDir { get; set; }
        private void sourcedirectorybutton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dl = new FolderBrowserDialog();
            dl.ShowDialog();
            sourcedirtextBox.Text = dl.SelectedPath ;
            SourceDir = sourcedirtextBox.Text; // 수동으로 입력 가능하게 텍스트 내용을 경로로 넣음
        }

        private void targetdirectorybutton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dl = new FolderBrowserDialog();
            dl.ShowDialog();
            targetdirtextBox.Text = dl.SelectedPath;
            TargetDir = targetdirtextBox.Text;
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            DirectoryWork(SourceDir, TargetDir);
        }

        private void DirectoryWork(string sourceDirName, string destDirName)
        {
            // MSDN제공 : 재궤함수를 통한 파일경로 복사

            DirectoryInfo sourcedirinfo = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] sourcedirArray = sourcedirinfo.GetDirectories();

            CopyDirectory(sourceDirName, destDirName);
            CopyFile(sourceDirName, destDirName);
            //DeleteFile(sourceDirName, destDirName);
            //DeleteDirectory(sourceDirName, destDirName);

            foreach (DirectoryInfo sourcedirinfoiterator in sourcedirArray)
            {
                string path = Path.Combine(destDirName, sourcedirinfoiterator.Name);
                // path에 target경로 + 원본파일에 폴더 이름을 넣어 CopyDirectory함수로 전달함
                // source경로에 c:\test\something target경로에 c:\test\가 있으면
                // target경로에는 something폴더가 없으므로 CopyDirectory함수에서 추가함
                CopyDirectory(sourceDirName, path); // 소스파일에 폴더가 있는만큼 재귀로 호출함
            }
        }

        private void CopyFile(string sourceDirName, string destDirName)
        {
            DirectoryInfo sourcedir = new DirectoryInfo(sourceDirName);
            DirectoryInfo destdir = new DirectoryInfo(destDirName);

            FileInfo[] sourcefileArray = sourcedir.GetFiles(); // 현재 경로의 파일
            FileInfo[] destfileArray = destdir.GetFiles(); // 현재 경로의 파일

            FileInfo destfileinfo1 = null;

            foreach (FileInfo sourcefileinfo in sourcefileArray)
            {
                string path = Path.Combine(destDirName, sourcefileinfo.Name); // 복사를 위한 타겟 경로 + 원본파일 경로추가
                // FileInfo sourcefileinfo1 = new FileInfo(destDirName + "\\" + sourcefileinfo.Name); 

                foreach (FileInfo destfileinfo in destfileArray) 
                    // sourcefiles를 대상으로 상대 destdir경로의 파일들을 반복하며 if문으로 destdir에는 존재하지 않는 파일을 복사함
                {
                    destfileinfo1  = new FileInfo(destDirName + "\\" + destfileinfo.Name);

                    if (sourcefileinfo.Name.Equals(destfileinfo.Name) && 
                        sourcefileinfo.LastWriteTime.Equals(destfileinfo.LastWriteTime))
                    {
                        // 소스경로의 파일이랑 타겟 경로의 파일의 마지막 작성(수정) 시간이 동일하지 않으면 파일을 수정한것으로 간주
                        destfileinfo.CopyTo(path, true); // source파일에서 destfile로 복사함 (덮어쓰기 허용)
                        string[] DirectorySplit = destDirName.Split('\\'); // 타겟 경로의 마지막 부분 \\를 가져옴
                        dataGridViewfile.Rows.Add(DirectorySplit[DirectorySplit.Length - 1], sourcefileinfo.LastWriteTime);
                    }
                }

                if (!System.IO.File.Exists(path)) // source경로의 파일에서 반복하는 동안 타겟 경로의 파일이 존재하지 않으면
                {
                    sourcefileinfo.CopyTo(path, false); // source파일에서 target경로에 destfile로 복사해 새로 만듦
                                                      // destfile에는 없는걸 만들기 때문에 덮어쓰기를 하지 않아도 됨
                    string[] DirectorySplit = destDirName.Split('\\');
                    dataGridViewfile.Rows.Add(DirectorySplit[DirectorySplit.Length - 1], sourcefileinfo.LastWriteTime);
                }
            }
        }

        private void CopyDirectory(string sourceDirName, string destDirName)
        {
            DirectoryInfo sourcedirinfo = new DirectoryInfo(sourceDirName);
            DirectoryInfo targetdirinfo = new DirectoryInfo(destDirName);

            if (!targetdirinfo.Exists) // 타겟 경로에 폴더가 존재하지 않으면 생성하는 if문
            // DirectoryWork 함수에서 재귀함수가 돌면서 폴더명을 바꿔 접근하다가 없는폴더를 발견할 경우 if문 접근함
            {
                Directory.CreateDirectory(destDirName);
                string[] DirectorySplit = destDirName.Split('\\');
                dataGridViewfile.Rows.Add(DirectorySplit[DirectorySplit.Length-1], sourcedirinfo.LastWriteTime);
            }

        }
    }
}
