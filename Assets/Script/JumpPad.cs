using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 100f; // 점프 패드의 힘 크기

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌안됌?");
        if (other.CompareTag("Player"))
        {
            // 플레이어의 Rigidbody 가져오기
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // 위쪽 방향으로 힘을 추가하여 점프 효과
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
