using UnityEngine;
using System.Collections.Generic;

public class PlantMaster : MonoBehaviour
{

    [SerializeField] private List<PlantSpawner> plants = new List<PlantSpawner>();
    [SerializeField] private List<RandomObject> bugs = new List<RandomObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlant(PlantSpawner newplant)
    {
        plants.Add(newplant);
    }

    public void PlantMasterCheck()
    {
        foreach (PlantSpawner ps in plants)
        {
            ps.CheckStatus();
        }
        foreach (RandomObject ro in bugs)
        {
            ro.RollRandomObject();
        }
    }

}
