using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 100f; // ���� �е��� �� ũ��

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�浹�ȉ�?");
        if (other.CompareTag("Player"))
        {
            // �÷��̾��� Rigidbody ��������
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // ���� �������� ���� �߰��Ͽ� ���� ȿ��
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
