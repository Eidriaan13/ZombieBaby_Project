using UnityEngine;

namespace Properties
{
    [CreateAssetMenu(fileName = "Data_Weapon_Properties", menuName = "Data/Properties/Weapon Properties", order = 2)]
    public class Weapon_Properties : ScriptableObject
    {

        [Header("Weapon GameObject")]
        [Tooltip("Name of the weapon")] public string weaponName;
        [Tooltip("The gameobject")] public GameObject weapon;
        [Tooltip("Where to put the weapon")] public Vector3 position;

        [Header("Weapon Properties")]
        [Tooltip("Max bullets in the magazine (between 1 and 5)")] public float maxMagazineBullets;
        [Tooltip("Max ammo of the weapon")] public float maxAmmo;
        [Tooltip("Price in-Game of the weapon")] public float inGameWeaponPrice;
        [Tooltip("Price in-Game of the ammo of the weapon")] public float inGameAmmoPrice;
        [Tooltip("Reload time of one bullet of the weapon")] public float maxReloadTime;

        [Header("Weapon Shoot")]
        [Tooltip("The gameobject to instantiate of the shot")] public GameObject shoot;


    }



}
