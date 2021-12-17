using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public string PlayerName = "";

	public HighScore HighScore;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}

		LoadHighScore();
	}

	public void UpdateHighScore(int score)
	{
		HighScore = new HighScore()
		{
			playerName = PlayerName,
			highScore = score
		};

		SaveHighScore();
	}

	private void SaveHighScore()
	{
		string json = JsonUtility.ToJson(HighScore);

		File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
	}

	private void LoadHighScore()
	{
		string url = Application.persistentDataPath + "/highscore.json";

		if (File.Exists(url))
		{
			string json = File.ReadAllText(url);

			HighScore = JsonUtility.FromJson<HighScore>(json);
		}
	}
}
