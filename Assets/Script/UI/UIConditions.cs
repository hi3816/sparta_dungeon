using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConditions : MonoBehaviour
{
    public Condition health;
    public Condition stamina;

    private void Start()
    {
        CharacterManager.Instance.Player.condition.uiConditions = this;
    }
}
