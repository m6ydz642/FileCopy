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

            targetdirtextBox.TextChanged += TargetdirtextBox_TextChanged;
            sourcedirtextBox.TextChanged += SourcedirtextBox_TextChanged;
        }
        // 텍스트 박스에 직접 입력을 했을 경우
        private void SourcedirtextBox_TextChanged(object sender, EventArgs e)

        {
            if (sender is TextBox text)
            {
                SourceDir = text.Text;
            }
        }
        // 텍스트 박스에 직접 입력을 했을 경우
        private void TargetdirtextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox text)
            {
                TargetDir = text.Text;
            }
        }

        public string SourceDir { get; set; }
        public string TargetDir { get; set; }

        // 경로버튼 클릭으로 선택했을경우
        private void sourcedirectorybutton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dl = new FolderBrowserDialog();
            dl.ShowDialog();
            sourcedirtextBox.Text = dl.SelectedPath ;
            SourceDir = sourcedirtextBox.Text; // 수동으로 입력 가능하게 텍스트 내용을 경로로 넣음
        }
        // 경로버튼 클릭으로 선택했을경우
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
            DeleteFile(sourceDirName, destDirName);
            //DeleteDirectory(sourceDirName, destDirName);

            foreach (DirectoryInfo sourcedirinfoiterator in sourcedirArray)
            {
                string path = Path.Combine(destDirName, sourcedirinfoiterator.Name);
                // path에 target경로 + 원본파일에 폴더 이름을 넣어 CopyDirectory함수로 전달함
                // source경로에 c:\test\something target경로에 c:\test\가 있으면
                // target경로에는 something폴더가 없으므로 CopyDirectory함수에서 추가함
                DirectoryWork(sourcedirinfoiterator.FullName, path); // 소스파일에 폴더가 있는만큼 재귀로 호출함
            }
        }

        private void DeleteFile(string sourceDirName, string destDirName)
        {
            DirectoryInfo sourcedir = new DirectoryInfo(sourceDirName);
            DirectoryInfo destdir = new DirectoryInfo(destDirName);

            FileInfo destfileinfo_getDirfiles = new FileInfo(destDirName); // 파일 전체 경로 및 정보 가져오기
            FileInfo[] deestfilesArray = destdir.GetFiles(); // 들어있는 파일들 배열형태로 가져오기 

            // 타겟에는 있는데 소스에는 없는걸 삭제처리 하면 됨
            foreach (FileInfo destfile in deestfilesArray) // sourcefiles를 대상으로 상대 destdir경로의 파일들을 검색함
            {
                FileInfo destfileinfo = new FileInfo(destDirName + "\\" + destfile.Name); // 타겟 경로 + 타겟 파일
                string tempPath = Path.Combine(sourceDirName, destfile.Name); // 원본 경로 + target 들어있는 파일명

                if (!System.IO.File.Exists(tempPath)) // 소스파일에 파일이 존재하는지를 확인함 
                    // source폴더에는 존재하지않는데 target에만 존재한다면 source폴더에 맞춰서 삭제하는거임
                {
                    // target의 폴더를 반복하고 있을 때 sources폴더에 그 target 의 파일 내용이 없으면 삭제한 것으로 간주
                    string[] DirectorySplit = tempPath.Split('\\');
                    dataGridViewfile.Rows.Add(DirectorySplit[DirectorySplit.Length - 1], destfileinfo.LastWriteTime);
                    destfile.Delete();
                }
            }

        }

        private void CopyFile(string sourceDirName, string destDirName)
        {
            DirectoryInfo sourcedir = new DirectoryInfo(sourceDirName);
            DirectoryInfo destdir = new DirectoryInfo(destDirName);

            FileInfo[] sourcefileArray = sourcedir.GetFiles(); // 현재 경로의 파일
            FileInfo[] destfileArray = destdir.GetFiles(); // 현재 경로의 파일

            FileInfo destfileinfo_CombinePath = null;
            FileInfo sourcefileinfo_CombinePath = null;

            foreach (FileInfo sourcefileinfo in sourcefileArray)
            {
                string path = Path.Combine(destDirName, sourcefileinfo.Name); // 복사를 위한 타겟 경로 + 원본파일 경로추가
                sourcefileinfo_CombinePath = new FileInfo(sourceDirName + "\\" + sourcefileinfo.Name); 

                foreach (FileInfo destfileinfo in destfileArray) 
                    // sourcefiles를 대상으로 상대 destdir경로의 파일들을 반복하며 if문으로 destdir에는 존재하지 않는 파일을 복사함
                {
                    destfileinfo_CombinePath = new FileInfo(destDirName + "\\" + destfileinfo.Name);

                    if (sourcefileinfo.Name.Equals(destfileinfo.Name) && 
                        !sourcefileinfo.LastWriteTime.Equals(destfileinfo_CombinePath.LastWriteTime))
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
