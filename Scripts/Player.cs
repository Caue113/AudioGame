using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]
    Transform StartPosition;

    Rigidbody2D rb;
    AudioSource audioSource;
    [SerializeField] AudioClip shock;

    Vector2 playerPosition;
    [SerializeField] float playerSpeed;
   
    void Start()
    {
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
            if (SceneManager.GetActiveScene().name == "Fase 1")
            {
                SceneManager.LoadScene("Fase 2");
            }
            else
            {
                SceneManager.LoadScene("Fase 1"); // muda pra outra coisa se atakfelg

            }
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("moreu");
            isKilled();
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

    public void isKilled()
    {
        rb.transform.position = StartPosition.transform.position;
        audioSource.clip = shock;
        audioSource.Play();
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
