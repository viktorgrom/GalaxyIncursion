using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : MonoBehaviour
{
    public static void SavePlayer(UniRxStats uniRxStats)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Create);      
        PlayerData data = new PlayerData(uniRxStats);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static int[] LoadPlayer()
    {
        if (File.Exists(Application.persistentDataPath + "/player.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Open);
            PlayerData data = bf.Deserialize(stream) as PlayerData;

            stream.Close();
            return data.stats;
        }
        else
        {
            Debug.LogError("File does not exist");
            return new int[2];
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public int[] stats;
    public PlayerData(UniRxStats uniRxStats)
    {
        stats = new int[2];
        
        stats[0] = uniRxStats.level;        
        stats[1] = uniRxStats.score;
    }
}
