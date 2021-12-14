using Puzzle_Image_Game.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game.Feature.Music_Player
{
    public partial class MusicPlayerForm : Form
    {
        public event EventHandler<OnPressPlayButtonMusicPlayer> OnPressPlayButtonMusicPlayer;
        public event EventHandler<EventArgs> OnEndedMusic;

        private MusicPlayerManager musicPlayerManager;

        public MusicPlayerManager MusicPlayerManager { get => musicPlayerManager; set => musicPlayerManager = value; }

        public MusicPlayerForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 File|*.mp3;*.mkv";
            openFileDialog.Multiselect = true;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                string[] names = openFileDialog.SafeFileNames;
                string[] paths = openFileDialog.FileNames;
                MusicPlayerManager.AddSongToListBoxAndSave(names, paths, songsLsbx);
            }

        }

        private void MusicPlayerForm_Load(object sender, EventArgs e)
        {
            MusicPlayerManager = new MusicPlayerManager();
            MusicPlayerManager.LoadMusic(songsLsbx);
        }

        private void songsLsbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (songsLsbx.SelectedIndex < 0) return;
            playBtn.Enabled = delBtn.Enabled = true;
            MusicPlayerManager.SongChoosen
                = MusicPlayerManager.Songs[songsLsbx.SelectedIndex].Path;

            playBtn.Click -= PlayBtn_Click;
            playBtn.Click += PlayBtn_Click;

            delBtn.Click -= DelBtn_Click;
            delBtn.Click += DelBtn_Click;
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MusicPlayerManager.SongChoosen
                    == MusicPlayerManager.SongPlaying) throw new Exception();
                new Thread(() =>
                {
                    File.Delete(MusicPlayerManager.SongChoosen);
                    songsLsbx.Items.Clear();
                    MusicPlayerManager.Songs.Clear();
                    MusicPlayerManager.LoadMusic(songsLsbx);

                }).Start();
            }
            catch
            {
                MessageBox.Show("File is running!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                delBtn.Enabled = false;
                delBtn.Click -= DelBtn_Click;
            }
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            WMPlayer.URL = Path.GetFullPath(MusicPlayerManager.SongChoosen);
            

            MusicPlayerManager.SongPlaying = MusicPlayerManager.SongChoosen;
            MusicPlayerManager.IndexSongPlaying
                = MusicPlayerManager.Songs.FindIndex(
                    (obj) => obj.Path == MusicPlayerManager.SongPlaying);
            OnPressPlayButtonMusicPlayer?.Invoke(sender,
                new Events.OnPressPlayButtonMusicPlayer(
                    Path.GetFileNameWithoutExtension(MusicPlayerManager.SongChoosen)));
            playBtn.Enabled = false;
            playBtn.Click -= PlayBtn_Click;
        }

        private void WMPlayer_PlayStateChange(object sender,
            AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(e.newState == 8)
            {
                OnEndedMusic?.Invoke(sender, new EventArgs());
            }
            else if(e.newState == 1)
            {
                GameFunction.MusicPlayerForm.WMPlayer.Ctlcontrols.play();
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
    }
}
