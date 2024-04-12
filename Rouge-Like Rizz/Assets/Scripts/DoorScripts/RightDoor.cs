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

    public void Start()
    {
        sceneBuildIndex = Random.Range(lowRightScene, topRightScene);
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
