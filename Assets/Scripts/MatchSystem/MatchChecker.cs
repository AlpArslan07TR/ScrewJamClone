using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class MatchChecker : MonoBehaviour
{
    public List<Transform> screwsInHoldPlace = new List<Transform>(); 
    public Transform holdPlace; 

    
    public void CheckForMatch()
    {
       
        List<Transform> currentScrews = new List<Transform>();

        
        foreach (Transform holdPosition in holdPlace)
        {
            for (int i = 0; i < holdPosition.childCount; i++)
            {
                Transform childScrew = holdPosition.GetChild(i);
                if (childScrew != null) 
                {
                    currentScrews.Add(childScrew); 
                }
            }
        }

        
        Dictionary<string, List<Transform>> screwGroups = new Dictionary<string, List<Transform>>();

        
        foreach (var screw in currentScrews)
        {
            string screwTag = screw.tag; 
            if (!screwGroups.ContainsKey(screwTag))
            {
                screwGroups[screwTag] = new List<Transform>();
            }
            screwGroups[screwTag].Add(screw);
        }

       
        foreach (var group in screwGroups)
        {
            Debug.Log($"Grup: {group.Key}, Vida Sayýsý: {group.Value.Count}"); 
            if (group.Value.Count >= 3) 
            {
                
                foreach (var screw in group.Value)
                {
                    screw.DOScale(Vector3.zero, 0.5f).Kill();
                    screw.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
                    {
                        Destroy(screw.gameObject); 
                    });
                }

                
                return; 
            }
        }

        
        screwsInHoldPlace.Clear();
        screwsInHoldPlace.AddRange(currentScrews);
    }

    public void CheckAndSwapLastScrew()
    {
        if (screwsInHoldPlace.Count < 3) return;

        Transform lastScrew = screwsInHoldPlace[screwsInHoldPlace.Count - 1];
        string lastScrewTag = lastScrew.tag;

        lastScrew.DOKill();
        if (screwsInHoldPlace[screwsInHoldPlace.Count - 2].tag == lastScrewTag &&
            screwsInHoldPlace[screwsInHoldPlace.Count - 3].tag == lastScrewTag)
        {
            return;
        }

        

        for (int i = 0; i < screwsInHoldPlace.Count - 2; i++)
        {
            if (screwsInHoldPlace[i].tag == lastScrewTag &&
                screwsInHoldPlace[i + 1].tag != lastScrewTag)
            {
                
                Transform differentColorScrew = screwsInHoldPlace[i + 1];

                differentColorScrew.DOKill();
                Vector3 lastScrewPos = lastScrew.position;
                Vector3 differentScrewPos = differentColorScrew.position;

                lastScrew.DOMove(differentScrewPos, 0.5f);
                differentColorScrew.DOMove(lastScrewPos, 0.5f);

                
                screwsInHoldPlace[i + 1] = lastScrew;
                screwsInHoldPlace[screwsInHoldPlace.Count - 1] = differentColorScrew;

                return;
            }
        }
    }

    private void ShiftScrewsToFillGaps()
    {
        int targetIndex = 0; 

        
        foreach (Transform screw in screwsInHoldPlace)
        {
            if (screw != null)
            {
                
                Transform targetPosition = screwsInHoldPlace[0].parent.GetChild(targetIndex);
                if (screw.position != targetPosition.position)
                {
                    screw.DOKill();
                    screw.DOMove(targetPosition.position, 0.5f);
                }
                targetIndex++; 
            }
        }

        
        screwsInHoldPlace.RemoveAll(screw => screw == null); 
    }
}
