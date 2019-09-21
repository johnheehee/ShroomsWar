using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource levelMusic;
    public AudioSource victoryMusic;


    public bool levelSong = true;
    public bool victorySong = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelMusic()
    {
        levelSong = true;
        victorySong = false;
        levelMusic.Play();
    }

    public void VictorySound()
    {
        if (levelMusic.isPlaying)
            levelSong = false;
        {
            levelMusic.Stop();
        }
        if (!victoryMusic.isPlaying && victorySong == false)
        {
            victoryMusic.Play();
            victorySong = true;
        }
    }

}
