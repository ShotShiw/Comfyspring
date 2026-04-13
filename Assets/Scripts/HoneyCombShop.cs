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
        if (playerPol.nectarCount > 0 && fillTimer < 0 && currentllyClickedOn)
        {
            fillTimer = fillRate;
            playerPol.nectarCount -= 1;
            currentNectar += 1;
            currentNectar = Mathf.Clamp(currentNectar, 0, costToUnlock);
            fillHoneycomb.fillAmount = ((float)currentNectar / costToUnlock);
            playerPol.UpdateNectarCount();
        }
    }

    public void ClickedOnHoneyComb()
    {
        if (currentNectar >= costToUnlock)
        {
            //equip
            Debug.Log("equip item");
            AccesoriesChan.ChangeAccessorie(itemImage.sprite);
        }
        else
        {
            currentllyClickedOn = true;
        }

    }

    public void UnClickedOnHoneyComb()
    {
        currentllyClickedOn = false;
    }
}
