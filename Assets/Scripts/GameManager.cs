using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int score;
    public static int highScore;
    public static int selectedBirdNumber = 0;    
    public static UnityEvent onScoreChanged = new UnityEvent();    
    public static UnityEvent onGameOver = new UnityEvent();
    public static UnityEvent onGameStart = new UnityEvent();
    public List<GameObject> birdsList = new List<GameObject>();
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            LoadData();
            DontDestroyOnLoad(gameObject);
        }
    }
    public static void SendGameStart()
    {
        onGameStart.Invoke();
    }
    public static void SendScoreChanged()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;            
        }    
        onScoreChanged.Invoke();
    }
    public static void SendGameOver()
    {
        if (score >= highScore)
            SavePlayerData();
        onGameOver.Invoke();
    }
    [Serializable]
    class SaveData
    {
        public int highScore;
        public int selectedBirdNumber;
    }
    public static void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.selectedBirdNumber = selectedBirdNumber;
        string jSon = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savehighscore.json", jSon);
    }
    public static int LoadData()
    {
        SaveData data = new SaveData();
        if (File.Exists(Application.persistentDataPath + "/savehighscore.json"))
        {
            string jSon = File.ReadAllText(Application.persistentDataPath + "/savehighscore.json");
            data = JsonUtility.FromJson<SaveData>(jSon);
            highScore = data.highScore;
            selectedBirdNumber = data.selectedBirdNumber;
        }
        else
        {
            selectedBirdNumber = 0;
            highScore = 0;
        }
        return highScore;
    }
}
