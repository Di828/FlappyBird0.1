using UnityEngine;
using UnityEngine.Events;
using System;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int highScore;
    public static UnityEvent onScoreChanged = new UnityEvent();    
    public static UnityEvent onGameOver = new UnityEvent();
    public static UnityEvent onGameStart = new UnityEvent();
    private void Awake()
    {
        score = 0;        
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
            SaveHighScore();
        onGameOver.Invoke();
    }
    [Serializable]
    class SaveData
    {
        public int highScore;        
    }
    private static void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        string jSon = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savehighscore.json", jSon);
    }
    public static int LoadHighScore()
    {
        SaveData data = new SaveData();
        if (File.Exists(Application.persistentDataPath + "/savehighscore.json"))
        {
            string jSon = File.ReadAllText(Application.persistentDataPath + "/savehighscore.json");
            data = JsonUtility.FromJson<SaveData>(jSon);
            highScore = data.highScore;
        }
        else
            highScore = 0;
        return highScore;
    }
}
