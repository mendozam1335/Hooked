/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Hold data for Move state for enemies
 * GameObjects associated: Enemies 1 and 2
 * Files Associated: DodgeState
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

[CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State Data/Move State")]
public class D_MoveState : ScriptableObject
{
    public float movementSpeed = 3f;
    
}
