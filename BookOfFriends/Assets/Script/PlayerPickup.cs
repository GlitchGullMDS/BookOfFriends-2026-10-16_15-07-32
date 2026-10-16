using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickup pickup = collision.GetComponent<IPickup>();
        if (pickup != null)
        {
            pickup.OnPickup(GetComponentInParent<Player>().GetPlayerNumber());
        }
    }
}
