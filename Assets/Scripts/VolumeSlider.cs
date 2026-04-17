using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    public Slider sl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(AudioManager.AM == null)
        {
            Debug.LogError("Missing Audio Manager Singleton");
        }
        sl.value = AudioManager.AM.volume / 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SliderSetVolume()
    {
        AudioManager.AM.volume = sl.value * 10;
    }
}
