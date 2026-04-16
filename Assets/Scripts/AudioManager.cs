using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager AM;

    public float volume = 5;

    private float musictimer = 0;

    [SerializeField] private AudioSource song1;
    [SerializeField] private AudioSource song2;

    [SerializeField] private AudioSource sound1;
    [SerializeField] private AudioSource sound2;
    [SerializeField] private AudioSource sound3;
    [SerializeField] private AudioSource sound4;
    [SerializeField] private AudioSource sound5;
    [SerializeField] private AudioSource sound6;
    [SerializeField] private AudioSource sound7;
    [SerializeField] private AudioSource sound8;


    void Awake()
    {
        if (AM == null)
        {
            DontDestroyOnLoad(gameObject);
            AM = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        song1.Play();
        musictimer = 30;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AudioListener.volume = volume / 10.0f;
        musictimer -= Time.fixedDeltaTime;
        if (musictimer < 0)
        {
            if (Random.Range(1, 7) < 2)
            {
                song1.Play();
                musictimer = 30;
            }
            else
            {
                song2.Play();
                musictimer = 60;
            }
        }
    }

    public void Soundboard(int sound)
    {
        if (sound == 1)
        {
            sound1.Play();
        }
        if (sound == 2)
        {
            sound2.Play();
        }
        if (sound == 3)
        {
            sound3.Play();
        }
        if (sound == 4)
        {
            sound4.Play();
        }
        if (sound == 5)
        {
            sound5.Play();
        }
        if (sound == 6)
        {
            sound6.Play();
        }
        if (sound == 7)
        {
            sound7.Play();
        }
        if (sound == 8)
        {
            sound8.Play();
        }
    }
}