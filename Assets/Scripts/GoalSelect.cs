
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSelect : MonoBehaviour
{
    // Array of game objects to choose from
    public GameObject[] objectsToChooseFrom;

    // New game object to replace the chosen one
    public GameObject replacementObject;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    private void Update()
    {
        if (replacementObject != null) {
            replacementObject.SetActive(false);
            // Choose a random index from the array
            int randomIndex = Random.Range(0, objectsToChooseFrom.Length);

            // Get the GameObject at the random index
            GameObject objectToReplace = objectsToChooseFrom[randomIndex];

            // Instantiate the replacement object at the same position and rotation as the object to replace
            GameObject newObject = Instantiate(replacementObject, objectToReplace.transform.position, objectToReplace.transform.rotation);

            // Destroy the old object
            Destroy(objectToReplace);
        }
    }
}