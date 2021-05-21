using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class GameData
{
    
    public int score;
    public float p;

    public GameData(int score, float p) 
    {

        this.p = p;
        this.score = score;
    }
}
public class SaveLoadManager
{
    public static int control { get; set; }
    public static void Save(string path, GameData gameData)
    {
        using (var fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(fs, gameData);
        }
    }
    public static GameData Load(string path)
    {
        using (var fs = new FileStream(path, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return (GameData)formatter.Deserialize(fs);
        }
    }
}

