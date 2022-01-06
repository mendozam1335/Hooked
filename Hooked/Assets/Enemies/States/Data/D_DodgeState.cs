/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Hold data for Dodge state for enemies
 * GameObjects associated: Enemies 1 and 2
 * Files Associated: DodgeState
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

[CreateAssetMenu(fileName = "newDodgeStateData", menuName = "Data/State Data/Dodge State")]
public class D_DodgeState : ScriptableObject
{
    public float dodgeSpeed = 10f;
    public Vector2 dodgeAngle;
    public float dodgeTime = 0.2f;
    public float dodgeCoolDown = 2;
}
