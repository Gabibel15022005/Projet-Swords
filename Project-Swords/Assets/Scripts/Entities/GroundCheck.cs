using System.Xml.Serialization;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Color colorCheck;
    [SerializeField] private Transform posCheck;
    [SerializeField] private Vector2 sizeCheck = new Vector2(1,1);
    [SerializeField] private float radiusCheck = 0f;
    [SerializeField] private LayerMask groundLayer;
    [HideInInspector] public bool isGrounded = false;

    void Update()
    {
        Collider2D[] ground = Physics2D.OverlapBoxAll(posCheck.position, sizeCheck, radiusCheck, groundLayer);
        isGrounded = ground.Length > 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = colorCheck;
        Gizmos.DrawWireCube(posCheck.position, sizeCheck);
    }
}
