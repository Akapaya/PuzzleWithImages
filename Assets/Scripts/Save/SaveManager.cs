using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region Static Variables
    public static SaveManager Control;
    #endregion

    #region Save Variables
    public static List<bool> LevelsBlock = new List<bool>();
    #endregion

    #region Delegates
    public delegate void SaveImageEvent(int index);
    public static SaveImageEvent SaveImageHandle;
    #endregion

    private void OnEnable()
    {
        SaveImageHandle += SaveImage;
    }

    private void OnDisable()
    {
        SaveImageHandle -= SaveImage;
    }

    private void SaveImage(int index)
    {
        LevelsBlock[index] = false;
        Save();
    }

    #region Start Methods
    void Awake()
    {
        Load();
        if (Control == null)
        {
            DontDestroyOnLoad(gameObject);
            Control = this;
        }
        else
        {
            if (Control != this)
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion

    #region Save Method
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.ddt");

        all data = new all();

        data._level1Block = LevelsBlock[0];
        data._level2Block = LevelsBlock[1];
        data._level3Block = LevelsBlock[2];
        data._level4Block = LevelsBlock[3];
        data._level5Block = LevelsBlock[4];
        data._level6Block = LevelsBlock[5];
        data._level7Block = LevelsBlock[6];
        data._level8Block = LevelsBlock[7];
        data._level9Block = LevelsBlock[8];
        data._level10Block = LevelsBlock[9];
        data._level11Block = LevelsBlock[10];
        data._level12Block = LevelsBlock[11];
        data._level13Block = LevelsBlock[12];
        data._level14Block = LevelsBlock[13];
        data._level15Block = LevelsBlock[14];
        data._level16Block = LevelsBlock[15];
        data._level17Block = LevelsBlock[16];
        data._level18Block = LevelsBlock[17];
        data._level19Block = LevelsBlock[18];
        data._level20Block = LevelsBlock[19];
        data._level21Block = LevelsBlock[20];

        bf.Serialize(file, data);
        file.Close();
        Load();
    }
    #endregion

    #region Load Method
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.ddt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.ddt", FileMode.Open);
            all data = (all)bf.Deserialize(file);
            file.Close();

            LevelsBlock.Add(data._level1Block);
            LevelsBlock.Add(data._level2Block);
            LevelsBlock.Add(data._level3Block);
            LevelsBlock.Add(data._level4Block);
            LevelsBlock.Add(data._level5Block);
            LevelsBlock.Add(data._level6Block);
            LevelsBlock.Add(data._level7Block);
            LevelsBlock.Add(data._level8Block);
            LevelsBlock.Add(data._level9Block);
            LevelsBlock.Add(data._level10Block);
            LevelsBlock.Add(data._level11Block);
            LevelsBlock.Add(data._level12Block);
            LevelsBlock.Add(data._level13Block);
            LevelsBlock.Add(data._level14Block);
            LevelsBlock.Add(data._level15Block);
            LevelsBlock.Add(data._level16Block);
            LevelsBlock.Add(data._level17Block);
            LevelsBlock.Add(data._level18Block);
            LevelsBlock.Add(data._level19Block);
            LevelsBlock.Add(data._level20Block);
            LevelsBlock.Add(data._level21Block);
        }
        else
        {
            CreateSave();
        }
    }

    private void CreateSave()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.ddt");

        all data = new all();

        data._level1Block = true;
        data._level2Block = true;
        data._level3Block = true;
        data._level4Block = true;
        data._level5Block = true;
        data._level6Block = true;
        data._level7Block = true;
        data._level8Block = true;
        data._level9Block = true;
        data._level10Block =true;
        data._level11Block =true;
        data._level12Block =true;
        data._level13Block =true;
        data._level14Block =true;
        data._level15Block =true;
        data._level16Block =true;
        data._level17Block =true;
        data._level18Block =true;
        data._level19Block =true;
        data._level20Block =true;
        data._level21Block = true;

        bf.Serialize(file, data);
        file.Close();
    }
    #endregion
}

#region Save Class
[Serializable]
class all
{
    public bool _level1Block = true;
    public bool _level2Block = true;
    public bool _level3Block = true;
    public bool _level4Block = true;
    public bool _level5Block = true;
    public bool _level6Block = true;
    public bool _level7Block = true;
    public bool _level8Block = true;
    public bool _level9Block = true;
    public bool _level10Block = true;
    public bool _level11Block = true;
    public bool _level12Block = true;
    public bool _level13Block = true;    
    public bool _level14Block = true;
    public bool _level15Block = true;
    public bool _level16Block = true;
    public bool _level17Block = true;
    public bool _level18Block = true;
    public bool _level19Block = true;
    public bool _level20Block = true;
    public bool _level21Block = true;
}
#endregion