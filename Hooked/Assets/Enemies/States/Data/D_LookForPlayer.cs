/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Hold data for Look for Player state for enemies
 * GameObjects associated: Enemies 1 and 2
 * Files Associated: LookForPlayerState
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

[CreateAssetMenu(fileName = "newLookForPLayerStateData", menuName = "Data/State Data/Look for Player State")]
public class D_LookForPlayer : ScriptableObject
{
    public int amountOfTurns = 2;
    public float timeBetweenTurns = 0.75f;
}
