/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Hold data for Idle state for enemies
 * GameObjects associated: Enemies 1 and 2
 * Files Associated: IdleState
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

[CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/State Data/Idle State")]
public class D_IdleState : ScriptableObject
{
    public float minIdleTime = 1f;
    public float maxIdleTime = 2f;
}
