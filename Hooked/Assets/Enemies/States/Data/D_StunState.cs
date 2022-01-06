/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Hold data for Stun state for enemies
 * GameObjects associated: Enemies 1 and 2
 * Files Associated: Stun State
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

[CreateAssetMenu(fileName = "newStunStateData", menuName = "Data/State Data/Stun State")]
public class D_StunState : ScriptableObject
{
    public float stunTme = 3f;
    public float stunKnockBackTime = 0.2f;
    public float stunKnockBackSpeed = 20f;
    public Vector2 stunKnockBackAngle;
}
