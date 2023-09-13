using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using SoundLoop.Controller.Extensions;
using SoundLoop.Controller.NAudio;

namespace SoundLoop.Controller
{
    internal class UFileDialog
    {
        public static string FileOpen(string fileter= "音声ファイル(*.wav,*.mp3,*.mp4|*.wav;*.mp3;*.mp4|" + "すべてのファイル(*.*)|*.*")
        {
            try
            {
				string fname = null;
				using (var openDialog = new OpenFileDialog())
				{
					openDialog.Filter = fileter;
					openDialog.FilterIndex = 1;
					openDialog.CheckFileExists = true;
					if (openDialog.ShowDialog() == DialogResult.OK)
						fname = openDialog.FileName;
                    CheckExt(fname);
				}
				return fname;
			}
            catch(Exception ex)
            {
                var message = MessageBox.Show(ex.Message,"確認",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                if(message == DialogResult.OK)
                {
                    return FileOpen();
                }
                return null;
            }

        }
        [Pure]
        public static string InvokeFileOpen(string fname)
        {
            if(!File.Exists(fname) || string.IsNullOrEmpty(fname))
            {
                fname=FileOpen();
            }
            return fname;
        }
        [Pure]
        public static string GetIconPath()
        {
            var iconPath = Directory.GetCurrentDirectory();
            if (string.IsNullOrEmpty(iconPath))
                return null;
            for (int i = 0; i < 4; i++)
            {
                var t = iconPath.LastIndexOf(@"\");
                iconPath = iconPath.Substring(0, t);
            }
            return Path.Combine(iconPath, "Icon", "audio.ico");
        }
        private static bool CheckExt(string fileName)
        {
            var ext = fileName.GetExtensionWithoutPeriod();
            if (ext == FormatsData.WAV || ext == FormatsData.MP4 || ext == FormatsData.MP3)
            {
                return true;
            }
            else
            {
                throw new Exception("拡張子が違います");
            }

        }
    }
}
