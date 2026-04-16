using UnityEngine;

public class PlayerPollen : MonoBehaviour
{
    [SerializeField] private NectarGauge nectarGauge;

    public int pollenCount = 0; //flowers pollonated
    public int nectarCount = 0; //game currency



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pollen"))
        {
            AudioManager.AM.Soundboard(5);
            other.gameObject.SetActive(false);
            pollenCount += 1;
            nectarCount += 5;
            nectarGauge.ChangeCount(nectarCount);
        }
    }

    public void LosePollen(int lostPollen)
    {
        pollenCount -= lostPollen;
        pollenCount = Mathf.Clamp(pollenCount, 0, 100);
        nectarCount -= (lostPollen * 5);
        nectarCount = Mathf.Clamp(nectarCount, 0, 100);
        nectarGauge.ChangeCount(nectarCount);
    }

    public void UpdateNectarCount()
    {
        nectarGauge.ChangeCount(nectarCount);
    }
}
