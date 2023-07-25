using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoretext;
    public float scoreValue = 0f;
    public float points = 1f;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        scoretext.text = ((int)scoreValue).ToString();
        scoreValue += points * Time.fixedDeltaTime;
    }
}
