using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmellVision : MonoBehaviour
{

    //public Transform Player;
    public GameObject arrowPrefab;
    GameObject arrow;
    bool arrowExists;

    public GameObject[] objects;
    Transform searching;
    int currentIndex = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        arrowLogic();
    }

    void createArrow() {
		if (updateIndex ()) {
			arrow = Instantiate (arrowPrefab) as GameObject;
            arrow.transform.position = transform.GetChild (0).position + new Vector3 (0, -0.8f, 0) + (transform.GetChild (0).forward * 3);
			arrow.transform.position = new Vector3 (arrow.transform.position.x, transform.position.y - 1.2f, arrow.transform.position.z);
            checkTag();
            arrow.transform.LookAt( new Vector3(searching.position.x, transform.position.y, searching.position.z));
            arrow.transform.Rotate(90,0,0);
            changeArrowExistence ();
			destroyArrow();
		}
    }

    void destroyArrow() {
        Destroy(arrow, 1.4f);
        Invoke("changeArrowExistence", 2f);
    }

    void arrowLogic() {
        if (!arrowExists && Input.GetButtonDown("Special")){
            createArrow();
        }
    }

    void changeArrowExistence() {
        arrowExists = !arrowExists;
    }

    void checkTag() {
        if (objects[currentIndex].tag == "Door") {
            searching = objects[currentIndex].transform;
        }
        else {
            searching =  objects[currentIndex].transform.GetChild(1);
        }
    }

    bool updateIndex() {
		currentIndex = -1;
        for (int i = 0; i < objects.Length; i++) {
			Debug.Log ("In loop: " + i);
			Debug.Log ("objects[i]: " + objects [i]);
			if (!objects[i].Equals(null))
            {	
				currentIndex = i;
				Debug.Log ("Found one! At: " + i);
				return true;
            }
        }
		Debug.Log ("Nothing!");
		return false;
    }
}
