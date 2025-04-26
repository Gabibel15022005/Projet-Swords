using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ScObjWeapons weapon;
    [SerializeField] private Transform pos;

    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private float smoothTimeFast = 0.05f;


    private SpriteRenderer spriteRenderer;

    private bool isFollowingPos = true;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = weapon.sprite;
    }

    void Update()
    {
        if (isFollowingPos) 
        {
            transform.position = Vector3.SmoothDamp(transform.position, pos.position, ref velocity, smoothTime);
        }
    } 
}
