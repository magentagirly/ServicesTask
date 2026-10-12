using System.Threading.Tasks;
using UnityEngine;

public class MainScreenController : IUIState
{
    private readonly MainScreenView _view;
    private readonly UISwitcher _switcher;
    private readonly IFadeService _fade;

    public MainScreenController(MainScreenView view, UISwitcher switcher, IFadeService fade)
    {
        _view = view; _switcher = switcher; _fade = fade;
    }

    public void Enter()
    {
        _view.gameObject.SetActive(true);
        _view.SubscribeOpen(OnOpen);
        _ = _fade.FadeIn(_view.FadeImage, 0.25f);
    }

    public void Exit()
    {
        _view.UnsubscribeOpen(OnOpen);
        _ = _fade.FadeOut(_view.FadeImage, 0.25f);
        _view.gameObject.SetActive(false);
    }

    private void OnOpen() => _switcher.SwitchToPanel();
}