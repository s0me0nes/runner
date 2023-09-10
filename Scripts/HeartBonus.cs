using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.PickupBonus();
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
