using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float interactRange = 2f;

    private void Update()
    {
        var colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        var showChatInteract = false;
            
            
        foreach (var col in colliderArray)
        {
            if (col.TryGetComponent<NPCInteractable>(out var npcInteractable))
            {
                showChatInteract = true;
            }
        }

        DialogueManager.Inst.DisplayChatInteractUI(showChatInteract);
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (DialogueManager.Inst.InConversation) return;
            
            foreach (var col in colliderArray)
            {
                if (col.TryGetComponent<NPCInteractable>(out var npcInteractable))
                {
                    npcInteractable.Interact();
                }
            }

        }
    }
}
