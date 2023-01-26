using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicTrigger : MonoBehaviour
{
    bool triggerCinem;
    bool triggerOnce = true;
    bool StartEvents = true;
    [SerializeField] bool changeCamera;
    float CameraSpeed = 5;
    public float cinematicDuration;
    public float durationLeft;
    public GameObject[] Activates;
    [SerializeField] GameObject triggerObj;
    [SerializeField] Vector2 newCamPos;
    [SerializeField] Camera maincam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerCinem == true)
        {
            if (triggerOnce) { durationLeft = cinematicDuration; triggerOnce = false; }

            triggerObj.GetComponent<playerMovement>().CinematicModeTrigger(true);
            if (changeCamera == true)
            {
                changeCamera = false;
                triggerObj.GetComponentInChildren<ChangeCameraPos>().NewCameraTrigger(CameraSpeed, newCamPos);
                durationLeft = durationLeft + CameraSpeed;
            }
            else if (CameraSpeed >= durationLeft && StartEvents)
            {
                StartEvents = false;
                for (int i = 0; Activates.Length > i; i++)
                {
                    Activates[i].SetActive(true);
                    Debug.Log(i);
                }
                
            }
            durationLeft = durationLeft - 1f * Time.deltaTime;
            if (durationLeft <= 0)
            {
               GameObject.Find("Main Camera").GetComponent<Camera>().enabled = true;
               triggerObj.GetComponent<playerMovement>().CinematicModeTrigger(false);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == triggerObj)
        {
            triggerCinem = true;
        }
    }
}
