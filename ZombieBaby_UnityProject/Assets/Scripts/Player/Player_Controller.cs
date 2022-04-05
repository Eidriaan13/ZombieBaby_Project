using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Properties;

public class Player_Controller : MonoBehaviour
{
    [Header("Config")] 
    public Player_Properties playerProperties;

    [Header("Testing Values")]
    public float currentLife;
    public float currentShield;

    void Awake()
    {
        if (playerProperties != null)
        {
            playerProperties = Instantiate(playerProperties);
            currentLife = playerProperties.maxLife;
            currentShield = playerProperties.maxShield;
        }
        else
        {
            Debug.LogWarning("Player properties not set!");
        }

        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
