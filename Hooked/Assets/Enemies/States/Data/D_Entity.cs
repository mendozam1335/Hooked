/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Hold data for all enemies
 * GameObjects associated: Enemies 1 and 2
 * Files Associated: 
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{

    public float maxHealth = 30f;

    public float damageHopSpeed = 3f;

    public float groundCheckRadius = 0.3f;
    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;
    public LayerMask whatIsGround;

    public float closeRangeActionDistance = 1f;

    public float maxAgroDistance = 4f;
    public float minAgroDistance = 3f;

    public float stunResistance = 3f;
    public float stunRecoveryTimer = 2f;
    public LayerMask whatIsPlayer;

    public GameObject hitparticle;
}
