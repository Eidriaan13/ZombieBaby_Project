using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Properties;


public class Bullet_Controller : MonoBehaviour
{
    [Header("Info")]
    public string weaponName;

    [Header("Config")]
    public Bullet_Properties bulletProperties;

    [Header("Testing Values")]
    public float bulletDamage;
    public float bulletVelocity;
    public float bulletRange;
    public Vector3 bulletDirection;
    private Vector3 initialPosition;

    private Player_Movement player;
    void Awake()
    {
        
            bulletProperties = Instantiate(bulletProperties);
            bulletDamage = bulletProperties.bulletDamage;
            bulletVelocity = bulletProperties.bulletVelocity;
            bulletRange = bulletProperties.bulletRange;
        
        
        
            Debug.LogWarning("Bullet properties not set!");

        initialPosition = transform.position;
        player = (Player_Movement)FindObjectOfType(typeof(Player_Movement));
        bulletDirection = player.GetForward();
        transform.rotation = Quaternion.LookRotation(bulletDirection);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, initialPosition);
        if (dist >= bulletRange)
        {
            Destroy(this.gameObject);
        }

        transform.position += bulletDirection * bulletVelocity * Time.deltaTime;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(this.gameObject);
    }


}
