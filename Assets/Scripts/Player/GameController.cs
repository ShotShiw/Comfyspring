using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] AccesoriesChanger acessories;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Back()
    {
        SceneManager.LoadScene("SampleScene");
    }
   public void BuyItem()
    {
        Image img = GetComponent<Image>();
        acessories.ChangeAccessorie(img.sprite);
       
    }
}
