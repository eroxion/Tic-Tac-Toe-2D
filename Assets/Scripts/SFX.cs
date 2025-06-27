using UnityEngine;

public class SFX : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip drawSound;
    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }
    
    public void ClickSound()
    {
        _audioSource.PlayOneShot(clickSound);
    }

    internal void GameOverSound(int gameState)
    {
        if (gameState == 0)
        {
            _audioSource.PlayOneShot(drawSound);
        }
        else
        {
            _audioSource.PlayOneShot(winSound);
        }
    }
}
