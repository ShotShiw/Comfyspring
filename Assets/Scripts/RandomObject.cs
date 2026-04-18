using UnityEngine;
using System.Collections.Generic;

public class RandomObject : MonoBehaviour
{

    public List<GameObject> TheObjects = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RollRandomObject();
    }

    public void RollRandomObject()
    {
        foreach (GameObject rgo in TheObjects)
        {
            rgo.SetActive(false);
        }
        int rannum = Random.Range(0, TheObjects.Count);
        GameObject chosenobject = TheObjects[rannum];
        chosenobject.SetActive(true);
    }
}
