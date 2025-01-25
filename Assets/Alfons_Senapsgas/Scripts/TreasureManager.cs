using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    [SerializeField]
    List<TreasuresENUM> treasures = new();

    [SerializeField]
    List<GameObject> treasureObjects = new();

    [SerializeField]
    int treasureAmount = 20;

    [SerializeField]
    AnimationCurve treasureDisplayCurve = new();

    [SerializeField]
    List<Transform> treasureDisplay = new();

    void Start()
    {
        // For loop for randomizing the treasures added
        for (int i = 0; i < treasureAmount; i++)
        {
            AddTreasure((TreasuresENUM)UnityEngine.Random.Range(0, treasureObjects.Count));
        }

        StartCoroutine(DisplayTreasureCoroutine());
    }

    IEnumerator DisplayTreasureCoroutine()
    {
        int treasureDisplayIndex = 0;

        for (int i = 0; i < treasures.Count; i++)
        {
            Instantiate(treasureObjects[Mathf.Clamp((int)treasures[i], 0, treasureObjects.Count)], new Vector3(i, 0, 0), Quaternion.identity, treasureDisplay[treasureDisplayIndex]);
            
            treasureDisplayIndex++;

            if (treasureDisplayIndex >= treasureDisplay.Count)
            {
                treasureDisplayIndex = 0;
            }
            yield return new WaitForSeconds(treasureDisplayCurve.Evaluate(i / 10));
        }
    }

    public void AddTreasure(TreasuresENUM treasure)
    {
        treasures.Add(treasure);
    }
}
