using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomDoor : MonoBehaviour
{
    private int sceneBuildIndex;
    public AIDestinationSetter destinationSetter;
    public int Enemies;
    public Canvas EInteractCanvas;
    public bool isInRange = false;
    private int lowBottomScene = 20;
    private int topBottomScene = 27;

    public void Start()
    {
        sceneBuildIndex = Random.Range(lowBottomScene, topBottomScene);
        destinationSetter = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AIDestinationSetter>();
        EInteractCanvas.enabled = false;
    }

    public void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
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
        }
    }

    public void DoorAddOne()
    {

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
