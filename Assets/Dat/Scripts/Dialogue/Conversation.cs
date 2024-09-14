using System;
using System.Collections.Generic;
using DazuCode;
using TMPro;
using UnityEngine;

public class Conversation: MonoBehaviour
{
    [Header("Speech Content")]
    [SerializeField] private List<SpeechNode> speeches;
    private SpeechNode _currentNode;


    private void Awake()
    {
        _currentNode = speeches.Find(x => x.id == 0);
    }

    public void RunNext()
    {
        if (_currentNode.isEnd)
        {
            this.SendEvent(EventID.DialogueEnding);
            return;
        }
        
        _currentNode = speeches[_currentNode.nextNodeId];
    }
    
    public string GetCurrentContent()
    {
        return _currentNode.dialogue;
    }
}

[Serializable]
public class SpeechNode
{
    public int id;
    public string characterName;
    public string dialogue;
    public Sprite icon;
    public AudioClip audio;
    [Range(0f, 1f)] public float audioVolume;

    public bool isEnd;
    public bool isOption;
    public int nextNodeId;
}

