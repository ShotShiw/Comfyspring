using UnityEngine;

public class PlantSpawner : MonoBehaviour
{

    public int pollenCountToUnlock = 0;
    public GameObject targetobject;
    private PlayerPollen playerPol;
    private PlantMaster pm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPol = FindFirstObjectByType<PlayerPollen>();
        pm = GetComponentInParent<PlantMaster>();
        pm.AddPlant(this);
        targetobject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckStatus()
    {
        if (playerPol.pollenCount > pollenCountToUnlock)
        {
            targetobject.SetActive(true);
        }
    }
}
