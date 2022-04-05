using UnityEngine;

namespace Properties
{
    [CreateAssetMenu(fileName = "Data_Player_Properties", menuName = "Data/Properties/Player Properties", order = 1)]
    public class Player_Properties : ScriptableObject
    {
        [Header("Running")]
        [Tooltip("Maximum time in seconds the player can run without resting.")] public float maximumStamina = 5f;
        [Tooltip("Time before stamina starts regenerating.")] public float rechargeDelay = 0f;
        [Tooltip("Amount of stamina regenerated per second.")] public float staminaRechargePerSecond = 2f;

        [Header("Speeds")]
        public float SlowWalkSpeed = 0.5f;
        public float WalkSpeed = 1f;
        public float RunSpeed = 2f;
    }

    
    
}


  
