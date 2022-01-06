/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Hold data for Player Detected state for enemies
 * GameObjects associated: Enemies 1 and 2
 * Files Associated: PlayerDetectedState
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerDetectedStateData", menuName = "Data/State Data/Player Detected State")]
public class D_PlayerDetectedState : ScriptableObject
{
    public float longRangeActionTime = 1.5f;
}
