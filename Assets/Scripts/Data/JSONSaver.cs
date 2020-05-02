using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Security.Cryptography;

namespace levelmanagement.data
{
    public class JSONSaver
    {
        private static string _fileName = "saveData1.sav";

        public static string GetSaveFileName()
        {
            return Application.persistentDataPath + "/" + _fileName;
        }

        public void Save(SaveData data)
        {
            data.hashValue = String.Empty;

            string json = JsonUtility.ToJson(data);

            data.hashValue = GETSHA256(json);

            json = JsonUtility.ToJson(data);

            string saveFileName = GetSaveFileName();

            FileStream fileStream = new FileStream(saveFileName, FileMode.Create);

            using(StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        }

        public bool Load(SaveData data)
        {
            string loadFileName = GetSaveFileName();
            if (File.Exists(loadFileName))
            {
                using(StreamReader reader = new StreamReader(loadFileName))
                {
                    string json = reader.ReadToEnd();

                    //check hash data
                    if (CheckData(json))
                        JsonUtility.FromJsonOverwrite(json, data);
                    else
                        Debug.LogWarning("JSONSAVER Load: invalid hash. Aborting file read.");
                }
                return true;
            }
                return false;
        }

        public void Delete()
        {
            File.Delete(GetSaveFileName());
        }

        public string GetHexStringFromHash(byte[] hash)
        {
            string hexString = String.Empty;
            foreach (byte b in hash)
            {
                hexString += b.ToString("x2");
            }
            return hexString;
        }


        private string GETSHA256(string text)
        {
            byte[] textToBytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed sHA256Managed = new SHA256Managed();

            byte[] hashValue = sHA256Managed.ComputeHash(textToBytes);

            //return hex string
            return GetHexStringFromHash(hashValue);
        }

        private bool CheckData(string json)
        {
            SaveData tempSaveData = new SaveData();
            JsonUtility.FromJsonOverwrite(json, tempSaveData);

            string oldHash = tempSaveData.hashValue;
            tempSaveData.hashValue = string.Empty;

            string tempJson = JsonUtility.ToJson(tempSaveData);
            string newHash = GETSHA256(tempJson);

            return (oldHash == newHash);
        }

    }
}