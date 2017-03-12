using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;

public class BeatRecorder : MonoBehaviour {

    public string songName; 
    public static BeatRecorder control;
    public static List<Beat> recordedBeats;


    // Use this for initialization
    void Awake () {
		if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
	}
    void Start()
    {
        recordedBeats = new List<Beat>();
    }

    public void SaveMusic()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/" + songName + ".dat", FileMode.Create);

        Debug.Log("Saved!");
        SongData songData = new SongData();
        songData.beats = recordedBeats;
        Debug.Log(songData.beats.Count);
        bf.Serialize(file, songData);
        file.Close();
    }

    public void LoadMusic()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/" + songName + ".dat", FileMode.Open);

        Debug.Log("Loaded!");
        GameManager.startTime = Time.time;
        SongData songData = (SongData)bf.Deserialize(file);
        recordedBeats = songData.beats;
        Debug.Log(recordedBeats.Count);
        file.Close();
    }

}

[Serializable]
public class SongData {
    public List<Beat> beats;
}

[Serializable]
public class Beat
{
    public float beatTime;
    public int drumRef;
    public float beatForce;

    public Beat(float _beatTime, int _drumRef, float _beatForce)
    {
        beatTime = _beatTime;
        drumRef = _drumRef;
        beatForce = _beatForce;
    }
}
