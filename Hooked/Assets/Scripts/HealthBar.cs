/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Set correct health value on UI health bar
 * GameObjects associated: Health Bar
 * Files Associated: 
 * Source:
 *--------------------------------*/
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
