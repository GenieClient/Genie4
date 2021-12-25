using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient.Genie
{
    public class Sound
    {
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        static extern int PlaySound(string name, int hmod, int flags);
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        static extern int PlaySound(byte[] name, int hmod, int flags);

        public const int SND_SYNC = 0x0; // play synchronously 
        public const int SND_ASYNC = 0x1; // play asynchronously 
        public const int SND_MEMORY = 0x4;  // Play wav in memory
        public const int SND_ALIAS = 0x10000; // Play system alias wav 
        public const int SND_NODEFAULT = 0x2;
        public const int SND_FILENAME = 0x20000; // name is file name 
        public const int SND_RESOURCE = 0x40004; // name is resource name or atom
        public const int SND_PURGE = 0x40;

        public static void PlayWaveFile(string fileWaveFullPath)
        {
            try
            {
                if (fileWaveFullPath.Contains(@"\") == false)
                {
                    fileWaveFullPath = LocalDirectory.Path + @"\Sounds\" + fileWaveFullPath;
                }

                if (Conversions.ToString(fileWaveFullPath[fileWaveFullPath.Length - 4]) != ".")
                {
                    fileWaveFullPath += ".wav";
                }

                Sound.PlaySound(fileWaveFullPath, 0, SND_FILENAME | SND_ASYNC);
            }
            catch
            {
            }
        }

        public static void PlayWaveResource(string WaveResourceName)
        {
            // get the namespace 
            string strNameSpace = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString();

            // get the resource into a stream
            var resourceStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(strNameSpace + "." + WaveResourceName);
            if (resourceStream is null)
                return;

            // bring stream into a byte array
            byte[] wavData;
            wavData = new byte[Conversions.ToInteger(resourceStream.Length) + 1];
            resourceStream.Read(wavData, 0, Conversions.ToInteger(resourceStream.Length));

            // play the resource
            PlaySound(wavData, 0, SND_ASYNC | SND_MEMORY);
        }

        public static void PlayWaveSystem(string SystemWaveName)
        {
            Sound.PlaySound(SystemWaveName, 0, SND_ALIAS | SND_ASYNC | SND_NODEFAULT);
        }

        public static void StopPlaying()
        {
            // PlaySound(String.Empty, 0, SND_FILENAME Or SND_PURGE)
            string argname = "";
            Sound.PlaySound(argname, 0, SND_NODEFAULT | SND_MEMORY);
        }
    }
}