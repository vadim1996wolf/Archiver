﻿using System;
using System.IO;
using System.Windows.Forms;

namespace archiver
{
    public static class FileManipulator
    {
        public static string path  = "";
        public static void WriteFile(string decodedText, string typeFile)
        {
            var locPath = path;
            if (string.IsNullOrEmpty(locPath))
            {
                locPath = "./";
                locPath += typeFile;
            }
            else
            {
                var ind = locPath.LastIndexOf(".");
                if (ind < 0)
                {
                    locPath += typeFile;
                }
                else
                {
                    locPath = locPath.Insert(ind, typeFile);
                }
            }
            var sw1 = new StreamWriter(locPath);
            sw1.Write("{0}", decodedText);
            sw1.Close();
        }

        public static string ReadFile(string file)
        {
            if (!File.Exists(file))
            {
                MessageBox.Show("Error:\nФайл не существует");
                return string.Empty;
            }
            var reader = new StreamReader(file);
        
            var sourceText = string.Empty;
            var buffer = string.Empty;
            while ((buffer = reader.ReadLine()) != null)
            {
                sourceText += buffer;
            }
            return sourceText;
        }
    }
}
