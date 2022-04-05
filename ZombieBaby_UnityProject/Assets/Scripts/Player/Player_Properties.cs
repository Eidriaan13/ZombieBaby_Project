using UnityEngine;

namespace Properties
{
    [CreateAssetMenu(fileName = "Data_Player_Properties", menuName = "Data/Properties/Player Properties", order = 1)]
    public class Player_Properties : ScriptableObject
    {
        [Header("Testing")]
        [Tooltip("")] public float maxLife = 100f;
        [Tooltip("")] public float maxShield = 100f;
        public float speed = 8f;

    }

    
    
}


  
