using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Reset : MonoBehaviour
{
    public Transform receiver;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") receiver.GetComponent<BoxCollider>().enabled = true;
    }
}
