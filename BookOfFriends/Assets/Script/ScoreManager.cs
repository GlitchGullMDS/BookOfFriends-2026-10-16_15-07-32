using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int Player1Score { get; private set; } // If you want to make these save between scenes, you can use PlayerPrefs or set this as a static variable
    public int Player2Score { get; private set; }

    // The UI text so the players can see their scores. If you make this script DontDestroyOnLoad, you will need to reassign these references when you load a new scene.
    [SerializeField] private TextMeshProUGUI p1ScoreText;
    [SerializeField] private TextMeshProUGUI p2ScoreText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject); // If you don't want to destroy the ScoreManager when you load a new scene
    }

    private void Start()
    {
        UpdateScoreText();
    }

    private void OnEnable()
    {
        ScorePickup.OnAnyScorePickup += ScorePickup_OnAnyScorePickup;
    }

    private void OnDisable()
    {
        ScorePickup.OnAnyScorePickup -= ScorePickup_OnAnyScorePickup;
    }

    private void ScorePickup_OnAnyScorePickup(object sender, Player.PlayerNumber playerNumber)
    {
        switch (playerNumber)
        {
            case Player.PlayerNumber.Player1:
                Player1Score++;
                break;

            case Player.PlayerNumber.Player2:
                Player2Score++;
                break;
        }

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        p1ScoreText.text = Player1Score.ToString();
        p2ScoreText.text = Player2Score.ToString();
    }
}
