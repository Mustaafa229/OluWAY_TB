using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                StartCoroutine(teleportPlayer(controller, other.transform, teleportTarget.position));
            }
        }
    }

    IEnumerator teleportPlayer(CharacterController controller, Transform player, Vector3 destination)
    {
        controller.enabled = false;
        player.position = destination;
        Vector3 offset = new Vector3(3f, 0, 0); // Adjust the Y value as needed
        player.transform.position = teleportTarget.position + offset;

        // Wait for a frame to ensure the teleport happens smoothly
        yield return null;

        controller.enabled = true;
    }
}
