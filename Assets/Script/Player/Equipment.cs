using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public Heldtem curHeld;
    public Transform HeldParent;

    private PlayerController controller;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
        CharacterManager.Instance.Player.addItem += HeldNew;
    }

    public void HeldNew()
    {
        Instantiate(CharacterManager.Instance.Player.itemData.equipPrefab, HeldParent);
    }
}
