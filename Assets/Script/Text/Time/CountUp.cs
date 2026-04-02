using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountUp : MonoBehaviour
{
    public float playTime;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;
        timerText.text = "Time : "+ playTime.ToString("F1");
    }
}
