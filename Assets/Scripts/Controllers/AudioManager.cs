using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [Header("------------- Audio Clip -------------")]
    public AudioClip mainMusic;
    public AudioClip walking;
    public AudioClip attacking;
    public AudioClip jumping;
    public AudioClip fireBall;
    public AudioClip death;
    public AudioClip hitting;
    public AudioClip click;
    public AudioClip pause;
    public AudioClip unpause;
    public AudioClip mana;
    public AudioClip hurt;
    public AudioClip health;
    public AudioClip respawn;
    public AudioClip bossMusic;

    private void Start(){
        musicSource.clip = mainMusic;
        musicSource.Play();
    }

    public void PlaySFX (AudioClip clip){
        sfxSource.PlayOneShot(clip);
    }
}
