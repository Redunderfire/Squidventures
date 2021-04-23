using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will need to be expanded as time goes on to account for ending the game and sending informtion to the HUD.
public class ObjectiveManager : MonoBehaviour
{
    [SerializeField]
    private int maxValue = 6;
    public int currentValue{get; set;}

    public ObjectiveCircle objectiveCircle;

    // Start is called before the first frame update
    void Start() {
        currentValue = 0;
        objectiveCircle.setMaxObj(maxValue);
        objectiveCircle.setObj(0);
    }

    // Increment our objective's value
    public void incrementObjValue(){
        currentValue++;
        objectiveCircle.setObj(currentValue);
        if(currentValue >= maxValue){ // if all objectives collected, call the endgame function
            endGame();
        }
    }

    // Return value of currentValue
    
    // Placeholder function for ending the game through objective collection.
    private void endGame(){
        Application.Quit();
    }
}
