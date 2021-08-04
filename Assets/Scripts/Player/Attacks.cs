using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacks : MonoBehaviour
{
    // Access to camera
    [SerializeField] Camera mainCamera;

    // Cooldown times for attacks (seconds)
    private float quickScratchCooldown = 0f;

    // Cooldown bools
    [HideInInspector] public bool quickOnCooldown = false;

    // Attack visuals
    [SerializeField] Text quickCooldownVis;

    // Player movement sctipt var
    private PlayerMovement playerMovement;

    void Start()
    {
        // Get movement script
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Check for quick scratch
        QuickScratch();

        // Check for quick scratch cooldown
        Cooldown();
    }

    private void QuickScratch()
    {
        // If the player left clicks and right click is not being held and not on cooldown
        // Player also cannot be super sprinting to attack
        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1) == false && quickOnCooldown == false && playerMovement.moveSpeed <= playerMovement.sprintSpeed)
        {
            // Do a quick scratch
            print("Quick Scratch");

            // Begin cooldown
            quickOnCooldown = true;
            quickScratchCooldown = 3f;

            // vv Add visuals for quick scratch here vv
        }
    }

    private void Cooldown()
    {
        if (quickScratchCooldown > 0 && quickOnCooldown == true)
        {
            // Update UI text
            int roundTime = (int)quickScratchCooldown;
            quickCooldownVis.text = roundTime.ToString();

            // Subtract time per instance
            quickScratchCooldown -= Time.deltaTime;
        }
        // Once the timer hits 0
        else if (quickScratchCooldown <= 0)
        {
            // Ability no longer on cooldown
            quickOnCooldown = false;
        }
    }
}