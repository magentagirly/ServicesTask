using System.IO;
using UnityEngine;

[System.Serializable]
public class ScoreData { public int score; }

public class JsonSaver : ISaver
{
    private readonly Score _score;
    public JsonSaver(Score score) => _score = score;

    public void SaveScore(string path = null)
    {
        if (string.IsNullOrEmpty(path))
        {
            Debug.LogError("[JsonSaver] Empty path");
            return;
        }
        var json = JsonUtility.ToJson(new ScoreData { score = _score.Value }, true);
        File.WriteAllText(path, json);
    }

    public int LoadScore(string path = null)
    {
        if (string.IsNullOrEmpty(path) || !File.Exists(path)) return 0;
        var data = JsonUtility.FromJson<ScoreData>(File.ReadAllText(path));
        return data?.score ?? 0;
    }
}