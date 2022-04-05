using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Pistol : MonoBehaviour
{
    public GameObject bullet;
    private Player_Movement player;

    [Header("Properties")]
    public float maxBullets = 5;
    private float bulletCount = 0f;
    public float maxCooldown = 0.3f;
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        player = (Player_Movement)FindObjectOfType(typeof(Player_Movement));

        Instantiate(bullet, player.transform.position, player.transform.rotation);
        bulletCount++;
        cooldown = maxCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown<=0)
        {
            Instantiate(bullet, player.transform.position, player.transform.rotation);
            Debug.Log("GOAL");
            bulletCount++;
            cooldown = maxCooldown;
        }
        cooldown -= Time.deltaTime;

        if (bulletCount >= maxBullets)
        {
            Destroy(this.gameObject);
        }
    }
}
