using UnityEngine;

public class InsectSpawner : MonoBehaviour
{
    public Transform spawnTransform;
    private PlayerController playerController;
    [SerializeField] private GameObject[] flyPrefabs;
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        InvokeRepeating("SpawnInsect", 3, Random.Range(3,5));
    }

    void SpawnInsect()
    {
        if (!playerController.inShop)
        {
            Vector3 spawnPoint = new Vector3(spawnTransform.position.x, spawnTransform.position.y + Random.Range(-4.5f, 4.5f), spawnTransform.position.z);
            int spawnIndex = Random.Range(0, 5);
            if (spawnIndex < 4) spawnIndex = 0;
            else spawnIndex = 1;
            

            var spawnedInsect = Instantiate(flyPrefabs[spawnIndex], spawnPoint, Quaternion.identity);
            spawnedInsect.GetComponent<FlyFunction>().spawnPoint = spawnPoint;
        }
    }
}
