using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private List<QuestObjective> objectives;

    public bool IsCompleted()
    {
        return true;
    }
    
}

[Serializable]
public class QuestObjective
{
    public enum ObjectiveType
    {
        Collect,    
        Talk,
        Drop,
    }
    
    public ObjectiveType Type { get; set; }
    public int Quantity { get; set; }

    public void Complete()
    {
        
    }
}

