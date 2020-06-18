using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] private float speed;

    private Vector2 stickDirection;
    private Rigidbody2D myRB2D;

    private void OnEnable()
    {
        var playerControls = new PlayerControls();
        playerControls.Enable();
        playerControls.Main.Move.performed += MoveOnperformed;
        playerControls.Main.Move.canceled += MoveOncanceled;
        playerControls.Main.Shoot.performed += ShootOnperformed;
    }


    private void ShootOnperformed(InputAction.CallbackContext obj)
    {
        //Instantiate a bullet
    }

    private void MoveOnperformed(InputAction.CallbackContext obj)
    {
        stickDirection = obj.ReadValue<Vector2>();
    }

    private void MoveOncanceled(InputAction.CallbackContext obj)
    {
        stickDirection = Vector2.zero;
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
}
