using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Player player;
    public static Camera playerCamera;
    public static AudioSource playerAudioSource;

    public static bool blindMode = false;


    public AudioClip[] AudioGameMessages;




    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerCamera = Camera.main;
        playerAudioSource = GameObject.Find("Player").GetComponent<AudioSource>();
    }    
    void Update()
    {
        
    }



    #region Player zone

    #endregion


    public static void LoadNextLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }
    public static void LoadCurrentLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayGameStatusAudio() 
    {
        //stupid huge filter (needs good code here)
        if (player.lifes == 3) 
        {
            playerAudioSource.clip = AudioGameMessages[1];
        }

        if (player.lifes == 2) 
        {
            playerAudioSource.clip = AudioGameMessages[0];
        }

        if (player.lifes == 1)
        {
            playerAudioSource.clip = AudioGameMessages[2];
        }

        if (player.lifes < 1)
        {
            playerAudioSource.clip = AudioGameMessages[7];

            //CHOICE IF PLAYER WANTS TO KEEP PLAYING OR NOT (via menu)

            LoadCurrentLevel();
        }

        playerAudioSource.Play();
    }


}
