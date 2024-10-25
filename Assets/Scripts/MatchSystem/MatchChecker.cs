using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class MatchChecker : MonoBehaviour
{
    public List<Transform> screwsInHoldPlace = new List<Transform>(); 
    
    public void CheckForMatch()
    {
        
        Dictionary<string, List<Transform>> screwGroups = new Dictionary<string, List<Transform>>();

        foreach (var screw in screwsInHoldPlace)
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
            if (group.Value.Count >= 3) 
            {
                
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
    }
}
