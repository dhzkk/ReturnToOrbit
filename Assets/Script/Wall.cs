using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private bool isEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy")) // 스폰 영역 Trigger에 태그 붙임
        {
            isEntered = true; // 이제 적이 안으로 들어왔음
            Debug.Log("적이 안으로 진입 완료");
        }
    }
}
