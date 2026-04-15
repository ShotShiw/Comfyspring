using UnityEngine;

public class InsectSpawner : MonoBehaviour
{
    public Transform spawnTransform;
    private PlayerController playerController;
    [SerializeField] private GameObject flyPrefab;
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        InvokeRepeating("SpawnInsect", 3, Random.Range(3,5));
    }

    void SpawnInsect()
    {
        if (!playerController.inShop)
        {
            Instantiate(flyPrefab, new Vector3(spawnTransform.position.x, spawnTransform.position.y + Random.Range(-4.5f, 4.5f), spawnTransform.position.z), Quaternion.identity);
        }
    }
}
