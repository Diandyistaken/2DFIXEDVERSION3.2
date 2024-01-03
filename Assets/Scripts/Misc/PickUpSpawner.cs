using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goinCoinPrefab;

    public void DropItems()
    {
        Instantiate(goinCoinPrefab,transform.position, Quaternion.identity);
    }
}
