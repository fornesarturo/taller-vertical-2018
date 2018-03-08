using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* TO DO
    * Pull or build array from player prefs
    * Remove object from array when picked up
    * Change to look up by tag
        * Add new cariable
        * var target = GameObject.FindWithTag("enemy that spawns tag");
    * Use currentIndexFunction
*/


public class SmellVision : MonoBehaviour
{

    public Transform Player;
    public GameObject arrowPrefab;
    GameObject arrow;
    bool arrowExists;

    public Transform target;

    public Transform[] locations;
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
        arrow = Instantiate(arrowPrefab, Player.transform) as GameObject;
        arrow.transform.position = Player.GetChild(0).position + new Vector3(0, -0.8f, 0) + (Player.GetChild(0).forward * 3);
        //arrow.transform.LookAt(locations[currentIndex]);
        float angle = Vector3.Angle(target.position - arrow.transform.position, transform.forward);
        angle = calculateCorrectAngle(target, arrow, angle);
        arrow.transform.Rotate(0, 0, angle);
        //arrow.transform.Rotate(90, 90, 90);
        //Debug.Log(target.position);
        //Debug.Log(arrow.transform.position);
        changeArrowExistence();
    }

    void destroyArrow() {
        Destroy(arrow, 1.4f);
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
        for (int i = currentIndex; i < locations.Length; i++) {
            if (locations[i] == null)
            {
                i++;
            }
            else {
                currentIndex = i;
            }
        }
    }

    float calculateCorrectAngle(Transform target, GameObject arrow, float angle) {
        if (target.position.x > arrow.transform.position.x) {
            return -angle;
        }
        return angle;
    }
}
