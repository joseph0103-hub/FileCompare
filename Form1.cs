using System;
using System.Collections.Generic;
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
            PopulateRecursiveListView(lvwLeftDir, txtLeftDir.Text, txtRightDir.Text);
            PopulateRecursiveListView(lvwRightDir, txtRightDir.Text, txtLeftDir.Text);
        }

        private void PopulateRecursiveListView(ListView targetListView, string sourceDir, string compareDir)
        {
            targetListView.Items.Clear();
            if (string.IsNullOrWhiteSpace(sourceDir) || !Directory.Exists(sourceDir)) return;

            List<EntryInfo> entries = GetEntries(sourceDir);

            foreach (EntryInfo entry in entries.OrderBy(e => e.SortKey, StringComparer.CurrentCultureIgnoreCase))
            {
                ListViewItem item = new ListViewItem(entry.DisplayName);
                item.SubItems.Add(entry.DisplaySize);
                item.SubItems.Add(entry.ModifiedTime.ToString("yyyy-MM-dd HH:mm"));
                item.Tag = entry;
                item.ForeColor = GetEntryColor(entry, compareDir);
                targetListView.Items.Add(item);
            }
        }

        private List<EntryInfo> GetEntries(string rootDir)
        {
            List<EntryInfo> results = new List<EntryInfo>();

            foreach (string dir in Directory.GetDirectories(rootDir, "*", SearchOption.AllDirectories))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                string relative = GetRelativePath(rootDir, dir);

                results.Add(new EntryInfo
                {
                    SortKey = relative,
                    DisplayName = "[DIR] " + relative,
                    RelativePath = relative,
                    FullPath = dir,
                    IsDirectory = true,
                    DisplaySize = "<DIR>",
                    ModifiedTime = di.LastWriteTime
                });
            }

            foreach (string file in Directory.GetFiles(rootDir, "*", SearchOption.AllDirectories))
            {
                FileInfo fi = new FileInfo(file);
                string relative = GetRelativePath(rootDir, file);

                results.Add(new EntryInfo
                {
                    SortKey = relative,
                    DisplayName = relative,
                    RelativePath = relative,
                    FullPath = file,
                    IsDirectory = false,
                    DisplaySize = ToDisplaySize(fi.Length),
                    ModifiedTime = fi.LastWriteTime
                });
            }

            return results;
        }

        private Color GetEntryColor(EntryInfo sourceEntry, string compareRoot)
        {
            if (string.IsNullOrWhiteSpace(compareRoot) || !Directory.Exists(compareRoot))
                return Color.Black;

            string comparePath = Path.Combine(compareRoot, sourceEntry.RelativePath);

            if (sourceEntry.IsDirectory)
            {
                if (!Directory.Exists(comparePath)) return Color.Red;

                DateTime targetTime = new DirectoryInfo(comparePath).LastWriteTime;
                if (sourceEntry.ModifiedTime > targetTime) return Color.Blue;
                if (sourceEntry.ModifiedTime < targetTime) return Color.Gray;
                return Color.Black;
            }

            if (!File.Exists(comparePath)) return Color.Red;

            DateTime fileTargetTime = File.GetLastWriteTime(comparePath);
            if (sourceEntry.ModifiedTime > fileTargetTime) return Color.Blue;
            if (sourceEntry.ModifiedTime < fileTargetTime) return Color.Gray;
            return Color.Black;
        }

        private string GetRelativePath(string rootDir, string path)
        {
            Uri rootUri = new Uri(AppendDirectorySeparator(rootDir));
            Uri pathUri = new Uri(path);
            return Uri.UnescapeDataString(rootUri.MakeRelativeUri(pathUri).ToString()).Replace('/', '\\');
        }

        private string AppendDirectorySeparator(string path)
        {
            return path.EndsWith("\\") ? path : path + "\\";
        }

        private string ToDisplaySize(long length)
        {
            long kb = Math.Max(1, (long)Math.Ceiling(length / 1024.0));
            return kb.ToString() + " KB";
        }

        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {
            CopySelectedEntry(lvwLeftDir, txtLeftDir.Text, txtRightDir.Text);
        }

        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            CopySelectedEntry(lvwRightDir, txtRightDir.Text, txtLeftDir.Text);
        }

        private void CopySelectedEntry(ListView listView, string sourceRoot, string targetRoot)
        {
            if (!Directory.Exists(sourceRoot) || !Directory.Exists(targetRoot))
            {
                MessageBox.Show("양쪽 폴더를 먼저 선택하세요.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("복사할 항목을 먼저 선택하세요.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EntryInfo entry = (EntryInfo)listView.SelectedItems[0].Tag;
            string targetPath = Path.Combine(targetRoot, entry.RelativePath);

            if (entry.IsDirectory)
            {
                if (Directory.Exists(targetPath))
                {
                    string msg =
                        "동일한 이름의 폴더가 이미 존재합니다.\n\n" +
                        "원본 수정일: " + entry.ModifiedTime.ToString("yyyy-MM-dd HH:mm:ss") + "\n" +
                        "대상 수정일: " + new DirectoryInfo(targetPath).LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss") + "\n\n" +
                        "하위 내용까지 덮어쓰시겠습니까?";
                    if (MessageBox.Show(msg, "폴더 복사 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                }

                CopyDirectory(entry.FullPath, targetPath);
            }
            else
            {
                string parent = Path.GetDirectoryName(targetPath);
                if (!Directory.Exists(parent)) Directory.CreateDirectory(parent);

                if (File.Exists(targetPath))
                {
                    string msg =
                        "동일한 이름의 파일이 이미 존재합니다.\n\n" +
                        "원본 수정일: " + entry.ModifiedTime.ToString("yyyy-MM-dd HH:mm:ss") + "\n" +
                        "대상 수정일: " + File.GetLastWriteTime(targetPath).ToString("yyyy-MM-dd HH:mm:ss") + "\n\n" +
                        "덮어쓰시겠습니까?";
                    if (MessageBox.Show(msg, "파일 복사 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                }

                File.Copy(entry.FullPath, targetPath, true);
            }

            RefreshBothLists();
        }

        private void CopyDirectory(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);

            foreach (string dir in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
            {
                string relative = GetRelativePath(sourceDir, dir);
                Directory.CreateDirectory(Path.Combine(targetDir, relative));
            }

            foreach (string file in Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories))
            {
                string relative = GetRelativePath(sourceDir, file);
                string targetFile = Path.Combine(targetDir, relative);
                string parent = Path.GetDirectoryName(targetFile);
                if (!Directory.Exists(parent)) Directory.CreateDirectory(parent);
                File.Copy(file, targetFile, true);
            }
        }

        private class EntryInfo
        {
            public string SortKey;
            public string DisplayName;
            public string RelativePath;
            public string FullPath;
            public bool IsDirectory;
            public string DisplaySize;
            public DateTime ModifiedTime;
        }
    }
}
