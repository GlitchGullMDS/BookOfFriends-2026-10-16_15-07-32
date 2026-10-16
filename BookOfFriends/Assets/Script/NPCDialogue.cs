using UnityEngine;

[System.Serializable]
public class DialogueSet
{
    [TextArea(1, 10)] public string[] Lines; //for the inspectors text lines, I did up to 10 but we SHOULDN'T use dat
}

public class NPCDialogue : MonoBehaviour, IInteractable
{
    [SerializeField] private Dialogue dialogue;
    public DialogueSet Set;
    public void Interact()
    {
        dialogue.StartDialogue(Set.Lines); //begins le dialogue
    }
}
