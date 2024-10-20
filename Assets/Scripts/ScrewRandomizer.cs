using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewRandomizer : MonoBehaviour
{
    public GameObject redScrewPrefab;
    public GameObject blueScrewPrefab;
    public Transform[] holePositions; 

    private void Start()
    {
        DistributeScrews();
    }

    void DistributeScrews()
    {
        
        Transform[] availablePositions = holePositions;

        
        for (int i = 0; i < 3; i++)
        {
            PlaceScrew(redScrewPrefab, ref availablePositions);
            PlaceScrew(blueScrewPrefab, ref availablePositions);
        }
    }

    void PlaceScrew(GameObject screwPrefab, ref Transform[] availablePositions)
    {
        int randomIndex = Random.Range(0, availablePositions.Length);
        Instantiate(screwPrefab, availablePositions[randomIndex].position, Quaternion.identity);

        
        availablePositions = RemoveAt(availablePositions, randomIndex);
    }

    Transform[] RemoveAt(Transform[] array, int index)
    {
        var newArray = new Transform[array.Length - 1];
        for (int i = 0, j = 0; i < array.Length; i++)
        {
            if (i != index)
            {
                newArray[j++] = array[i];
            }
        }
        return newArray;
    }
}
