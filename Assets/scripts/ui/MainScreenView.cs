using System;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenView : MonoBehaviour
{
    [SerializeField] private Button _openButton;
    [SerializeField] private Image _fadeImage;

    public Button OpenButton => _openButton;
    public Image FadeImage => _fadeImage;

    public void SubscribeOpen(Action h) => _openButton.onClick.AddListener(() => h());
    public void UnsubscribeOpen(Action h) => _openButton.onClick.RemoveAllListeners();
}