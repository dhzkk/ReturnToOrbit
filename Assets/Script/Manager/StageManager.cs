using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public int CurrentStage = 1;

    [SerializeField] private GameObject[] BackGround;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SkipStage();
        }
        
    }

    private void SkipStage()
    {
        CurrentStage++;
        ApplyStage();
    }

    private void ApplyStage()
    {
        switch (CurrentStage)
        {
            case 2:
                SetBackGround();
                //대충 몹 종류 조절하는 함수
                break;
            case 3:
                SetBackGround();
                //대충 몹 종류 조절하는 함수
                break;
            case 4:
                SceneManager.LoadScene("End");
                break;

        }
    }

    void SetBackGround()
    {
        //스테이지 맞게 배경 설정

        BackGround[CurrentStage - 2].gameObject.SetActive(false);
        BackGround[CurrentStage - 1].gameObject.SetActive(true);
    }

    //대충 몹 종류 조절하는 함수
}
