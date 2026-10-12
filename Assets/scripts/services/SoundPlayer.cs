using UnityEngine;

public class SoundPlayer : ISoundPlayer
{
    private readonly AudioSource _source;
    private readonly AudioClip _open;
    private readonly AudioClip _close;

    public SoundPlayer(AudioSource source, AudioClip open, AudioClip close)
    {
        _source = source;
        _open = open;
        _close = close;
    }

    public void PlayOpenSound() { if (_open) _source.PlayOneShot(_open); }
    public void PlayCloseSound() { if (_close) _source.PlayOneShot(_close); }
}