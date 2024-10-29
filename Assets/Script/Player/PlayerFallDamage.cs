using UnityEngine;

public class PlayerFallDamage : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float fallDamageThreshold = 2f; // 피해를 주기 위한 낙하 높이 기준
    public float fallDamageMultiplier = 10f; // 낙하 속도에 따른 피해 배율
    public float gravityMultiplier = 2f; // 중력 가속도 조절
    private float lastYPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        lastYPosition = transform.position.y;
    }

    private void Update()
    {
        // 중력 가속도를 조정
        AdjustGravity();
        CheckFallDamage();
    }

    private void AdjustGravity()
    {
        // 중력 가속도 조정
        _rigidbody.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
    }

    private void CheckFallDamage()
    {
        // 현재 높이
        float currentYPosition = transform.position.y;
        // 이전 높이와의 차이 계산
        float fallDistance = lastYPosition - currentYPosition;

        // 떨어진 높이가 기준 높이 이상일 경우
        if (fallDistance > fallDamageThreshold)
        {
            // 낙하 속도에 따라 피해를 계산
            float damage = (fallDistance - fallDamageThreshold) * fallDamageMultiplier;
            ApplyDamage(damage);
        }

        // 현재 Y 위치를 이전 위치로 업데이트
        lastYPosition = currentYPosition;
    }

    private void ApplyDamage(float damage)
    {
        // 여기서 데미지를 적용하는 로직을 추가합니다.
        Debug.Log("Damage taken: " + damage);
        // 예: HealthSystem.Instance.TakeDamage(damage);
    }
}