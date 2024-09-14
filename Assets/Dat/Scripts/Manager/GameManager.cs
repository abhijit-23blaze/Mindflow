using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    private void Awake()
    {
        if (Inst != null)
        {
            Destroy(this);
            return;
        }
        
        Inst = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        
    }
}
