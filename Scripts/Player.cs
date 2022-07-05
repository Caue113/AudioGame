using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField]
    Transform StartPosition;

    Rigidbody2D rb;
    AudioSource audioSource;
    [SerializeField] AudioClip shock;

    Vector2 playerPosition;
    [SerializeField] float playerSpeed;

    public int lifes = 3;
   
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        rb = transform.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        StartPosition = GameObject.Find("StartPosition").transform;
    }

    // Update is called once per frame
    void Update()
    {
        InputMovementCheck();

        //Debug.Log(GetGroundCollisionWithRay());
        //Debug.Log(GetGroundCollisionWithRay().tag);
        //Debug.Log(GetGroundCollisionWithRay().GetComponent<BoxCollider2D>().sharedMaterial.name);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Objective"))
        {
            GameManager.LoadNextLevel();
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("moreu");
            KillPlayer();
        }
    }

    void InputMovementCheck() 
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed, Input.GetAxisRaw("Vertical") * playerSpeed);
    }


    Collider2D GetGroundCollisionWithRay() 
    {
       return Physics2D.Linecast(transform.position, transform.position + new Vector3(0, 0, 2)).collider;
    }

    public void KillPlayer()
    {
        //Return player to spawn
        rb.transform.position = StartPosition.transform.position;

        //Play Shocked SFX
        audioSource.clip = shock;
        audioSource.Play();

        //Remove 1 life
        lifes--;

        //Play Current Situation
        gameManager.PlayGameStatusAudio();
    }




    /* 
     *  STILL DEVELOPING THIS PART
     * 
    
    void CheckMaterialPlayerIsStanding() 
    {

    }

    

    void UpdateMaterialPlayerIsStanding() 
    {
        switch (GetGroundCollisionWithRay().GetComponent<BoxCollider2D>().sharedMaterial.name)
        {
            case "Dirt":
                audioSource.clip =
                    break;

            case "Metal":

                break;

            case "Wood":

                break;
            default:
                audioSource.clip =
            }
    }

    */
}
