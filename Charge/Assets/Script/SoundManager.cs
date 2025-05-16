using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip _buttonClick;
    [SerializeField] AudioClip _charge;
    [SerializeField] AudioClip _clear;
    [SerializeField] AudioClip _miss;
    [SerializeField] AudioClip _shot;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ButtonClick() { audioSource.PlayOneShot(_buttonClick); }
    public void Charge() { audioSource.PlayOneShot(_charge); }
    public void Clear() { audioSource.PlayOneShot(_clear); }
    public void Miss() { audioSource.PlayOneShot(_miss); }
    public void Shot() { audioSource.PlayOneShot(_shot); }
}
