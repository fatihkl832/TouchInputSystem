using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject player;
    public GameObject spawnpoint;
   
    public float myRange = 45.0f;
    public int TownyCounter = 0;
    public int objectLimit=0; //stats from 0 to 10;

   
     public void spawnThemAll()
    {
        while (objectLimit < 11)
        {
            Vector3 randomSpawnPoint = new Vector3(-27.0f+(Random.Range(-10.0f,10.0f)),0.5f,-31.0f+(Random.Range(-5.0f,5.0f)));
            Instantiate(prefab,randomSpawnPoint,prefab.transform.rotation);
            objectLimit++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnThemAll();
        }
    }

}

