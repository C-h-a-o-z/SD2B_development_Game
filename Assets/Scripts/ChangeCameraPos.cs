using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraPos : MonoBehaviour
{
    bool triggeredCamera;
    Vector3 StartCamPos;
    Vector3 newCamPos;

    bool reachedPos = false;

    float MoveSpeed;
    float startSpeed;
    float posX;
    float posY;
    [SerializeField] Camera maincam;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartCamPos = maincam.transform.position;
        GetComponent<Camera>().orthographicSize = maincam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggeredCamera == true)
        {
            if (MoveSpeed > 0)
            {
                MoveSpeed = MoveSpeed - 1 * Time.deltaTime;
            }
            else if (MoveSpeed < 0)
            {
                MoveSpeed = 0;
                triggeredCamera = false;
                reachedPos = true;
            }

            transform.position = new Vector3(newCamPos.x - ((newCamPos.x - StartCamPos.x) / startSpeed * MoveSpeed), newCamPos.y - (newCamPos.y - StartCamPos.y) / startSpeed * MoveSpeed, -10);
            //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAa

        }

    }

    public void NewCameraTrigger(float spd, Vector3 newpos)
    {
        maincam.enabled = false;
        MoveSpeed = spd;
        startSpeed = spd;
        newCamPos = newpos;
        Start();
        triggeredCamera = true;
    }
}
