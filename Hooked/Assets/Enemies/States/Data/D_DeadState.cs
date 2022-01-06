/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Hold data for Dead state for enemies
 * Files Associated: DeadState
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

[CreateAssetMenu(fileName = "newDeathStateData", menuName = "Data/State Data/Dead Data")]
public class D_DeadState : ScriptableObject
{
    public GameObject deathChunkParticles;
    public GameObject deathBloodParticles;
    
}
