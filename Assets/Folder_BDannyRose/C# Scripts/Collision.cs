using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    public GameObject player;
    public Vector2 dotDirection;
    public Vector2 posPlayer;
    public Dash dash;
    public Inventory2 inv2 = null;
    public Score scr;
    public BackpackControl backpack;
    public int skinAmountModifier;
    private int big;
    private string collisionTag;

    /*
     * Object IDs:
     * [Animals]:
     * ###Peaceful###
     * Deer = 100
     * Fox = 101
     * Grounhog = 102
     * Yak = 103
     * ###Aggressive###
     * Bear = 200
     * Hawk = 201
     * Snow Leopard = 202
     * Wolf = 203
     * ###Strange###
     * Bigfoot = 250
     * [Bonuses]:
     * BerserkerBerries = 300
     * Chest = 301
     * Clothes = 302
     * EnergyDrink = 303
     * Fuel = 304
     * House = 305
     * Jetpack = 306
     * Poacher Camp = 307
     * Snowboard = 308
     * [Roadblocks]
     * Bushes = 400
     * Fallen Tree = 401
     * Snow Pile = 402
     * Stone = 403
     */

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (inv2 == null)
        {
            inv2 = GameObject.Find("InvControl").GetComponent<Inventory2>();
            scr.LoadScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionTag = collision.transform.tag;
        if (collisionTag == "Animal")
        {
            big = (int)collision.gameObject.GetComponent<Enemy>().type;
            if (player.GetComponent<Bonuses>().bonuses.nuclearFuel.active && dash.dashing)
            {
                ;
            }
            else if (big == 1 && Random.Range(0, 101) > GetComponent<PlayerUpgrades>().killChance)
            {
                if (player.GetComponent<Bonuses>().bonuses.mushroom.active)
                {
                    ;
                }
                else if (player.GetComponent<Bonuses>().bonuses.shield.active)
                {
                    player.GetComponent<Bonuses>().bonuses.shield.ShieldUse();
                }
                else
                {
                    player.GetComponent<Death>().Die = true;
                }
            }
            int ID = collision.transform.GetComponent<ObjectID>().ID;
            float impact = collision.transform.GetComponent<ObjectID>().impact;
            Debug.Log(collision.transform.name);
            slowPlayerAnimal(player.GetComponent<Rigidbody2D>(), impact, big);
            Destroy(collision.gameObject);
            Debug.Log("object destroyed");
            if ((big != 1 && GetComponent<PlayerUpgrades>().smallAnimals)
                || (big == 1 && GetComponent<PlayerUpgrades>().bigAnimals))
            {
                inv2.AddItemFromCollision(ID, 1 * skinAmountModifier);
            }
        }
        else if (collisionTag == "Roadblock Collider")
        {
            if (player.GetComponent<Bonuses>().bonuses.nuclearFuel.active && dash.dashing == true)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private void slowPlayerAnimal(Rigidbody2D rb, float impact, int big)
    {
        posPlayer = player.transform.position;
        dotDirection = GameObject.Find("Direction").transform.position;
        Vector2 direction = posPlayer - dotDirection;

        if (big == 0)
        {
            rb.AddForce(direction * (impact * GetComponent<PlayerUpgrades>().smallAnimalImpactModifier));
        }
        else if (big == 1)
        {
            rb.AddForce(direction * (impact * GetComponent<PlayerUpgrades>().bigAnimalImpactModifier));
        }
    }

    private void slowPlayer(Rigidbody2D rb, float impact)
    {
        posPlayer = player.transform.position;
        dotDirection = GameObject.Find("Direction").transform.position;
        Vector2 direction = posPlayer - dotDirection;
        rb.AddForce(direction * impact);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        collisionTag = collision.transform.tag;
        if (collisionTag == "Chest")
        {
            inv2.AddCoinsFromChest();
            Destroy(collision.gameObject);
        }
        else if (collisionTag == "Avalanche")
        {
            player.GetComponent<Death>().Die = true;
        }
        else if (collisionTag == "Bonus")
        {
            int id = collision.GetComponent<BonusID>().ID;

            if (!backpack.StoreBonusItem(id) && !collision.GetComponent<BonusID>().activated)
            {
                Debug.Log("Backpack is not empty, bonus activated immediately");
                player.GetComponent<Bonuses>().ActivateBonus(id);
            }
            collision.GetComponent<BonusID>().activated = true;
            Destroy(collision.gameObject);
        }
        else if (collisionTag == "Camp")
        {
            inv2.AddItemFromCollision(Random.Range(0, 7), Random.Range(1, 4));
        }
        else if (collisionTag == "Roadblock Trigger")
        {
            if (player.GetComponent<Bonuses>().bonuses.nuclearFuel.active && dash.dashing == true)
            {

            }
            else
            {
                float impact = collision.transform.GetComponent<ObjectID>().impact;
                slowPlayer(player.GetComponent<Rigidbody2D>(), impact);
            }
        }
        //else if (collision.transform.parent.gameObject.CompareTag("Animal"))
        //{
        //    Debug.Log(collision.transform.parent.gameObject.name);
        //    Destroy(collision.gameObject);
        //    Destroy(collision.transform.parent.gameObject);
        //    inv2.AddItemFromCollision(collision.transform.GetComponentInParent<ObjectID>().ID, 1);
        //    Debug.Log("object destroyed");

        //}
        /*else
        {
            Destroy(collision.GetComponentInParent<Transform>().gameObject, 1f);
        }*/
        return;
    }
}
