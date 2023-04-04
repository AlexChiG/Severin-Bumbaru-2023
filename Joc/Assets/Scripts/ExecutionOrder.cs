using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionOrder : MonoBehaviour
{
    // Start is called before the first frame update
    private Player_Controller controller;
    private ActionArray actionArray;
    private List<string> list = new List<string>();
    private void Awake()
    {
        actionArray = GameObject.Find("Action Array").GetComponent<ActionArray>();
        controller = GameObject.FindWithTag("Player").GetComponent<Player_Controller>();
    }
    void Start()
    {
        
    }
    IEnumerator executeAction()
    {
        Debug.Log("Starting routine...");
        foreach (string item in list) {
            switch (item) {
                case "Move":
                    controller.moveUp();
                    break;
                case "RotateRight":
                    controller.Rotate90R();
                    break;
                case "RotateLeft":
                    controller.Rotate90L();
                    break;

            }
            yield return new WaitForSeconds(2);
            Debug.Log("Run executed.");
        }
        yield return null;
    }
    void readOrder()
    {
        list.Clear();
        for (int i = 0; i < actionArray.panels.Length; i++)
        {
            if (actionArray.panels[i].transform.childCount > 0)
            {

                list.Add(actionArray.panels[i].transform.GetChild(0).gameObject.tag);
                Debug.Log(actionArray.panels[i].transform.GetChild(0).gameObject.tag);

            }
            else break;
        }

    }
    public void Play()
    {
        readOrder();
        StartCoroutine("executeAction");
    }
    public void Res()
    {
        actionArray.ClearAll();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyUp("a")) {
            Debug.Log("Key pressed");
            readOrder();
            StartCoroutine("executeAction");} */
        

    }
}
