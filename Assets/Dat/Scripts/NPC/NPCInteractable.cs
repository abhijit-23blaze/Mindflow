using System;
using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField] private Conversation conversation;
    [SerializeField] private ChatBubbleUI chatBubbleUI;

    private bool _isTalking;
    private void Awake()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Start Converation with NPC");
        GetComponent<NPCInteraction>().SetState(NPCInteraction.State.Talk);
        _isTalking = false;
        
        DialogueManager.Inst.StartConversation(conversation, chatBubbleUI);
    }
}
