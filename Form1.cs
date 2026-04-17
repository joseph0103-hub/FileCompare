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

        private void btnLeftDir_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "왼쪽 폴더를 선택하세요.";
                dialog.ShowNewFolderButton = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtLeftDir.Text = dialog.SelectedPath;
                    RefreshBothLists();
                }
            }
        }

        private void btnRightDir_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "오른쪽 폴더를 선택하세요.";
                dialog.ShowNewFolderButton = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtRightDir.Text = dialog.SelectedPath;
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

            if (string.IsNullOrWhiteSpace(sourceDir) || !Directory.Exists(sourceDir))
            {
                return;
            }

            var files = new DirectoryInfo(sourceDir)
                .GetFiles("*", SearchOption.TopDirectoryOnly)
                .OrderBy(f => f.Name, StringComparer.CurrentCultureIgnoreCase)
                .ToArray();

            foreach (var file in files)
            {
                var item = new ListViewItem(file.Name);
                item.SubItems.Add(ToDisplaySize(file.Length));
                item.SubItems.Add(file.LastWriteTime.ToString("yyyy-MM-dd tt h:mm"));

                item.ForeColor = GetFileColor(file, compareDir);
                targetListView.Items.Add(item);
            }
        }

        private Color GetFileColor(FileInfo sourceFile, string compareDir)
        {
            if (string.IsNullOrWhiteSpace(compareDir) || !Directory.Exists(compareDir))
            {
                return Color.Black;
            }

            string targetPath = Path.Combine(compareDir, sourceFile.Name);

            if (!File.Exists(targetPath))
            {
                return Color.Red;
            }

            var targetFile = new FileInfo(targetPath);

            if (sourceFile.LastWriteTime > targetFile.LastWriteTime)
            {
                return Color.Blue;
            }

            if (sourceFile.LastWriteTime < targetFile.LastWriteTime)
            {
                return Color.DarkGray;
            }

            return Color.Black;
        }

        private string ToDisplaySize(long length)
        {
            long kb = (long)Math.Ceiling(length / 1024.0);
            return kb + " KB";
        }
    }
}
