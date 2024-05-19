using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioSlider : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("VolumeValue", 1f);
    }

    public void ChangeValue(float value)
    {
        PlayerPrefs.SetFloat("VolumeValue", value);
        AudioManager.Instance.ChangeVolume(value);
    }

}
