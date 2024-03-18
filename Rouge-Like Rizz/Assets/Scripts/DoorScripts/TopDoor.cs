using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopDoor : MonoBehaviour
{
    public int sceneBuildIndex;
    public AIDestinationSetter destinationSetter;
    public int Enemies;
    public Canvas EInteractCanvas;
    private bool isInRange = false;

    public void Start()
    {
        sceneBuildIndex = Random.Range(2, 6);
        destinationSetter = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AIDestinationSetter>();
    }

    public void Update()
    {
       Enemies =  GameObject.FindGameObjectsWithTag("Enemy").Length;
       EInteractCanvas = GameObject.FindGameObjectWithTag("TopDoorPrompt").GetComponent<Canvas>();
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
}
