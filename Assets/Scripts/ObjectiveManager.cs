using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will need to be expanded as time goes on to account for ending the game and sending informtion to the HUD.
public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] public int maxValue = 6;
    private int currentValue;

    // Start is called before the first frame update
    void Start() {
        currentValue = 0;
    }

    // Increment our objective's value
    public void incrementObjValue(){
        currentValue++;
        if(currentValue >= maxValue){ // if all objectives collected, call the endgame function
            endGame();
        }
    }

    // Return value of currentValue
    public int getObjValue(){
        return currentValue;
    }
    
    // Placeholder function for ending the game through objective collection.
    private void endGame(){

    }
}
