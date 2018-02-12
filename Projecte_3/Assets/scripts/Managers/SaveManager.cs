using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveManager { 

    public static void SavePlayer(PlayerBehavior player)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Create);

        PlayerData data = new PlayerData(player);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static float[] LoadPlayer()
    {
        if(File.Exists(Application.persistentDataPath + "/player.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;

            stream.Close();
            return data.stats;
        }
        else
        {
            Debug.LogError("Files does not exist :)");
            return new float[2];//0-0
        }
    }
}

[Serializable]
public class PlayerData
{
    public int genere;
    public float[] stats;

    public PlayerData(PlayerBehavior player)
    {
        stats = new float[2];
        stats[0] = player.maxForce;
        stats[1] = player.maxSpeed;

    }
}

//que vull guardar info dels enemics?
//puvlic class Enemy1Data...
