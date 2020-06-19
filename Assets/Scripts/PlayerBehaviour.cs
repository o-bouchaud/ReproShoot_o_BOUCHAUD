using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    private Vector2 stickDirection;
    private Rigidbody2D myRB2D;

    [SerializeField] private GameObject bullet;

    private void OnEnable()
    {
        var playerControls = new PlayerControls();
        playerControls.Enable();
        playerControls.Main.Move.performed += MoveOnperformed;
        playerControls.Main.Move.canceled += MoveOncanceled;
        playerControls.Main.Shoot.performed += ShootOnperformed;
        playerControls.Main.Rotate.performed += RotateOnperformed;
    }


    private void ShootOnperformed(InputAction.CallbackContext obj)
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    private void MoveOnperformed(InputAction.CallbackContext obj)
    {
        stickDirection = obj.ReadValue<Vector2>();
    }

    private void MoveOncanceled(InputAction.CallbackContext obj)
    {
        stickDirection = Vector2.zero;
    }

    private void RotateOnperformed(InputAction.CallbackContext obj)
    {
    //Pour récupérer un vecteur équivalent à la direction entre 2 points, la formule est : Point d'arrivée - point de départ. 
    //À ce titre la direction d'un objet A à la position (5,5) vers un objet B à la position (7,9) sera la suivante : (7-5,9-5) = (2,4)
    //Il faut noter aussi la possibilité de réduire la taille de ce vecteur à 1 en le normalisant à la suite des calculs.

    
    //Vector2.normalized
    Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
    //Vector2 mouseDirection = new Vector2(obj.ReadValue<Vector2>().x, obj.ReadValue<Vector2>().y);
    Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(obj.ReadValue<Vector2>());
    float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
    transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
    
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
     {
         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
     }


    }


    // Start is called before the first frame update
    void Start()
    {
        myRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var direction = new Vector2{ x = stickDirection.x, y = stickDirection.y};
        
            myRB2D.AddForce(direction * speed);


    }

    /*void OnCollisionEnter2D (Collision2D other)
    {
        Destroy(gameObject);
    }*/
}
