using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveProps : MonoBehaviour
{
    public bool Show;
    public GameObject[] gameObjects;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(Show);
            }
        }
    }
}
