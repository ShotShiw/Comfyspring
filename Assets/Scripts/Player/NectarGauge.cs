using UnityEngine;
using UnityEngine.UI;

public class NectarGauge : MonoBehaviour
{

    public int nectarCount;
    public Image fillGauge;

    public void ChangeCount(int nectarMod)
    {
        nectarCount = nectarMod;
        nectarCount = Mathf.Clamp(nectarCount, 0, 100);
        fillGauge.fillAmount = (float)(nectarCount * 0.01);
    }

}
