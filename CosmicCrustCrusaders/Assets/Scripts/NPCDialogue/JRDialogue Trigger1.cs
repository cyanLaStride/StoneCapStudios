using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JRDialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;
    private PlayerController playerController; // Reference to PlayerController\

    private bool jank = false;

    [SerializeField]
    private string npcName = string.Empty;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();

        // Check if DialogueManager exists before subscribing
        if (DialogueManager.GetInstance() != null)
        {
            DialogueManager.GetInstance().OnDialogueEnd += UnlockPlayerMovement;
        }
        else
        {
            Debug.LogError("DialogueManager is missing from the scene! Make sure it's added.");
        }
        
    }

    private void Update()
    {
        /*
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed())
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                playerController.LockMovement(true); // Lock player movement when dialogue starts
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
        */
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (!jank)
            {
                jank = true;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            } else if (npcName == "Tim")
            {
                //SceneManager.UnloadSceneAsync("Earth");
                //GameObject.Find("GameManager").GetComponent<GameManager>().LevelStart();
                SceneManager.LoadSceneAsync("Earth");
            } else if (npcName == "Ezekial")
            {
                //SceneManager.UnloadSceneAsync("Upgrade Shop");
                SceneManager.LoadSceneAsync("Upgrade Shop");
            } else if (npcName == "Lilia")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().CoinCount += 15;
                SceneManager.LoadSceneAsync("Pizza Shop");
            } else if (npcName == "Fice")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().CoinCount += 100;
                if(GameObject.Find("GameManager").GetComponent<GameManager>().endTime < 200)
                {
                    SceneManager.LoadSceneAsync(17);
                } else
                {
                    SceneManager.LoadSceneAsync(18);
                }
                
            } else if (npcName == "BadEnd")
            {
                SceneManager.LoadSceneAsync(11);
            } else if (npcName == "GoodEnd")
            {
                SceneManager.LoadSceneAsync(16);
            }

            //playerController.LockMovement(true); // Lock player movement when dialogue starts
        }
    }
    public void LockMovement(bool isLocked)
    {
        if (playerController != null)
        {
            playerController.isInteracting = isLocked; // Correctly reference isInteracting
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
    private void UnlockPlayerMovement()
    {
        if (playerController != null)
        {
            playerController.LockMovement(false);
        }
    }
    private void OnDestroy()
    {
        if (DialogueManager.GetInstance() != null)
        {
            DialogueManager.GetInstance().OnDialogueEnd -= UnlockPlayerMovement;
        }
    }

}