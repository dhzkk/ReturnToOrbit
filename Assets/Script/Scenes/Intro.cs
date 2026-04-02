using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 100 * Time.deltaTime);
        Invoke("LoadPlayScene", 5);
    }

    void LoadPlayScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
