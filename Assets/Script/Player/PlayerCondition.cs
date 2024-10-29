using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    //�������� ���� �� �Լ�
    void TakePhysicalDamage(int damageAmount);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UIConditions uiConditions;

    Condition health { get { return uiConditions.health; } }
    Condition stamina { get { return uiConditions.stamina; } }

    public event Action onTakeDamage;

    private void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);
        
        if (health.curValue <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Die()
    {
        Debug.Log("�׾����ϴ�.");
    }


    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        Debug.Log("�������Ա�");
        onTakeDamage?.Invoke();
    }



}
