using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler
{
    private AudioMixer _audioMixer;
    private const float OffVolumeValue = -80;
    private const float OnVolumeValue = 0;

    private const string MusicKey = "Music";
    private const string SFXKey = "SFX";

    public AudioHandler (AudioMixer audioMixer)
    {
        _audioMixer = audioMixer;
    }

    private bool IsMusicOn() => IsVolumeOn(MusicKey);
    private bool IsSFXOn() => IsVolumeOn(SFXKey);

    private void OnMusic() => OnVolume(MusicKey);
    private void OffMusic() => OffVolume(MusicKey);
    private void OnSFX() => OnVolume(SFXKey);
    private void OffSFX() => OffVolume(SFXKey);

    public void ToggleMusic()
    {
        if (IsMusicOn())
            OffMusic();
        else
            OnMusic();
    }

    public void ToggleSFX()
    {
        if (IsSFXOn())
            OffSFX();
        else
            OnSFX();
    }
        

    private bool IsVolumeOn(string key) => _audioMixer.GetFloat(key, out float volume) && Mathf.Abs(volume - OnVolumeValue) <= 0.01f;

    private void OnVolume(string key) => _audioMixer.SetFloat(key, OnVolumeValue);
    private void OffVolume(string key) => _audioMixer.SetFloat(key, OffVolumeValue);
}
