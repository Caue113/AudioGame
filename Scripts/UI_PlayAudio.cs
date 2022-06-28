using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayAudio : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject objectAudioSource;

    
    [SerializeField] Button buttonPlayAudio;

    AudioSource audioSource;

    void Start()
    {

        audioSource = objectAudioSource.GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        objectAudioSource = GameObject.Find("AudioObject");

        //buttonPlayAudio.onClick.AddListener(PlayAudioOnClick);  Add click function

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudioOnClick() 
    {
        Debug.Log(CalculateDistance(player, objectAudioSource)); //debug reasons

        audioSource.Play();
    }

    float CalculateDistance(GameObject Origin, GameObject Target) 
    {
        float distance = Mathf.Sqrt(
            (Origin.transform.position.x - Target.transform.position.x) * (Origin.transform.position.x - Target.transform.position.x) +
            (Origin.transform.position.y - Target.transform.position.y) * (Origin.transform.position.y - Target.transform.position.y)
            );

        return distance;
    }
}
