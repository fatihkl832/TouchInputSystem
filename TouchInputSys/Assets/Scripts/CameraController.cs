using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject myCamera;
    private Vector3 offset;
    public GameObject player;
    [SerializeField]public Joystick joystick;
    public float speed = 5.0f;
    public Vector3 finalOffset;
    

    private void Start()
    {
        player = GameObject.Find("Player");
        offset = new Vector3(0, 5, -5);
        finalOffset=offset;  
    }
    void FixedUpdate()
    {
        rotate();
        transform.position = Vector3.Lerp(transform.position,(player.transform.position+finalOffset),0.25f);  
        transform.LookAt(player.transform.position);
    }
    void rotate()
    {
        if(joystick.Horizontal != 0)
        {
             finalOffset = Quaternion.AngleAxis(joystick.Horizontal * 2f, Vector3.up) * finalOffset;
        }
    }
}
