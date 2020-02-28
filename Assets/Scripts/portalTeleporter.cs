using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTeleporter : MonoBehaviour
{
    public CharacterController player;
    public Transform receiver;

    private bool playerOverlapping = false;

    void Update()
    {
        if (playerOverlapping)
        {
            Debug.Log($"Before Location: {player.transform.position}");
            Vector3 portalToPlayer = player.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            Debug.Log($"Dot: {dotProduct}");
            if (dotProduct < 1f) // only transport the player once he's moved across plane
            {
                // transport him to the equivalent position in the other portal
                float rotDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotDiff += 180;
                player.transform.Rotate(Vector3.up, rotDiff);

                Vector3 positionOffset = Quaternion.Euler(0, rotDiff, 0) * portalToPlayer;
                player.enabled = false;
                player.transform.position = receiver.position + positionOffset;
                player.enabled = true;

                playerOverlapping = false;
                Debug.Log($"After Location: {player.transform.position}");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            receiver.GetComponent<BoxCollider>().enabled = false;
            playerOverlapping = true;
            Debug.Log($"Enter Portal: {player.transform.position}");
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerOverlapping = false;
            Debug.Log($"Exit Portal: {player.transform.position}");
        }
    }
    
}
