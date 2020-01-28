using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureHunter : MonoBehaviour
{
    public TreasureHunterInventory inventory;
    public CollectibleTreasure[] PointerArray;
    public TextMesh win;
    public TextMesh score;
    public int count = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")){
            if(inventory.treasures.Contains(PointerArray[0])==false){
                inventory.treasures.Add(PointerArray[0]);
            }
            print("You hit 1");
        }

        if(Input.GetKeyDown("2")){
            if(inventory.treasures.Contains(PointerArray[1])==false){
                inventory.treasures.Add(PointerArray[1]);
            }
            print("You hit 2");
        }

        if(Input.GetKeyDown("3")){
            if(inventory.treasures.Contains(PointerArray[2])==false){
                inventory.treasures.Add(PointerArray[2]);
            }
            print("You hit 3");
        }

        if(Input.GetKeyDown("4")){
            score.text="Score: " + countScore()+ "\n"+"# of obj:" + inventory.treasures.Count;
            print("You hit 4");
        }

        if(inventory.treasures.Count==3){
            win.text="You Win! - Ammar Puri";
        }
    }

    public int countScore(){
        count=0;
        for(int i=0;i<inventory.treasures.Count;i++){
            count+=inventory.treasures[i].value;
        }
        return count;
    }
}
