using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class NPCHeadLookAt : MonoBehaviour
{
    [SerializeField] private Rig rig;
    [SerializeField] private Transform headLookAtTransform;

    private bool _isLookingAtPosition;
    
    private void Update()
    {
        var targetWeight = _isLookingAtPosition ? 1f : 0f;
        var lerpSpeed = 2f;
        rig.weight = Mathf.Lerp(rig.weight, targetWeight, Time.deltaTime * lerpSpeed);
    }

    public void LookAtPosition(Vector3 lookAtPosition)
    {
        _isLookingAtPosition = true;
        headLookAtTransform.position = lookAtPosition;
    }
}
