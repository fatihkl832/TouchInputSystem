using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTowny : MonoBehaviour
{

    public GameObject player;
    public  bool isTrigg;
    public float TownySpeed = 10.0f;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (isTrigg)
        {
            gameObject.transform.LookAt(player.transform);
            gameObject.GetComponent<Rigidbody>().AddRelativeForce((Vector3.forward * TownySpeed * Time.deltaTime).normalized);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        isTrigg = true;
    }
}
