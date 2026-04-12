using UnityEngine;

public class PlayerPollen : MonoBehaviour
{
    [SerializeField] private NectarGauge nectarGauge;

    
    public int pollenCount = 0;



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bee trigger something!");
        if (other.CompareTag("Pollen"))
        {
            Destroy(other.gameObject);
            pollenCount += 5;
            nectarGauge.ChangeCount(pollenCount);
        }
    }
}
