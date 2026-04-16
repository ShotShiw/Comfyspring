
using UnityEngine;

public class AccesoriesChanger : MonoBehaviour
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
    public void ChangeAccessorie(int id, Sprite currentAcessory)
    {
        if (id == 0)
        {
            hatSlot.sprite = currentAcessory;

        }
        if (id == 1)
        {
           glassesSlot.sprite = currentAcessory;

        }
        if (id == 2)
        {
            tieSlot.sprite = currentAcessory;

        }
    }
}
