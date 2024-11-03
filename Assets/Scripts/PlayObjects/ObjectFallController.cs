using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFallController : MonoBehaviour
{
    public Transform FallObject;    // Rectangle GameObject'ine referans
    public Transform[] ObjectHoles;   // Rectangle i�indeki silindirlerin (hole'lar�n) referanslar�
    public float dropDistance = -10f;    // D��me mesafesi
    public float dropDuration = 1f;      // D��me s�resi

    private bool hasFallen = false;      // Rectangle'in d���p d��medi�ini kontrol eder

    private void Update()
    {
        if (!hasFallen && AreHolesEmpty())
        {
            DropObject();
            hasFallen = true; // Bir kere d��t�kten sonra tekrar d��mesin
        }
    }

    private bool AreHolesEmpty()
    {
        foreach (Transform hole in ObjectHoles)
        {
            if (hole.childCount > 0)
            {
                return false; // E�er herhangi bir hole doluysa, d��me i�lemi ba�lamas�n
            }
        }
        return true; // T�m hole�lar bo�sa d��me i�lemi ba�las�n
    }

    private void DropObject()
    {
        FallObject.DOMoveZ(FallObject.position.z + dropDistance, dropDuration).SetEase(Ease.InCubic);
    }
}
