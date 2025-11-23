//using System.Numerics;
//using Unity.VisualScripting;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 startPosition;
    [SerializeField] float launchForce = 500f;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.bodyType = RigidbodyType2D.Kinematic; //movement is controlled by codes and not by the physics systems

        // keep track of starting position when game started
        // when mouse is released, launch off towards the starting position

        startPosition = transform.position; //Vector2
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {   
        spriteRenderer.color = Color.lightPink;
    }

    void OnMouseUp()
    {
        Vector2 currentPosition = rb.position;
        Vector2 direction = startPosition - currentPosition;
        direction.Normalize();

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(direction * launchForce);
        spriteRenderer.color = Color.white;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }



}

