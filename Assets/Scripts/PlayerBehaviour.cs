using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{

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

    }

    private void MoveOnperformed(InputAction.CallbackContext obj)
    {

    }

    private void MoveOncanceled(InputAction.CallbackContext obj)
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
