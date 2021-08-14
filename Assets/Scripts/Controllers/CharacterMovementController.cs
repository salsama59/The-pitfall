using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    
    private float horizontalSpeed = 4f;
    private float initialVerticalSpeed = 10f;
    private Rigidbody2D characterRigidBody;
    private Vector2 movement;
    [SerializeField]
    private bool isParachuteDeployed = false;
    private Animator playerAnimator;
    [SerializeField]
    private GameManager gameManagerScript;
    private float currentVerticalSpeed;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        currentVerticalSpeed = initialVerticalSpeed;
        characterRigidBody = this.GetComponent<Rigidbody2D>();
        playerAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameManagerScript.IsGamePaused)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = characterRigidBody.position.y;
            //float verticalAxis = Input.GetAxisRaw("Vertical");
            if (Input.GetKeyUp(KeyCode.Space))
            {
                IsParachuteDeployed = !IsParachuteDeployed;
            }

            playerAnimator.SetBool("isParacuteDeployed", IsParachuteDeployed);
        }
       
    }


    private void FixedUpdate()
    {
        if (!gameManagerScript.IsGamePaused)
        {
            elapsedTime += Time.deltaTime;

           

            if (IsParachuteDeployed)
            {

                if (elapsedTime >= 1f)
                {
                    currentVerticalSpeed -= 1f;
                    if(currentVerticalSpeed == 0f)
                    {
                        currentVerticalSpeed = 1f;
                    }
                    elapsedTime = 0f;
                }
               
            }
            else
            {
                if (elapsedTime >= 2f)
                {
                    currentVerticalSpeed += 1f;
                    elapsedTime = 0f;
                }
            }

            Vector2 newposition = characterRigidBody.position + movement * horizontalSpeed * Time.fixedDeltaTime;
            newposition.y = characterRigidBody.position.y + currentVerticalSpeed * Time.fixedDeltaTime * -1;
            characterRigidBody.MovePosition(newposition);
        }
    }

    public bool IsParachuteDeployed { get => isParachuteDeployed; set => isParachuteDeployed = value; }
}
