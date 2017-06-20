using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32.TaskScheduler;

namespace FileMonitor
{
   public partial class FileMonitorInitForm : Form
   {
      private FileSystemWatcher watcher;
      private NotifyIcon notifyIcon;
      private string notificationPath;
      private TaskService ts = new TaskService();
      private string taskName;

      public FileMonitorInitForm()
      {
         InitializeComponent();

         initializeChecklist();
         btnBrowse.Click += BtnBrowse_Click;
         btnStart.Click += BtnStart_Click;

         //FormClosing += FileMonitorInitForm_FormClosing;

         checkCommandLine();
      }

      private void FileMonitorInitForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         /*
         if (e.CloseReason == CloseReason.UserClosing)
         {
            endMonitor();
         }
         */
      }

      private void checkCommandLine()
      {
         //args: <this exe>, <fullpath (string)>, <NotifyFilter (int)>
         string[] s = Environment.GetCommandLineArgs();
         if (s.Length >= 2)
         {
            if (!Directory.Exists(s[1]) && !File.Exists(s[1]))
            {
               if (Directory.GetParent(s[1]).Exists)
               {
                  txtFolder.Text = Directory.GetParent(s[1]).FullName;
                  txtFilter.Text = (new FileInfo(s[1])).Name;
               }
               else
               {
                  MessageBox.Show("Invalid path: " + s[1], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  Load += (s_, e) => Close();
               }
            }
            else
            {
               if ((System.IO.File.GetAttributes(s[1]) & FileAttributes.Directory) == FileAttributes.Directory)
               {
                  txtFolder.Text = s[1];
                  txtFilter.Text = "*";
               }
               else
               {
                  txtFolder.Text = Directory.GetParent(s[1]).FullName;
                  txtFilter.Text = (new FileInfo(s[1])).Name;
               }
            }
            if (s.Length >= 3)
            {
               if (s.Length == 4)
               {
                  IncludeSubdirs.Checked = s[3].Equals("/r", StringComparison.OrdinalIgnoreCase);
               }
               else
               {
                  IncludeSubdirs.Checked = true;
               }
               int filter;
               if (int.TryParse(s[2], out filter))
               {
                  start((NotifyFilters)filter);
                  //setTaskName();
               }
            }
         }
      }

      private void initializeChecklist()
      {
         notifyFiltersChecklistBox.CheckOnClick = true;
         ContextMenuStrip ctx = new ContextMenuStrip();

         ctx.Items.Add("Select All", null, (s, e) => SelectAll(true));
         ctx.Items.Add("Deselect All", null, (s, e) => SelectAll(false));

         notifyFiltersChecklistBox.ContextMenuStrip = ctx;

         NotifyFilters[] notifyFilters = (NotifyFilters[])Enum.GetValues(typeof(NotifyFilters));
         for (int i = 0; i < notifyFilters.Length; i++)
         {
            if (i == 0 || i == 1 || i == 4 || i == 6)
            {
               notifyFiltersChecklistBox.Items.Add(notifyFilters[i].ToString(), true);
            }
            else
            {
               notifyFiltersChecklistBox.Items.Add(notifyFilters[i].ToString(), false);
            }
         }
      }

      private void SelectAll(bool select)
      {
         for (int i = 0; i < notifyFiltersChecklistBox.Items.Count; i++)
         {
            notifyFiltersChecklistBox.SetItemChecked(i, select);
         }
      }

      private void start(NotifyFilters filter = 0)
      {
         if (!Directory.Exists(txtFolder.Text))
         {
            MessageBox.Show("Invalid path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }

         initializeWatcher(filter);
         initializeNotifyIcon();
         initializeTask();

         Hide();
         Shown += HideEvent;
      }

      private void HideEvent(object sender, EventArgs e)
      {
         //add this to Shown event to hide form before shown
         Hide();
         Shown -= HideEvent;
      }

      private void BtnStart_Click(object sender, EventArgs e)
      {
         start();
      }

      private void initializeTask()
      {
         if (RunAtLogin.Checked)
         {
            createStartupTask();
         }
      }

      private void initializeWatcher(NotifyFilters filter = 0)
      {
         watcher = new FileSystemWatcher(txtFolder.Text, txtFilter.Text);
         watcher.IncludeSubdirectories = IncludeSubdirs.Checked;
         watcher.NotifyFilter = filter;
         if (watcher.NotifyFilter == 0)
         {
            for (int idx = 0; idx < notifyFiltersChecklistBox.Items.Count; idx++)
            {
               if (!notifyFiltersChecklistBox.GetItemChecked(idx))
               {
                  continue;
               }
               Array filters = Enum.GetValues(typeof(NotifyFilters));
               for (int i = 0; i < filters.Length; i++)
               {
                  if (notifyFiltersChecklistBox.Items[idx].ToString()
                      == filters.GetValue(i).ToString())
                  {
                     watcher.NotifyFilter |= (NotifyFilters)Enum.Parse(typeof(NotifyFilters),
                         notifyFiltersChecklistBox.Items[idx].ToString());
                  }
               }
            }
         }

         watcher.Changed += Watcher_Changed;
         watcher.Renamed += Watcher_Renamed;
         watcher.Created += Watcher_Changed;
         watcher.Deleted += Watcher_Changed;
         watcher.Error += Watcher_Error;

         watcher.EnableRaisingEvents = true;
      }

      private void Watcher_Error(object sender, ErrorEventArgs e)
      {
         if (MessageBox.Show("Internal error occurred within the FileSystemWatcher object: " +
             e.GetException().GetType().ToString() + ": " + e.GetException().Message +
             ".\n\nWould you like to continue monitoring this directory?",
             "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
         {
            Close();
         }
      }

      private void initializeNotifyIcon()
      {
         notifyIcon = new NotifyIcon();
         notifyIcon.Icon = Properties.Resources.file_integrity_monitoring;

         //set text
         setNotifyIconText();

         //context menu
         ContextMenuStrip ctx = new ContextMenuStrip();
         ctx.Items.Add("Restart", null, RestartContextItemClicked);
         ctx.Items.Add("Open Directory", null, (s, e) => System.Diagnostics.Process.Start(watcher.Path));
         ctx.Items.Add("Exit", null, (s, e) => { endMonitor(); Close(); });

         notifyIcon.ContextMenuStrip = ctx;

         notifyIcon.MouseClick += (s, e) =>
         {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) { return; }
            System.Diagnostics.Process.Start(watcher.Path);
            setNotifyIconText();
         };

         notifyIcon.BalloonTipClicked += (s, _e) => NotifyIcon_BalloonTipClicked();

         notifyIcon.Visible = true;
      }

      private void setNotifyIconText()
      {
         //set text
         notifyIcon.Text = "Monitoring \"";
         int maxPathLength = 63 - notifyIcon.Text.Length;
         string trimmedPath = watcher.Path;
         int lastSlashIdx = watcher.Path.LastIndexOf('\\');
         if (lastSlashIdx < 0 || watcher.Path.LastIndexOf('/') > lastSlashIdx)
         {
            lastSlashIdx = watcher.Path.LastIndexOf('/');
         }
         string pathText = watcher.Path.Substring(lastSlashIdx);
         lastSlashIdx = trimmedPath.LastIndexOf('\\');
         if (lastSlashIdx < 0 || watcher.Path.LastIndexOf('/') > lastSlashIdx)
         {
            lastSlashIdx = trimmedPath.LastIndexOf('/');
         }
         trimmedPath = trimmedPath.Substring(0, lastSlashIdx);

         while (true)
         {
            int idx = trimmedPath.LastIndexOf('\\');
            if (idx < 0 || trimmedPath.LastIndexOf('/') > idx)
            {
               idx = trimmedPath.LastIndexOf('/');
            }
            string tempPathText;
            if (idx < 0)
            {
               tempPathText = trimmedPath + pathText;
               trimmedPath = "";
            }
            else
            {
               tempPathText = trimmedPath.Substring(idx) + pathText;
               trimmedPath = trimmedPath.Substring(0, idx);
            }
            if (tempPathText.Length >= maxPathLength)
            {
               break;
            }
            pathText = tempPathText;
            if (string.IsNullOrWhiteSpace(trimmedPath))
            {
               break;
            }
         }

         notifyIcon.Text += pathText + '\"';
         if (notifyIcon.Text.Length <= 61)
         {
            notifyIcon.Text += "...";
         }
      }

      private void endMonitor()
      {
         try
         {
            notifyIcon.Dispose();
            watcher.Dispose();
            removeStartupTask();
         }
         catch (Exception ex)
         {
            return;
         }
      }

      private void RestartContextItemClicked(object sender, EventArgs e)
      {
         endMonitor();
         Show();
      }

      private void Watcher_Changed(object sender, FileSystemEventArgs e)
      {
         notifyIcon.Text = "Change detected! Click to open";
         notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
         notifyIcon.BalloonTipTitle = "Change to \"" + e.Name + '\"';
         notifyIcon.BalloonTipText = '\"' + e.FullPath + "\" has been " + e.ChangeType.ToString().ToLower() + ". Click this balloon to open the directory.";

         notificationPath = Directory.Exists(e.FullPath) ? e.FullPath : Directory.GetParent(e.FullPath).FullName;

         notifyIcon.ShowBalloonTip(30000);
      }

      private void Watcher_Renamed(object sender, RenamedEventArgs e)
      {
         notifyIcon.Text = "Rename detected! Click to open";
         notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
         notifyIcon.BalloonTipTitle = "Change to \"" + e.OldName + '\"';
         notifyIcon.BalloonTipText = '\"' + e.OldFullPath + "\" has been renamed to " + e.Name +
             ". Click this balloon to open the directory.";

         notificationPath = Directory.Exists(e.FullPath) ? e.FullPath : Directory.GetParent(e.FullPath).FullName;

         notifyIcon.ShowBalloonTip(30000);
         notifyIcon.BalloonTipClosed += (s, e_) => setNotifyIconText();
      }

      private void NotifyIcon_BalloonTipClicked()
      {
         if (Directory.Exists(notificationPath))
         {
            System.Diagnostics.Process.Start(notificationPath);
         }
         else if (File.Exists(notificationPath))
         {
            string directory = notificationPath.Remove(notificationPath.LastIndexOf('\\'));
            System.Diagnostics.Process.Start(directory);
         }
         else
         {
            MessageBox.Show("Error opening directory: " + notificationPath, "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         setNotifyIconText();
         //watcher.Dispose();
         //notifyIcon.Dispose();
         //Show();
      }

      private void BtnBrowse_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();
         ofd.FileName = "Folder Selection";
         ofd.CheckFileExists = false;
         ofd.Multiselect = false;
         ofd.Title = "Select File or Folder";

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            txtFolder.Text = ofd.FileName.Substring(0, ofd.FileName.LastIndexOf('\\'));
            string filename = ofd.FileName.Remove(0, ofd.FileName.LastIndexOf('\\') + 1);
            if (String.Equals(filename, "Folder Selection", StringComparison.OrdinalIgnoreCase))
            {
               txtFilter.Text = "*";
            }
            else
            {
               txtFilter.Text = filename;
            }
         }
      }

      private void createStartupTask()
      {
         TaskDefinition td = ts.NewTask();
         td.RegistrationInfo.Description = "Monitors " + txtFolder.Text + " for files of format \""
             + txtFilter.Text + "\" with changes in";

         Array notifyFilters = Enum.GetValues(typeof(NotifyFilters));
         foreach (object s in notifyFilters)
         {
            NotifyFilters f = (NotifyFilters)Enum.Parse(typeof(NotifyFilters), s.ToString());
            if ((f & watcher.NotifyFilter) == f)
            {
               td.RegistrationInfo.Description += ' ' + f.ToString() + ',';
            }
         }
         if (td.RegistrationInfo.Description.IndexOf(',') != td.RegistrationInfo.Description.LastIndexOf(','))
         {
            string lastItem = td.RegistrationInfo.Description.Substring(td.RegistrationInfo.Description.LastIndexOf(' '));
            lastItem.Replace(" ", " and ");
            td.RegistrationInfo.Description = td.RegistrationInfo.Description.Remove(td.RegistrationInfo.Description.LastIndexOf(' '));
            td.RegistrationInfo.Description += lastItem;
         }
         int idx = td.RegistrationInfo.Description.LastIndexOf(',');
         if (idx > 0)
         {
            td.RegistrationInfo.Description = td.RegistrationInfo.Description.Remove(idx);
            td.RegistrationInfo.Description += '.';
         }
         else
         {
            td.RegistrationInfo.Description += " [no attributes selected].";
         }

         td.Triggers.Add(new LogonTrigger());

         string filePath = Application.ExecutablePath;
         string arguments = "\"" + txtFolder.Text +
             (txtFilter.Text.Contains("*") ? "" : '\\' + txtFilter.Text) + "\" " +
             (int)watcher.NotifyFilter + (IncludeSubdirs.Checked ? " /r" : " /nr");


         td.Actions.Add(filePath, arguments);

         setTaskName();

         td.Settings.ExecutionTimeLimit = new TimeSpan(0);

         ts.RootFolder.RegisterTaskDefinition(taskName, td);
      }

      private void setTaskName()
      {
         taskName = "Monitor_" + (watcher.Path + (txtFilter.Text.Contains("*") ? "" :
             '\\' + txtFilter.Text)).Replace('\\', '-') + '_' + (int)watcher.NotifyFilter;
         taskName = taskName.Replace('/', '-');
         int idx = taskName.IndexOf(':');
         if (idx >= 0)
         {
            taskName = taskName.Remove(idx, 1);
         }
      }

      private void removeStartupTask()
      {
         if (!string.IsNullOrWhiteSpace(taskName))
         {
            ts.RootFolder.DeleteTask(taskName, false);
         }
      }
   }
}