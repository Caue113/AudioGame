using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    GameObject _StartPosition;

    Rigidbody2D rb;
    AudioSource audioSource;

    Vector2 playerPosition;
    [SerializeField] float playerSpeedX, playerSpeedY;
   
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        InputMovementCheck();

        //Debug.Log(GetGroundCollisionWithRay());
        //Debug.Log(GetGroundCollisionWithRay().tag);
        //Debug.Log(GetGroundCollisionWithRay().GetComponent<BoxCollider2D>().sharedMaterial.name);

    }







    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Objective"))
        {
            Debug.Log("Reached Objective");
        }

        if (collision.collider.CompareTag("Wall"))
        {
            transform.position = _StartPosition.transform.position;
            Debug.Log("Player touched a wall");
        }
    }






    void InputMovementCheck() 
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.position += new Vector3(playerSpeedX * Time.deltaTime, 0, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.position -= new Vector3(playerSpeedX * Time.deltaTime, 0, 0);
        };

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            transform.position += new Vector3(0, playerSpeedY * Time.deltaTime, 0);

        }
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            transform.position -= new Vector3(0, playerSpeedY * Time.deltaTime, 0);
        };
    }


    Collider2D GetGroundCollisionWithRay() 
    {
       return Physics2D.Linecast(transform.position, transform.position + new Vector3(0, 0, 2)).collider;
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
