using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    private Rigidbody bombRB;
    public float speed;
    public float gravityScale = 1;
    public GameObject particle;

    private void Start()
    {
        bombRB = GetComponent<Rigidbody>();
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        Physics.gravity = new Vector3(0, -9.8f, 0);
        StartCoroutine(DestroyObject());

    }

    private void Update()
    {
        bombRB.velocity = transform.forward * speed;
    }

    private void FixedUpdate()
    {
        bombRB.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DownWall")
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }
        else if (collision.gameObject.tag == "RightWall")
        {
            Debug.Log("Gravity Changed");
            Physics.gravity = new Vector3(0, 0, -9.8f);
            transform.eulerAngles = new Vector3(-90f, 180f, 0f);
        }
        else if(collision.gameObject.tag == "UpWall")
        {
            Debug.Log("Gravity Changed");
            Physics.gravity = new Vector3(9.8f, 0, 0);
            transform.eulerAngles = new Vector3(-90f, 0f, 90f);
        }
        else if (collision.gameObject.tag == "LeftWall")
        {
            Debug.Log("Gravity Changed");
            Physics.gravity = new Vector3(0, 0, 9.8f);
            transform.eulerAngles = new Vector3(-90f, 0f, 0f);
        }
        else if (collision.gameObject.tag == "backwardWall")
        {
            Debug.Log("Gravity Changed");
            Physics.gravity = new Vector3(-9.8f, 0, 0);
            transform.eulerAngles = new Vector3(-90f, 0f, -90f);
        }

        if (collision.gameObject.tag == "Turret")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }

    IEnumerator DestroyObject( )
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }


    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "RightWall")
    //    {
    //        Debug.Log("RIGHT GTAVITY");
    //        Physics.gravity = new Vector3(9.8f, 0, 0);
    //        transform.rotation = new Quaternion(-90, transform.rotation.y, transform.rotation.z, 1);
    //    }
    //}
}
