using UnityEngine;
using TMPro;
using System.Collections;
using System;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI TextComponent;
    private string[] Lines;
    public float TextSpeed;
    private int Index;
    public GameObject Panel;

    public static bool IsActive
    {
        get; //other scripts can access
        private set; 
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        IsActive = false;
    }

    void Start()
    {
        TextComponent.text = string.Empty;
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (!IsActive)
            {return;}
            if (TextComponent.text == Lines[Index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                TextComponent.text = Lines[Index];
            }
        }
    }

    public void StartDialogue(string[] lines) //now pulls an array of strings and lines FROM the NPC interacted with.
    {
        if (IsActive || lines == null || lines.Length == 0)
        { return; }

        else 
        {
            Lines = lines;
            Index = 0;
            IsActive = true;
            Panel.SetActive(true);
            TextComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in Lines[Index].ToCharArray())
        {
            TextComponent.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }

    void NextLine()
    {
        if (Index < Lines.Length - 1)
        {
            Index++;
            TextComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Panel.SetActive(false);
            IsActive = false;
        }
    }
}
