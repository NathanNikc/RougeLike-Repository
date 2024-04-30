using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RightDoor : MonoBehaviour
{
    private int sceneBuildIndex;
    public AIDestinationSetter destinationSetter;
    public int Enemies;
    public Canvas EInteractCanvas;
    public bool isInRange = false;
    private int lowRightScene = 8;
    private int topRightScene = 14;
    static int doorsEntered = 0;
    public float doorsEnteredPublic = 0;

    public void Start()
    {
        sceneBuildIndex = Random.Range(lowRightScene, topRightScene);
        destinationSetter = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AIDestinationSetter>();
        EInteractCanvas.enabled = false;
        doorsEnteredPublic = doorsEntered;
    }

    public void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        doorsEnteredPublic = doorsEntered;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Enemies == 0)
        {
            EInteractCanvas.enabled = true;
            isInRange = true;
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
                destinationSetter.player = GameObject.FindGameObjectWithTag("Player");
                EInteractCanvas.enabled = false;
                isInRange = false;
                DoorCounter(1);
            }
            else if (Input. GetKey(KeyCode.E) && doorsEntered == 20) //20 is just a random number, after playtesting, choose the number of rooms before the boss to make it resonable
            {
              //  SceneManager.LoadScene((MAKE THIS THE BOSSLADY SCENE), LoadSceneMode.Single);
                destinationSetter.player = GameObject.FindGameObjectWithTag("Player");
                EInteractCanvas.enabled = false;
                isInRange = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            EInteractCanvas.enabled = false;
            isInRange = false;
        }
    }

    public void DoorCounter(int addDoor)
    {
        doorsEntered += addDoor;
    }
}
