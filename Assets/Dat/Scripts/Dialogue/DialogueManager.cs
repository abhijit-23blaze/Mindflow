using System;
using System.Collections;
using System.Collections.Generic;
using DazuCode;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Inst;
    
    [SerializeField] private GameObject chatInteractUI;
    
    private Conversation _currentConversation;
    private ChatBubbleUI _chatUI;
    private bool _inConversation;

    public bool InConversation => _inConversation;

    private void Awake()
    {
        if (Inst != null)
        {
            Destroy(this);
            return;
        }

        Inst = this;
        
        this.SubscribeListener(EventID.DialogueEnding, CloseDialogue);
    }

    private void CloseDialogue(object obj)
    {
        _chatUI.gameObject.SetActive(false);
        _inConversation = false;
    }

    private void OpenDialogue()
    {
        _chatUI.gameObject.SetActive(true);
    }

    public void DisplayChatInteractUI(bool state)
    {
        if (_inConversation) return;
        
        chatInteractUI.gameObject.SetActive(state);
    }
    

    public void StartConversation(Conversation conversation, ChatBubbleUI chat)
    {
        _chatUI = chat;
        _currentConversation = conversation;
        _inConversation = true;
        OpenDialogue();
        ShowContent();
    }

    private void ShowContent()
    {
        _chatUI.SetContent(_currentConversation.GetCurrentContent());
    }

    private void NextContent()
    {
        _currentConversation.RunNext();
        ShowContent();
    }

    private void Update()
    {
        if (_inConversation) chatInteractUI.gameObject.SetActive(false);

        if (Input.GetKeyUp(KeyCode.R))
        {
            Debug.Log("Next Content");
            NextContent();
        }
    }
}

public enum DialogueType
{
    
}
