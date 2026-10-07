using UnityEngine;
using UnityEngine.Audio;

public class AudioExample : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    private AudioHandler _audioHandler;

    private void Awake()
    {
        _audioHandler = new AudioHandler(_audioMixer);  
    }

    public void ToggleMusic() => _audioHandler.ToggleMusic();
    public void ToggleSFX() => _audioHandler.ToggleSFX();
}
