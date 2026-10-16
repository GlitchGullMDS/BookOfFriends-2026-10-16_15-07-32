using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerNumber
    {
        Player1,
        Player2
    }

    [SerializeField] private PlayerNumber playerNumber = PlayerNumber.Player1; 

    public PlayerNumber GetPlayerNumber()
    {
        return playerNumber;
    }
}
