/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Hold data for charge state for enemies
 * Files Associated: ChargeState 
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

[CreateAssetMenu(fileName = "newChargeStateData", menuName = "Data/State Data/Charge State")]
public class D_ChargeState : ScriptableObject
{
    public float chargeSpeed = 6f;
    public float chargeTime = 2f;
}
