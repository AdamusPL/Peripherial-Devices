using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class WaveHeader
    {
        public byte[] riffID;
        public uint riffSize;
        public byte[] wavID;
        public byte[] fmtID;
        public uint fmtSize;
        public ushort audioFormat;
        public ushort channels;
        public uint samplesPerSec;
        public uint bytesPerSec;
        public ushort blockAlignment;
        public ushort bitsPerSample;
        public byte[] dataID;
        public uint dataSize;

        public string GetInfo(string filepath) 
        {
            var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            var binaryReader = new BinaryReader(fileStream);

            try
            {
                riffID = binaryReader.ReadBytes(4);
                riffSize = binaryReader.ReadUInt32();
                wavID = binaryReader.ReadBytes(4);
                fmtID = binaryReader.ReadBytes(4);
                fmtSize = binaryReader.ReadUInt32();
                audioFormat = binaryReader.ReadUInt16();
                channels = binaryReader.ReadUInt16();
                samplesPerSec = binaryReader.ReadUInt32();
                bytesPerSec = binaryReader.ReadUInt32();
                blockAlignment = binaryReader.ReadUInt16();
                bitsPerSample = binaryReader.ReadUInt16();
                dataID = binaryReader.ReadBytes(4);
                dataSize = binaryReader.ReadUInt32();
                
            }
            finally
            {
                binaryReader.Close();
                fileStream.Close();
            }

            return ToString();
        }

        public string ToString()
        {
            return "riffID: " + riffID + "\n" +
                   "size: " + riffSize + "\n" +
                   "wavID: " + wavID + "\n" +
                   "fmtID: " + fmtID + "\n" +
                   "fmtSize: " + fmtSize + "\n" +
                   "format: " + audioFormat + "\n" +
                   "channel: " + channels + "\n" +
                   "sampleRate: " + samplesPerSec + "\n" +
                   "bytePerSec: " + bytesPerSec + "\n" +
                   "blockSize: " + blockAlignment + "\n" +
                   "bit: " + bitsPerSample + "\n" +
                   "dataID: " + dataID + "\n" +
                   "dataSize: " + dataSize + "\n";
        }
    }
}
