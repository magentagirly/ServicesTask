using UnityEngine;

public class PlayerPrefsSaver : ISaver
{
    private const string KEY = "Score";
    private readonly Score _score;

    public PlayerPrefsSaver(Score score) => _score = score;

    public void SaveScore(string path = null)
    {
        PlayerPrefs.SetInt(KEY, _score.Value);
        PlayerPrefs.Save();
    }

    public int LoadScore(string path = null) => PlayerPrefs.GetInt(KEY, 0);
}