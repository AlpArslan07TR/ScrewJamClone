using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFallController : MonoBehaviour
{
    public Transform FallObject;    
    public Transform[] ObjectHoles;   
    public float dropDistance = -10f;    
    public float dropDuration = 1f;      

    private bool hasFallen = false;      

    private void Update()
    {
        if (!hasFallen && AreHolesEmpty())
        {
            StartFallSequence();
            DropObject();
            hasFallen = true; 
        }
    }

    private bool AreHolesEmpty()
    {
        foreach (Transform hole in ObjectHoles)
        {
            if (hole.childCount > 0)
            {
                return false; 
            }
        }
        return true; 
    }
    private void StartFallSequence()
    {
        DropObject();                       
        DestroyAfterDelay();           
    }
    private void DropObject()
    {
        FallObject.DOMoveZ(FallObject.position.z + dropDistance, dropDuration).SetEase(Ease.InCubic);
    }
    private async void DestroyAfterDelay()
    {
        await UniTask.Delay(5000);    
        Destroy(FallObject.gameObject); 
    }
}
