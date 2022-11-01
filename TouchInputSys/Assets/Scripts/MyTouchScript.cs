using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyTouchScript : MonoBehaviour
{
  
    public GameObject player;
    public Joystick joystick;
    public GameObject CoinPos;

    public float height = 0.75f;

    private Touch theTouch;
    private Vector2 touchStartPos, touchEndPosition;

    private float x;
    private float y;
    public float speed = 10.0f;
   
    public SpawnManager spawnManager;
  

   
    void Update()
    {
        TouchInput();   
    }

    public void TouchInput()
    {
        if (Input.touchCount == 1)
        {
            theTouch=Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPos = theTouch.position;
                joystick.transform.position = touchStartPos;
                joystick.gameObject.SetActive(true);
            }
            else if(theTouch.phase == TouchPhase.Moved|| theTouch.phase == TouchPhase.Ended|| theTouch.phase==TouchPhase.Stationary)
            {
                touchEndPosition = theTouch.position;
                 x = touchEndPosition.x - touchStartPos.x;
                 y= touchEndPosition.y - touchStartPos.y;
            }
            else if (theTouch.phase == TouchPhase.Ended)
            {
                joystick.gameObject.SetActive(false);

                x = 0;
                y=0;
            }

            if (joystick.Horizontal > 0.2f || joystick.Horizontal < -0.2f)
            {
                player.transform.Rotate(Vector3.up,joystick.Horizontal*speed/3);
            }
            if (joystick.Vertical > 0.2f || joystick.Vertical < -0.2f)
            {
                player.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * joystick.Vertical * speed*2);
            }
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        { 
            spawnManager.objectLimit--;
       
            other.transform.rotation = player.transform.rotation;
            other.transform.parent = player.transform;

            Vector3 mypos = new Vector3(CoinPos.transform.position.x,height,CoinPos.transform.position.z);
            other.transform.position = mypos;
            height += 0.50f ;

        }
    }
}
