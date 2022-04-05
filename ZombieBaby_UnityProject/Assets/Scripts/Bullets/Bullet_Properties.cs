using UnityEngine;

namespace Properties
{
    [CreateAssetMenu(fileName = "Data_Bullet_Properties", menuName = "Data/Properties/Bullet Properties", order = 3)]
    public class Bullet_Properties : ScriptableObject
    {
        [Header("Bullet Properties")]
        [Tooltip("")] public string bulletName;
        //[Tooltip("")] public GameObject bullet;
        [Tooltip("")] public Vector3 position;
        [Tooltip("")] public Vector3 direction;
        [Tooltip("Damage of each bullet of the weapon")] public float bulletDamage;
        [Tooltip("Velocity of each bullet of the weapon")] public float bulletVelocity;
        [Tooltip("Max range of the bullet")] public float bulletRange;


    }



}
