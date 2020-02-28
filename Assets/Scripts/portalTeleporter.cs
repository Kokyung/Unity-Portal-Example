using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTeleporter : MonoBehaviour
{
    public GameObject Player;
    public Transform receiver;

    private bool playerOverlapping = false;

    void Update()
    {
        if (playerOverlapping)
        {
            Debug.Log($"Before Location: {Player.transform.position}");
            Vector3 portalToPlayer = Player.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            Debug.Log($"Dot: {dotProduct}");
            if (dotProduct < 0f) // only transport the player once he's moved across plane
            {
                // transport him to the equivalent position in the other portal
                float rotDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotDiff += 180;
                Player.transform.Rotate(Vector3.up, rotDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotDiff, 0f) * portalToPlayer;

                Player.GetComponent<CharacterController>().enabled = false;

                Player.transform.position = receiver.position + positionOffset;

                Player.GetComponent<CharacterController>().enabled = true;

                playerOverlapping = false;
                Debug.Log($"After Location: {Player.transform.position}");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            receiver.GetComponent<BoxCollider>().enabled = false;
            playerOverlapping = true;
            Debug.Log($"Enter Portal: {Player.transform.position}");
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerOverlapping = false;
            Debug.Log($"Exit Portal: {Player.transform.position}");
        }
    }
    
}
