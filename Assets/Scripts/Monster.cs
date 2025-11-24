using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite deadSprite;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    [SerializeField] ParticleSystem particleSystem;
    private bool hasDied;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(ShouldDieFromCollision(collision))
        {
            Die();
        }
    }

    void Die()
    {
        hasDied = true;
        
        //GetComponent<SpriteRenderer>().sprite = deadSprite;
        if (anim.enabled)
        {
            anim.enabled = false;
        }
        
        transform.localScale = new Vector3(1, 1, 0);

        spriteRenderer.sprite = deadSprite;
        particleSystem.Play();

        //gameObject.SetActive(false);
    }

    private bool ShouldDieFromCollision(Collision2D collision)
    {
        if(hasDied)
            return false;

        if(collision.gameObject.tag == "Bird")
        {
            return true;
        }

        // collisions is from above at certain angle (any objects)
        if(collision.contacts[0].normal.y < -0.5) 
        {
            return true;
        }

        return false;
    }

}
