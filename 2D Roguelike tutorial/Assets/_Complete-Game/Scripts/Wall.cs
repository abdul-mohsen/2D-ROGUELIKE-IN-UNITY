using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Wall : MonoBehaviour
{
    //public AudioClip chopSound1;                //1 of 2 audio clips that play when the wall is attacked by the player.
    //public AudioClip chopSound2;                //2 of 2 audio clips that play when the wall is attacked by the player.
    public Sprite dmgSprite;                    //Alternate sprite to display after Wall has been attacked by player.
    public int hp = 3;                          //hit points for the wall.
    public AudioClip chop1Sound;
    public AudioClip chop2Sound;


    private SpriteRenderer spriteRenderer;      //Store a component reference to the attached SpriteRenderer.


    void Awake()
    {
        //Get a component reference to the SpriteRenderer.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    //DamageWall is called when the player attacks a wall.
    public void DamageWall(int dmg)
    {
        //Call the RandomizeSfx function of SoundManager to play one of two chop sounds.
        SoundManager.instance.RandomizeSfx(chop1Sound, chop2Sound);

        //Set spriteRenderer to the damaged wall sprite.
        spriteRenderer.sprite = dmgSprite;

        //Randomize the dmg
        int loss = Random.Range(1,dmg+1);

        //Subtract loss from hit point total.
        hp -= loss;

        //If hit points are less than or equal to zero:
        if (hp <= 0)
            //Disable the gameObject.
            gameObject.SetActive(false);
    }
}