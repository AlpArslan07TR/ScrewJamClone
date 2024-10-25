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
                // Sadece vidalarý yok et
                foreach (var screw in group.Value)
                {
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
}
