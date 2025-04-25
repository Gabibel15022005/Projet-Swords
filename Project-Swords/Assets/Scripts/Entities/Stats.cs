using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Physics")]
    public float speed = 1f;
    public float jumpPower = 2f;

    [Space(20)]
    [Header("Stats")]
    public int health = 3;
    public int healthMax = 3;

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
}
