using UnityEngine;
using DG.Tweening;

using Cysharp.Threading.Tasks;


public class ScrewMovement : MonoBehaviour
{
    public Transform[] holdPositions;     
    public MatchChecker matchChecker;

    private Transform selectedScrew;
    private bool canClick = true;

    private async void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            int screwLayer = LayerMask.GetMask("ScrewLayer");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, screwLayer))
            {
                if (hit.transform.CompareTag("Red Screw") || hit.transform.CompareTag("Blue Screw"))
                {
                    
                    canClick = false;
                    MoveScrew(hit.transform);

                    
                    await UniTask.Delay(1500);
                    canClick = true;
                }
            }
        }
    }

    private void MoveScrew(Transform screw)
    {
        selectedScrew = screw;

        foreach (Transform holdPosition in holdPositions)
        {
            if (holdPosition.childCount == 0)
            {
                selectedScrew.SetParent(holdPosition);
                selectedScrew.DOMove(holdPosition.position, 1f).OnComplete(() =>
                {
                    selectedScrew.DOKill();

                    matchChecker.screwsInHoldPlace.Add(selectedScrew);
                    matchChecker.CheckAndSwapLastScrew(); 
                    matchChecker.CheckForMatch(); 
                });
                return;
            }
        }
    }

}
