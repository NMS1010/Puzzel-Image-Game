using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game.Feature.Music_Player
{
    public class MusicPlayerManager
    {
        private List<Song> songs;
        private static string folderPath = @"Music";
        private string songPlaying;
        private int indexSongPlaying;
        private string songChoosen;

        public MusicPlayerManager()
        {
            songs = new List<Song>();
        }
        static MusicPlayerManager()
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public List<Song> Songs { get => songs; set => songs = value; }
        public string SongPlaying { get => songPlaying; set => songPlaying = value; }
        public string SongChoosen { get => songChoosen; set => songChoosen = value; }
        public int IndexSongPlaying { get => indexSongPlaying; set => indexSongPlaying = value; }

        public void GetSongFromFolder()
        {
            string[] temp = Directory.GetFiles(folderPath);
            
            foreach(string item in temp)
            {
                songs.Add(new Song(item, Path.GetFileName(item)));
            }
        }

        public void LoadMusic(ListBox songsLsbx)
        {
            GetSongFromFolder();
            UpdateListBox(songsLsbx);
        }

        public void AddSongToListBoxAndSave(string[] names,
            string[] paths, ListBox songsLsbx)
        {
            int size = paths.Length;
            
            for (int i = 0; i < size; i++)
            {
                if (!songsLsbx.Items.Contains(names[i]) &&
                    !Songs.Contains(new Song(paths[i], names[i])))
                {
                    Song temp = new Song(paths[i], names[i]);
                    SaveIntoFolder(paths[i], names[i],temp);
                    Songs.Add(temp);
                }
            }
            
            UpdateListBox(songsLsbx);
        }
        private void SaveIntoFolder(string path, string name,Song song)
        {
            if (!File.Exists(folderPath + $"/{name}"))
            {
                File.Copy(path, folderPath + $"/{name}");
                song.Path = folderPath + $"/{name}";
            }
        }

        public void UpdateListBox(ListBox songsLsbx)
        {
            songsLsbx.Items.Clear();
            Songs.Sort(new CompareSong());
            foreach (var item in Songs)
            {
                songsLsbx.Items.Add(item.Name);
            }
        }
    }
}
