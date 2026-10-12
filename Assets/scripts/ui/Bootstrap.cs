using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [Header("Views")]
    [SerializeField] private MainScreenView _mainScreenView;
    [SerializeField] private PanelView _panelView;
    [SerializeField] private UISwitcher _switcher;

    [Header("Audio")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _openSound;
    [SerializeField] private AudioClip _closeSound;

    [Header("Save")]
    [SerializeField] private bool _useJsonSaver = true;

    private Score _score;

    private void Awake()
    {
        var locator = new ServiceLocator();
        _score = new Score();

        IFadeService fade = new FadeService();
        ISoundPlayer sound = new SoundPlayer(_audioSource, _openSound, _closeSound);
        ISaver saver = _useJsonSaver
            ? new JsonSaver(_score)
            : new PlayerPrefsSaver(_score);

        locator.Register(fade);
        locator.Register(sound);
        locator.Register(saver);
        locator.Register(_score);

        var mainCtrl = new MainScreenController(_mainScreenView, _switcher, fade);
        var panelCtrl = new PanelController(_panelView, _switcher, fade, sound, _score, saver);

        _switcher.Initialize(mainCtrl, panelCtrl);
        _switcher.StartUI();

        // Восстановление счёта
        string path = Application.persistentDataPath + "/" + PanelController.JsonPath;
        _score.SetValue(_useJsonSaver ? saver.LoadScore(path) : saver.LoadScore());
    }
}