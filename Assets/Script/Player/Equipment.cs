using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public Equip curHeld;
    public Transform HeldParent;

    private PlayerController controller;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
        CharacterManager.Instance.Player.addItem += EquipNew;
    }

    public void EquipNew(ItemData data)
    {
        Instantiate(data.equipPrefab, HeldParent);
    }

    public void OnEatInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curHeld != null)
        {
            Debug.Log("ธิพ๎");
        }
    }
}
