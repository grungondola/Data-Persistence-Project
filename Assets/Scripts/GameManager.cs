using System;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string PlayerName;
    public string HighScorePlayerName;
    public int HighScorePoints;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadHighScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetHighScore(string playerName, int highScore)
    {
        HighScorePlayerName = playerName;
        HighScorePoints = highScore;
    }

    [Serializable]
    public class SaveData
    {
        public string HighScorePlayerName;
        public int HighScorePoints;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData
        {
            HighScorePlayerName = HighScorePlayerName,
            HighScorePoints = HighScorePoints
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText($"{Application.persistentDataPath}/savefile.json", json);
    }

    public void LoadHighScore()
    {
        var filename = $"{Application.persistentDataPath}/savefile.json";
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScorePlayerName = data.HighScorePlayerName;
            HighScorePoints = data.HighScorePoints;
        }
    }
}
