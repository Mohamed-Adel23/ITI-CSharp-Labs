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

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDrives(leftBox);
            LoadDrives(rightBox);
        }

        private void LoadDrives(RichTextBox box)
        {
            box.Clear();
            foreach (var drive in Directory.GetLogicalDrives())
            {
                box.AppendText(drive + Environment.NewLine);
            }
        }

        private void goLeft_Click_1(object sender, EventArgs e)
        {
            LoadPath(leftPathBox.Text, leftBox);
        }

        private void goRight_Click_1(object sender, EventArgs e)
        {
            LoadPath(rightPathBox.Text, rightBox);
        }

        private void LoadPath(string path, RichTextBox box)
        {
            try
            {
                box.Clear();
                foreach (var dir in Directory.GetDirectories(path))
                    box.AppendText("[DIR] " + dir + Environment.NewLine);
                foreach (var file in Directory.GetFiles(path))
                    box.AppendText(file + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void OpenSelected(RichTextBox box, TextBox pathBox)
        {
            string selected = box.SelectedText.Trim();
            if (string.IsNullOrEmpty(selected)) return;

            // Remove [DIR] prefix if present
            if (selected.StartsWith("[DIR]"))
                selected = selected.Substring(5).Trim();

            if (Directory.Exists(selected))
            {
                pathBox.Text = selected;
                LoadPath(selected, box);
            }
            else if (File.Exists(selected))
            {
                MessageBox.Show("This is a file: " + selected);
            }
        }

        private void leftBox_DoubleClick(object sender, EventArgs e)
        {
            OpenSelected(leftBox, leftPathBox);
        }

        private void rightBox_DoubleClick(object sender, EventArgs e)
        {
            OpenSelected(rightBox, rightPathBox);
        }

        private void MoveItem(RichTextBox sourceBox, string sourcePath, string targetPath)
        {
            string selected = sourceBox.SelectedText.Trim();
            if (string.IsNullOrEmpty(selected)) return;

            if (selected.StartsWith("[DIR]")) selected = selected.Substring(5).Trim();

            string name = Path.GetFileName(selected);
            string dest = Path.Combine(targetPath, name);

            try
            {
                if (Directory.Exists(selected))
                    Directory.Move(selected, dest);
                else if (File.Exists(selected))
                    File.Move(selected, dest);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Move error: " + ex.Message);
            }
        }

        private void moveRight_Click_1(object sender, EventArgs e)
        {
            MoveItem(leftBox, leftPathBox.Text, rightPathBox.Text);
            LoadPath(leftPathBox.Text, leftBox);
            LoadPath(rightPathBox.Text, rightBox);
        }

        private void moveLeft_Click_1(object sender, EventArgs e)
        {
            MoveItem(rightBox, rightPathBox.Text, leftPathBox.Text);
            LoadPath(rightPathBox.Text, rightBox);
            LoadPath(leftPathBox.Text, leftBox);
        }

        private void CopyItem(RichTextBox sourceBox, string sourcePath, string targetPath)
        {
            string selected = sourceBox.SelectedText.Trim();
            if (string.IsNullOrEmpty(selected)) return;

            if (selected.StartsWith("[DIR]")) selected = selected.Substring(5).Trim();

            string name = Path.GetFileName(selected);
            string dest = Path.Combine(targetPath, name);

            try
            {
                if (Directory.Exists(selected))
                {
                    DirectoryCopy(selected, dest, true);
                }
                else if (File.Exists(selected))
                {
                    File.Copy(selected, dest, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy error: " + ex.Message);
            }
        }

        // Helper for recursive directory copy
        private void DirectoryCopy(string sourceDir, string destDir, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);
            DirectoryInfo[] dirs = dir.GetDirectories();

            Directory.CreateDirectory(destDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                string tempPath = Path.Combine(destDir, file.Name);
                file.CopyTo(tempPath, true);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDir, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private void copyBtn_Click_1(object sender, EventArgs e)
        {
            CopyItem(leftBox, leftPathBox.Text, rightPathBox.Text);
            LoadPath(rightPathBox.Text, rightBox);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selected = leftBox.SelectedText.Trim();
            if (string.IsNullOrEmpty(selected)) return;

            if (selected.StartsWith("[DIR]")) selected = selected.Substring(5).Trim();

            if (MessageBox.Show("Delete " + selected + "?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (Directory.Exists(selected))
                        Directory.Delete(selected, true);
                    else if (File.Exists(selected))
                        File.Delete(selected);

                    LoadPath(leftPathBox.Text, leftBox);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete error: " + ex.Message);
                }
            }
        }

        private void newBtn_Click_1(object sender, EventArgs e)
        {
            string currentPath = leftPathBox.Text;
            DialogResult result = MessageBox.Show("Create File? (No = Folder)", "New", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                string filePath = Path.Combine(currentPath, "NewFile.txt");
                File.Create(filePath).Close();
            }
            else if (result == DialogResult.No)
            {
                string folderPath = Path.Combine(currentPath, "NewFolder");
                Directory.CreateDirectory(folderPath);
            }

            LoadPath(currentPath, leftBox);
        }
    }
}
