using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreasureHunter : MonoBehaviour
{
    public GameObject head;
    public TreasureHunterInventory inventory;
    public TextMesh numitems;
    public TextMesh score;
    public int count = 0;
    void Start()
    {
        for(int i=0;i<inventory.treasures.Count;i++){
            inventory.amount.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("9")){ //code for how to raycast was based off of Nick Rewkowski's VrPawn teleport code
            RaycastHit outHit;
            if(Physics.Raycast(head.transform.position,head.transform.forward,out outHit, 100.0f)){
                if(outHit.collider.gameObject.GetComponent("CollectibleTreasure")){
                    print("hit");
                    string objectname = outHit.collider.gameObject.GetComponent<CollectibleTreasure>().name;
                    bool exist = false;
                    for(int i=0;i<inventory.treasures.Count;i++){
                        if(inventory.treasures.ElementAt(i).name==objectname){
                            inventory.amount[i]++;
                            exist = true;
                        }
                    }
                    if(exist==false){
                        inventory.treasures.Add(outHit.collider.gameObject.GetComponent<CollectibleTreasure>());
                        inventory.amount.Add(1);
                    }
                    /*if(objectname==1){
                        numberofEach[0]++;
                    } else if(objectvalue==5){
                        numberofEach[1]++;
                    } else if(objectvalue==10){
                        numberofEach[2]++;
                    }*/
                    Destroy(outHit.collider.gameObject);
                }
            }
            print("You hit the collector button");
        }

        if(Input.GetKeyDown("1")){
            print("You hit the score button");
            int sum = 0;
            int totalitems = 0;
            for(int j=0;j<inventory.treasures.Count;j++){
                sum += inventory.treasures[j].value*inventory.amount[j];  
                totalitems += inventory.amount[j];
            }
            score.text = "Score = "+sum + " Ammar Puri";
            numitems.text = "Total Items = "+totalitems;
        }
        /*if(Input.GetKeyDown("1")){
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
        }*/
    }

    /*public int countScore(){
        count=0;
        for(int i=0;i<inventory.treasures.Count;i++){
            count+=inventory.treasures[i].value;
        }
        return count;
    }*/
}
