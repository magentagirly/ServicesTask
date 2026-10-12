using UnityEngine;

public class UISwitcher : MonoBehaviour
{
    private IUIState _main, _panel, _current;

    public void Initialize(IUIState main, IUIState panel)
    {
        _main = main; _panel = panel; _current = main;
    }

    public void StartUI() => _current?.Enter();

    public void SwitchToPanel()
    {
        if (_current == _panel) return;
        _current?.Exit();
        _current = _panel;
        _current.Enter();
    }

    public void SwitchToMain()
    {
        if (_current == _main) return;
        _current?.Exit();
        _current = _main;
        _current.Enter();
    }
}