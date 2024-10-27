using UnityEngine;
using DG.Tweening;


public class ScrewMovement : MonoBehaviour
{
    public Transform[] holdPositions; 
    private Transform selectedScrew; 
    public MatchChecker matchChecker; 

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            
            int screwLayer = LayerMask.GetMask("ScrewLayer");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, screwLayer))
            {
                
                if (hit.transform.CompareTag("Red Screw") || hit.transform.CompareTag("Blue Screw"))
                {
                    MoveScrew(hit.transform);
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
                    matchChecker.screwsInHoldPlace.Add(selectedScrew);
                    matchChecker.CheckAndSwapLastScrew(); // Vida yer de�i�imi kontrol�
                    matchChecker.CheckForMatch(); // E�le�me kontrol�
                });
                return;
            }
        }
    }

}
