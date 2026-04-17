using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeListViews();
        }

        private void InitializeListViews()
        {
            ConfigureListView(lvwLeftDir);
            ConfigureListView(lvwRightDir);
        }

        private void ConfigureListView(ListView listView)
        {
            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.HideSelection = false;
        }

        private void btnLeftDir_Click(object sender, EventArgs e) { SelectFolder(txtLeftDir); }
        private void btnRightDir_Click(object sender, EventArgs e) { SelectFolder(txtRightDir); }

        private void SelectFolder(TextBox targetTextBox)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "폴더를 선택하세요.";
                dialog.ShowNewFolderButton = false;
                dialog.SelectedPath = Directory.Exists(targetTextBox.Text)
                    ? targetTextBox.Text
                    : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    targetTextBox.Text = dialog.SelectedPath;
                    RefreshBothLists();
                }
            }
        }

        private void RefreshBothLists()
        {
            PopulateListView(lvwLeftDir, txtLeftDir.Text, txtRightDir.Text);
            PopulateListView(lvwRightDir, txtRightDir.Text, txtLeftDir.Text);
        }

        private void PopulateListView(ListView targetListView, string sourceDir, string compareDir)
        {
            targetListView.Items.Clear();
            if (string.IsNullOrWhiteSpace(sourceDir) || !Directory.Exists(sourceDir)) return;

            FileInfo[] files = new DirectoryInfo(sourceDir)
                .GetFiles("*", SearchOption.TopDirectoryOnly)
                .OrderBy(f => f.Name, StringComparer.CurrentCultureIgnoreCase)
                .ToArray();

            foreach (FileInfo file in files)
            {
                ListViewItem item = new ListViewItem(file.Name);
                item.SubItems.Add(ToDisplaySize(file.Length));
                item.SubItems.Add(file.LastWriteTime.ToString("yyyy-MM-dd HH:mm"));
                item.ForeColor = GetFileColor(file, compareDir);
                targetListView.Items.Add(item);
            }
        }

        private Color GetFileColor(FileInfo sourceFile, string compareDir)
        {
            if (string.IsNullOrWhiteSpace(compareDir) || !Directory.Exists(compareDir)) return Color.Black;

            string targetPath = Path.Combine(compareDir, sourceFile.Name);
            if (!File.Exists(targetPath)) return Color.Red;

            FileInfo targetFile = new FileInfo(targetPath);
            if (sourceFile.LastWriteTime > targetFile.LastWriteTime) return Color.Blue;
            if (sourceFile.LastWriteTime < targetFile.LastWriteTime) return Color.Gray;
            return Color.Black;
        }

        private string ToDisplaySize(long length)
        {
            long kb = Math.Max(1, (long)Math.Ceiling(length / 1024.0));
            return kb.ToString() + " KB";
        }

        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {
            CopySelectedFile(lvwLeftDir, txtLeftDir.Text, txtRightDir.Text);
        }

        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            CopySelectedFile(lvwRightDir, txtRightDir.Text, txtLeftDir.Text);
        }

        private void CopySelectedFile(ListView listView, string sourceDir, string targetDir)
        {
            if (!Directory.Exists(sourceDir) || !Directory.Exists(targetDir))
            {
                MessageBox.Show("양쪽 폴더를 먼저 선택하세요.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("복사할 파일을 먼저 선택하세요.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fileName = listView.SelectedItems[0].Text;
            string sourcePath = Path.Combine(sourceDir, fileName);
            string targetPath = Path.Combine(targetDir, fileName);

            if (!File.Exists(sourcePath))
            {
                MessageBox.Show("원본 파일을 찾을 수 없습니다.\n" + sourcePath, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (File.Exists(targetPath))
            {
                DateTime sourceTime = File.GetLastWriteTime(sourcePath);
                DateTime targetTime = File.GetLastWriteTime(targetPath);
                string message =
                    "동일한 이름의 파일이 반대쪽 폴더에 이미 있습니다.\n\n" +
                    "원본 수정일: " + sourceTime.ToString("yyyy-MM-dd HH:mm:ss") + "\n" +
                    "대상 수정일: " + targetTime.ToString("yyyy-MM-dd HH:mm:ss") + "\n\n" +
                    "덮어쓰시겠습니까?";

                if (MessageBox.Show(message, "덮어쓰기 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            File.Copy(sourcePath, targetPath, true);
            RefreshBothLists();
        }
    }
}
