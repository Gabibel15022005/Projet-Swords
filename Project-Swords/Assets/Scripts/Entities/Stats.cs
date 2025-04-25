using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float jumpPower = 2f;

    [Space(20)]
    [Header("Stat")]
    [SerializeField] protected int health = 3;
    [SerializeField] protected int healthMax = 3;
}
