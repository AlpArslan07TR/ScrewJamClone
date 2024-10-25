using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class ScrewMatchHandler : MonoBehaviour, IScrewMatchHandler
{
    public void HandleMatch(List<Transform> screws)
    {
        foreach (Transform screw in screws)
        {
            screw.DOScale(Vector3.zero, 0.5f).OnComplete(() => Destroy(screw.gameObject));
        }
    }
}
