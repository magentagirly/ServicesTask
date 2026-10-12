using System;

public class Score
{
    public event Action<int> OnValueChanged;
    private int _value;

    public int Value
    {
        get => _value;
        private set { _value = value; OnValueChanged?.Invoke(_value); }
    }

    public void Add(int amount = 1) => Value += amount;
    public void SetValue(int v) => Value = v;
}