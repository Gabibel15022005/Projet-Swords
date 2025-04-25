using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float jumpPower = 2f;

    [Space(20)]
    [Header("Stats")]
    [SerializeField] protected int health = 3;
    [SerializeField] protected int healthMax = 3;

    protected void ChangeHealth(int amount)
    {
        health += amount;

        if (health > healthMax)
        {
            health = healthMax;
        } 
        else if (health < 0)
        {
            health = 0;
        } 
    }

    public int GetHealthMax() { return healthMax; }
    public float GetSpeed() { return speed; }
    public float GetJumpPower() { return jumpPower; }
}
