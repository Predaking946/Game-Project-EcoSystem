using System.Runtime.CompilerServices;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Player_Controller : MonoBehaviour
{

    //Allows to be changed in Unity but not by other classes
    [SerializeField] private float movespeed = 7f;
    [SerializeField] private Game_Input gameInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //Gets inputVector from class Game_Input
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        //Transfers the values from the Vector2 into a Vector3 correctly
        Vector3 moveDir = new(inputVector.x, 0f, inputVector.y);
        //Makes actual changs to position while making sure framrate does not inpact speed
        transform.position += movespeed * Time.deltaTime * moveDir;

        float rotateSpeed = 10f;
        //Rotates character model towards direction of motion with Slerp smoothing the turn speed
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }
}
