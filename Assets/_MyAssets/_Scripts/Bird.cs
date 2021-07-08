using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    [SerializeField] float mfForce = 15f;

    //Keyboard mKeyboard = null;

    // Start is called before the first frame update
    void Start()
    {
        //mKeyboard = InputSystem.GetDevice<Keyboard>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Jump"))
        //    Debug.Log("Jump");

        //Debug.Log("Space: " + mKeyboard.spaceKey.ReadValue());


    }

    private void OnJump()
    {
        //Debug.Log("Jump");
        Rigidbody2D lRigidbody = GetComponent<Rigidbody2D>();
        Vector2 lvForce = new Vector2(0, mfForce);
        lRigidbody.AddForce(lvForce, ForceMode2D.Impulse);

    }


}
