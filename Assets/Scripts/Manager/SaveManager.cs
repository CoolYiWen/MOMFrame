using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System;

/// <summary>
/// Save manager.
/// 加密存储游戏数据
/// </summary>
public class SaveManager : SingletonUnity<SaveManager> {

    #region Config
    // 数据文件相对地址
    private static string fileName = "dataSource/RijndaelData.txt";
    // Rijndael加密算法256位密钥
    private static string key = "hudwk98126fohiw32957ksncfnksad15";
    #endregion

    private static PlayerData Data_instance;
    public static PlayerData Data_Instance
    {
        get
        {
            if (Data_instance == null)
            {
                if(ExistFile() == false){
                    Data_instance = new PlayerData ();
                }

                else
                    Load ();
            }
            return Data_instance;
        }
        set
        {
            Data_instance = value;
            Save ();
        }
    }

    void Start()
    {
        Save ();
    }

    void OnDestroy()
    {
        Save ();   
    }

    // 是否存在该文件
    public static bool ExistFile()
    {
        return File.Exists (getDataPath () + "/" + fileName);
    }

    // 删除该文件
    public static void DeleteDataFile()
    {
        if(ExistFile())
        {
            File.Delete (getDataPath () + "/" + fileName);
        }
    }

    // 保存该文件
    public static void Save()
    {
        string text = JsonFx.Json.JsonWriter.Serialize (Data_Instance);
        text = Encrypt (text);
        File.WriteAllText (getDataPath () + "/" + fileName, text);

    }

    // 读取该文件
    public static void Load()
    {
        if(File.Exists(getDataPath () + "/" + fileName) == false)
        {
            return;
        }
        string orginText = File.ReadAllText (getDataPath () + "/" + fileName);
        orginText = Decrypt (orginText);

        Data_Instance = JsonFx.Json.JsonReader.Deserialize<PlayerData> (orginText);
    }

    // 获取设备路径
    public static string getDataPath()
    {
        if(Application.platform == RuntimePlatform.IPhonePlayer)    //Iphone路径
        {
            string path = Application.dataPath.Substring (0, Application.dataPath.Length - 5);
            path = path.Substring(0, path.LastIndexOf('/'));
            return path + "Documents";
        }
        else if(Application.platform == RuntimePlatform.Android)    //安卓路径
        {
            return Application.persistentDataPath + "/";
        }
        else                                                        //其他路径
        {
            return Application.dataPath;
        }
    }

    // 字符串加密
    public static string Encrypt(string toE)
    {
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes (key);

        RijndaelManaged rDel = new RijndaelManaged ();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateEncryptor ();

        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes (toE);
        byte[] resultArray = cTransform.TransformFinalBlock (toEncryptArray, 0, toEncryptArray.Length);

        return Convert.ToBase64String (resultArray, 0, resultArray.Length);
    }

    // 字符串解密
    public static string Decrypt(string toD)
    {
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes (key);

        RijndaelManaged rDel = new RijndaelManaged ();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateDecryptor ();

        byte[] toEncryptArray = Convert.FromBase64String (toD);
        byte[] resultArray = cTransform.TransformFinalBlock (toEncryptArray, 0, toEncryptArray.Length);

        return UTF8Encoding.UTF8.GetString (resultArray, 0, resultArray.Length);
    }
}
