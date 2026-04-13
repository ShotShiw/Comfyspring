
using UnityEngine;

public class AccesoriesChanger : MonoBehaviour
{
    public SpriteRenderer hatSlot;
    [Header("Sprite")]
    public Sprite[] options;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeAccessorie(Sprite currentAcessory)
    {
        hatSlot.sprite = currentAcessory;

    }
}
