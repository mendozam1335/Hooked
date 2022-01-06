/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Hold data/variables for boss
 * Files Associated: Boss 1 and 2
 * Source:
 *--------------------------------*/
using UnityEngine;

[CreateAssetMenu(fileName = "newBossData", menuName = "Data/Boss Data/Boss Stats")]
public class D_BossData : ScriptableObject
{
    [Header("Boss Stats")]
    public float maxHealth = 1000f;
    public float moveSpeed = 2f;
    public LayerMask whatIsPlayer;

    [Header("Projectile Stats")]
    public float projectileDamage = 10f;
    public float projectileSpeed = 10f;
    public GameObject projectile;
    
    [Header("Close Range Stats")]
    public float closeRangeAttackRadius = 2f;
    public float closeRangeAttackCoolDown = 2.5f;
    public float CRDamage = 10f;

    [Header("Long Range Stats")]
    public float longRangeAttackCoolDown = 2f;
    public float longRangeAttackRadius = 3.5f;

    [Header("Particle Effects")] 
    public GameObject hitParticle;
    public GameObject deadParticle;

}
