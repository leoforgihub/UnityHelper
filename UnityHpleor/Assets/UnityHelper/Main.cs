using UnityEngine;
using System.Collections;
using Assets;
using UnityHelper;

public class Main : MonoBehaviour
{

    public GameObject obj;

	// Use this for initialization
	void Start () {
	    
        MessageHandler.Instance.BuildMessage("Myfunction", MyFunction);
        ClassA clsa = new ClassA();

	    GameObjectCreator.CreateChild(obj);
        
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetMouseButtonDown(0))
	    {
            MessageHandler.Instance.Execute("Myfunction");
        }
	}

    void MyFunction()
    {
        Debug.Log("MyFunction");
    }
}
