using UnityEngine;

public class PanelController : IUIState
{
    private readonly PanelView _view;
    private readonly UISwitcher _switcher;
    private readonly IFadeService _fade;
    private readonly ISoundPlayer _sound;
    private readonly Score _score;
    private readonly ISaver _saver;

    public const string JsonPath = "score.json";

    public PanelController(PanelView view, UISwitcher sw, IFadeService fade,
        ISoundPlayer sound, Score score, ISaver saver)
    {
        _view = view;
        _switcher = sw;
        _fade = fade;
        _sound = sound;
        _score = score;
        _saver = saver;
    }

    public void Enter()
    {
        Debug.Log("[PanelController] Enter");                    // ← ДОБАВЛЕНО

        _view.gameObject.SetActive(true);
        _view.SubscribeClose(OnClose);
        _view.SubscribeCollect(OnCollect);

        _score.OnValueChanged += _view.SetScoreText;
        _view.SetScoreText(_score.Value);

        _sound.PlayOpenSound();
        _ = _fade.FadeIn(_view.FadeImage, 0.3f);

        Debug.Log("[PanelController] Enter finished, subscribed"); // ← ДОБАВЛЕНО (опционально)
    }

    public void Exit()
    {
        _view.UnsubscribeClose(OnClose);
        _view.UnsubscribeCollect(OnCollect);
        _score.OnValueChanged -= _view.SetScoreText;

        _sound.PlayCloseSound();
        _saver.SaveScore(Application.persistentDataPath + "/" + JsonPath);
        _ = _fade.FadeOut(_view.FadeImage, 0.3f);

        _view.gameObject.SetActive(false);
    }

    private void OnClose() => _switcher.SwitchToMain();

    private void OnCollect()
    {
        Debug.Log("[PanelController] Collect clicked!");          // ← ДОБАВЛЕНО
        _score.Add(1);
        Debug.Log($"[PanelController] Score = {_score.Value}");   // ← ДОБАВЛЕНО
    }
}