using UnityEngine;

public class PlayerFallDamage : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float fallDamageThreshold = 2f; // ���ظ� �ֱ� ���� ���� ���� ����
    public float fallDamageMultiplier = 10f; // ���� �ӵ��� ���� ���� ����
    public float gravityMultiplier = 2f; // �߷� ���ӵ� ����
    private float lastYPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        lastYPosition = transform.position.y;
    }

    private void Update()
    {
        // �߷� ���ӵ��� ����
        AdjustGravity();
        CheckFallDamage();
    }

    private void AdjustGravity()
    {
        // �߷� ���ӵ� ����
        _rigidbody.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
    }

    private void CheckFallDamage()
    {
        // ���� ����
        float currentYPosition = transform.position.y;
        // ���� ���̿��� ���� ���
        float fallDistance = lastYPosition - currentYPosition;

        // ������ ���̰� ���� ���� �̻��� ���
        if (fallDistance > fallDamageThreshold)
        {
            // ���� �ӵ��� ���� ���ظ� ���
            float damage = (fallDistance - fallDamageThreshold) * fallDamageMultiplier;
            ApplyDamage(damage);
        }

        // ���� Y ��ġ�� ���� ��ġ�� ������Ʈ
        lastYPosition = currentYPosition;
    }

    private void ApplyDamage(float damage)
    {
        // ���⼭ �������� �����ϴ� ������ �߰��մϴ�.
        Debug.Log("Damage taken: " + damage);
        // ��: HealthSystem.Instance.TakeDamage(damage);
    }
}