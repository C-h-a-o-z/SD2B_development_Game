using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI test;
    public int score;
    // Update is called once per frame
    void Update()
    {
        test.text = "Points Earned: " + score.ToString();
    }

    public void scoreAdd()
    {
        score++;
    }
}
