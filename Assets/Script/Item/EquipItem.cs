using UnityEngine;

public class EquipItem : Equip
{
    public float eatRate;   //¸Ô´Â ¼Óµµ
    private bool eating;    //¸Ô´ÂÁßÀÎÁö
    public ItemData data;

    private Animator animator;

    private PlayerCondition condition;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        condition = CharacterManager.Instance.Player.condition;
    }

    public void Heal()
    {
        if (data.type == ItemType.Consumable)
        {
            for (int i = 0; i < data.consumables.Length; i++)
            {
                switch (data.consumables[i].type)
                {
                    case ConsumableType.Health:
                        condition.Heal(data.consumables[i].value);
                        break;
                    //case ConsumableType.Stamina:
                }
            }
        }
    }

    public override void OnEatInput()
    {
        if (!eating)
        {
            Heal();
            eating = true;
            
            animator.SetTrigger("Eat");
            Invoke("OnCanEat", eatRate);
        }
    }

    public void OnCanEat()
    {
        eating = false;
    }
}
