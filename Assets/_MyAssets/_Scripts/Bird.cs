using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using TMPro;

public class Bird : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI mScoreLabel;
    [SerializeField] PlayerInput mPlayerInput;


    [Header("Values")]
    [SerializeField] float mfForce = 15f;




    bool mbIsDead;
    int miCurrentScore = 0;

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

        if (!mbIsDead)
        {
            //Debug.Log("Jump");
            Rigidbody2D lRigidbody = GetComponent<Rigidbody2D>();
            Vector2 lvForce = new Vector2(0, mfForce);
            lRigidbody.AddForce(lvForce, ForceMode2D.Impulse);
        }

    }


    public void AddScore(int liScore)
    {
        miCurrentScore += liScore;
        mScoreLabel.text = miCurrentScore.ToString();
    }

    public void Kill()
    {
        mbIsDead = true;

        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * mfForce * 5, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddTorque(75.0f);


        GameObject.FindObjectOfType<GeneratorPipe>().CancelInvoke("SpawnPipe");
        Pipe[] laPipes = GameObject.FindObjectsOfType<Pipe>();

        for (int i = 0; i < laPipes.Length; i++)
            laPipes[i].mfVelocity = 0;


        Background[] laBackground = GameObject.FindObjectsOfType<Background>();
        for (int i = 0; i < laBackground.Length; i++)
            laBackground[i].mfMoveSpeed = 0;

    }

}
