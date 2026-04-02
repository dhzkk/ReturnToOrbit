using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Initialize()
    {

    }

    protected void BossMove()
    {

    }

    protected virtual void BossAttack()
    {

    }

    protected virtual void TakeDamageBoss()
    {
        //보스 맞으면 피 깎임
        //맞았으면 체력 체크해서 0되면 잠깐 클리어 메세지 띄우고 상점으로 넘어가고 죽음
    }
}
