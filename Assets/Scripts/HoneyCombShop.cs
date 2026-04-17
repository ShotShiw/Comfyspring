using UnityEngine;
using UnityEngine.UI;

public class HoneyCombShop : MonoBehaviour
{
    public PlayerPollen playerPol;
    private AccesoriesChanger AccesoriesChan;
    public int costToUnlock = 10;
    private float fillRate = 0.2f;
    private float fillTimer;
    private int currentNectar = 0;

    public Image fillHoneycomb;
    public Image itemImage;

    public bool currentllyClickedOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPol = FindFirstObjectByType<PlayerPollen>();
        AccesoriesChan = playerPol.GetComponent<AccesoriesChanger>();
    }

    void FixedUpdate()
    {
        fillTimer -= Time.fixedDeltaTime;
        if (playerPol.nectarCount > 0 && fillTimer < 0 && currentllyClickedOn && currentNectar < costToUnlock)
        {
            fillTimer = fillRate;
            playerPol.nectarCount -= 2;
            currentNectar += 2;
            currentNectar = Mathf.Clamp(currentNectar, 0, costToUnlock);
            fillHoneycomb.fillAmount = ((float)currentNectar / costToUnlock);
            playerPol.UpdateNectarCount();
        }
        if(currentNectar >= costToUnlock)
        {
            itemImage.color = Color.white;
        }
    }

    public void ClickedOnHoneyComb()
    {
        if (currentNectar >= costToUnlock)
        {
            AudioManager.AM.Soundboard(8);
            //equip
            Debug.Log("equip item");
            int accesoryId = gameObject.GetComponent<ID>().idAccessory;
            if (AccesoriesChan != null)
            {
                AccesoriesChan.ChangeAccessorie(accesoryId, itemImage.sprite);
            }
        }
        else
        {
            if (playerPol.nectarCount > 1)
            {
                AudioManager.AM.Soundboard(4);
            }
            currentllyClickedOn = true;
        }

    }

    public void UnClickedOnHoneyComb()
    {
        currentllyClickedOn = false;
    }
}
