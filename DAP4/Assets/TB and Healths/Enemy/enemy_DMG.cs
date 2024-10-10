using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_DMG : MonoBehaviour
{
    public PlayerDMG playerDMG;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDMG.TakeDamage(50);
            Debug.Log("Hurting the " + collision.gameObject.name);
        }
    }
}
