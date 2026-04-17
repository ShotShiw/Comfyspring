using UnityEngine;

public class ClearAccs : MonoBehaviour
{

    public SpriteRenderer hatSlot;
    public SpriteRenderer glassesSlot;
    public SpriteRenderer tieSlot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearBeesAccesories()
    {
        AudioManager.AM.Soundboard(8);
        Debug.Log("clear accs");
        hatSlot.sprite = null;
        glassesSlot.sprite = null;
        tieSlot.sprite = null;
    }
}
