using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ScObjWeaponsData", menuName = "ScriptableObjects/ScObjWeapons", order = 1)]
public class ScObjWeapons : ScriptableObject
{
    public AnimationType animationType;
    public Sprite sprite;
    public float speed;
    public int damage;
}
