using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Characters/Enemies/Normal Enemy")]
public class EnemyData : ScriptableObject
{
    public float health;
    public float damage;
    public float speed;
    public float activeRange;

}
