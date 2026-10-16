using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScorePickup : MonoBehaviour, IPickup
{
    public static event EventHandler<Player.PlayerNumber> OnAnyScorePickup;

    public void OnPickup(Player.PlayerNumber playerNumber)
    {
        OnAnyScorePickup?.Invoke(this, playerNumber);
        Destroy(gameObject);
    }
}
