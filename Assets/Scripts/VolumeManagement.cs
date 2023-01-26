using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManagement : MonoBehaviour
{
    [SerializeField] GameObject[] sounds;
    float VolumeLevel = 10;
    List<float> originalValues = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = sounds.Length - 1; i > -1; i--)
        {
            originalValues.Add(sounds[i].GetComponent<AudioSource>().volume);
        }
        originalValues.Reverse();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && VolumeLevel > 0)
        {
            VolumeLevel--;
            Debug.Log(VolumeLevel);
            for (int i = sounds.Length - 1; i > -1; i--)
            {
                sounds[i].GetComponent<AudioSource>().volume = sounds[i].GetComponent<AudioSource>().volume - originalValues[i] / 10;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && VolumeLevel < 10)
        {
            VolumeLevel++;
            Debug.Log(VolumeLevel);
            for (int i = sounds.Length - 1; i > -1; i--)
            {
                sounds[i].GetComponent<AudioSource>().volume = sounds[i].GetComponent<AudioSource>().volume + originalValues[i] / 10;
            }
        }
    }
}
