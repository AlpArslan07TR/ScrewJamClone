using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFallController : MonoBehaviour
{
    public Transform FallObject;    // Rectangle GameObject'ine referans
    public Transform[] ObjectHoles;   // Rectangle içindeki silindirlerin (hole'larýn) referanslarý
    public float dropDistance = -10f;    // Düþme mesafesi
    public float dropDuration = 1f;      // Düþme süresi

    private bool hasFallen = false;      // Rectangle'in düþüp düþmediðini kontrol eder

    private void Update()
    {
        if (!hasFallen && AreHolesEmpty())
        {
            DropObject();
            hasFallen = true; // Bir kere düþtükten sonra tekrar düþmesin
        }
    }

    private bool AreHolesEmpty()
    {
        foreach (Transform hole in ObjectHoles)
        {
            if (hole.childCount > 0)
            {
                return false; // Eðer herhangi bir hole doluysa, düþme iþlemi baþlamasýn
            }
        }
        return true; // Tüm hole’lar boþsa düþme iþlemi baþlasýn
    }

    private void DropObject()
    {
        FallObject.DOMoveZ(FallObject.position.z + dropDistance, dropDuration).SetEase(Ease.InCubic);
    }
}
