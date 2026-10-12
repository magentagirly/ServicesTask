using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _collectButton;
    [SerializeField] private Image _fadeImage;
    [SerializeField] private TMP_Text _scoreText;

    public Image FadeImage => _fadeImage;

    public void SubscribeClose(Action h) => _closeButton.onClick.AddListener(() => h());
    public void UnsubscribeClose(Action h) => _closeButton.onClick.RemoveAllListeners();

    public void SubscribeCollect(Action h) => _collectButton.onClick.AddListener(() => h());
    public void UnsubscribeCollect(Action h) => _collectButton.onClick.RemoveAllListeners();

    public void SetScoreText(int v) => _scoreText.text = v.ToString();
}