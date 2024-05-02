using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopDoor : MonoBehaviour
{
    private int sceneBuildIndex;
    public AIDestinationSetter destinationSetter;
    public int Enemies;
    public Canvas EInteractCanvas;
    public bool isInRange = false;
    private int lowTopScene = 2;
    private int topTopScene = 8;
    static int doorsEntered;

    public void Start()
    {
        sceneBuildIndex = Random.Range(lowTopScene, topTopScene); //integers are exclusive on the top range, need to set the top scene to 1 value higher than the largest numbered scene to accomodate
        destinationSetter = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AIDestinationSetter>();
        EInteractCanvas.enabled = false;
    }

    public void Update()
    {
       Enemies =  GameObject.FindGameObjectsWithTag("Enemy").Length;
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
                DoorAddOne();
            }
            else if (Input.GetKey(KeyCode.E) && doorsEntered == 15) //20 is just a random number, after playtesting, choose the number of rooms before the boss to make it resonable
            {
                SceneManager.LoadScene(26, LoadSceneMode.Single);
                destinationSetter.player = GameObject.FindGameObjectWithTag("Player");
                EInteractCanvas.enabled = false;
                isInRange = false;
            }
        }
    }

    public void DoorAddOne()
    {
        doorsEntered += 1;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            EInteractCanvas.enabled = false;
            isInRange = false;
        }
    }
}
