using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmellVision : MonoBehaviour
{

    //public Transform Player;
    public GameObject arrowPrefab;
    GameObject arrow;
    bool arrowExists;

    public GameObject[] items;
    public GameObject[] doors;
    public GameObject[] objects;
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
        selectArray();
        updateIndex();
        arrow = Instantiate(arrowPrefab) as GameObject;
		arrow.transform.position = transform.GetChild(0).position + new Vector3(0, -0.8f, 0) + (transform.GetChild(0).forward * 3);
		arrow.transform.position= new Vector3(arrow.transform.position.x, transform.position.y - 1f, arrow.transform.position.z);
        float angle = Vector3.Angle(objects[currentIndex].transform.position - arrow.transform.position, transform.forward);
        angle = calculateCorrectAngle(objects[currentIndex], arrow, angle);
        arrow.transform.Rotate(0, 0, angle);
        changeArrowExistence();
    }

    void destroyArrow() {
        Destroy(arrow, 1.4f);
		//items = new GameObject[1];
		//doors = new GameObject[1];
		//objects = new GameObject[1];
        Invoke("changeArrowExistence", 2f);
        //arrowExists = false;
    }

    void arrowLogic() {
        if (!arrowExists && Input.GetButtonDown("Special")){
            createArrow();
            destroyArrow();
        }
    }

    void changeArrowExistence() {
        arrowExists = !arrowExists;
    }

    void updateIndex() {
        for (int i = 0; i < objects.Length; i++) {
            if (objects[i] == null)
            {
                i++;
            }
            else {
                currentIndex = i;
            }
        }
    }

    float calculateCorrectAngle(GameObject target, GameObject arrow, float angle) {
        if (target.transform.position.x > arrow.transform.position.x) {
            return -angle;
        }
        return angle;
    }

    void selectArray() {
        items = GameObject.FindGameObjectsWithTag("GameItem");
        doors = GameObject.FindGameObjectsWithTag("Door");
        if (items.Length > 0) {
            objects = items;
        }
        else {
            objects = doors;
        }
    }
}
