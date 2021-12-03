using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    
    public int openingDirection;
    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door
    public int entryPoint;

    private RoomTemplates  templates;
    private int rand;
    private bool spawned =false;
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn",0.5f);
    }

    
    void Spawn()
    {
        if(!spawned){
            if(openingDirection ==1){
                // Need to spawn a room with a BOTTOM door.
                rand = Random.Range(0,templates.bootomRooms.Length);
                Instantiate(templates.bootomRooms[rand],transform.position,templates.bootomRooms[rand].transform.rotation);
            }
            else if(openingDirection ==2){
                // Need to spawn a room with a TOP door.
                rand = Random.Range(0,templates.topRooms.Length);
                Instantiate(templates.topRooms[rand],transform.position,templates.topRooms[rand].transform.rotation);
            }
            else if(openingDirection ==4){
                // Need to spawn a room with a RIGHT door.
                rand = Random.Range(0,templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand],transform.position,templates.rightRooms[rand].transform.rotation);
            }
            else if(openingDirection ==3){ 
                // Need to spawn a room with a LEFT door.
                rand = Random.Range(0,templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand],transform.position,templates.leftRooms[rand].transform.rotation);
            }
            spawned=true;
        }


    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("SpawnPoint")){
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned ==false){
                if(openingDirection==2){
                    if(other.GetComponent<RoomSpawner>().openingDirection==3){
                        Instantiate(templates.closedRoom[0],transform.position,Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else if(other.GetComponent<RoomSpawner>().openingDirection==4){
                        Instantiate(templates.closedRoom[1],transform.position,Quaternion.identity);
                        Destroy(gameObject);
                    }
                    
                }
                else if(openingDirection ==1){
                    if(other.GetComponent<RoomSpawner>().openingDirection==3){
                        Instantiate(templates.closedRoom[2],transform.position,Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else if(other.GetComponent<RoomSpawner>().openingDirection==4){
                        Instantiate(templates.closedRoom[3],transform.position,Quaternion.identity);
                        Destroy(gameObject);
                    }
                }
                else if(openingDirection==3){
                    if(other.GetComponent<RoomSpawner>().openingDirection==2){
                        Instantiate(templates.closedRoom[1],transform.position,Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else if(other.GetComponent<RoomSpawner>().openingDirection==1){
                        Instantiate(templates.closedRoom[3],transform.position,Quaternion.identity);
                        Destroy(gameObject);
                    }
                    
                }
                else if(openingDirection ==4){
                    if(other.GetComponent<RoomSpawner>().openingDirection==2){
                        Instantiate(templates.closedRoom[0],transform.position,Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else if(other.GetComponent<RoomSpawner>().openingDirection==1){
                        Instantiate(templates.closedRoom[2],transform.position,Quaternion.identity);
                        Destroy(gameObject);
                    }
                }
            }
            spawned = true;
        }


        // if(other.CompareTag("Rooms")){
        //     if(other.GetComponent<RoomSpawner>().spawned == true && spawned ==true){
        //         if(entryPoint==1){
        //             Instantiate(templates.bootomRooms[0],gameObject.transform.parent.transform.parent.gameObject.transform.position,templates.bootomRooms[rand].transform.rotation);
        //             Destroy(gameObject.transform.parent.transform.parent.gameObject);
        //         }
        //         else if(entryPoint==2){
        //             Instantiate(templates.topRooms[0],gameObject.transform.parent.transform.parent.gameObject.transform.position,templates.topRooms[rand].transform.rotation);
        //             Destroy(gameObject.transform.parent.transform.parent.gameObject);
        //         }
        //         else if(entryPoint==3){
        //             Instantiate(templates.leftRooms[0],gameObject.transform.parent.transform.parent.gameObject.transform.position,templates.leftRooms[rand].transform.rotation);
        //             Destroy(gameObject.transform.parent.transform.parent.gameObject);
        //         }
        //         else if(entryPoint==4){
        //             Instantiate(templates.rightRooms[0],gameObject.transform.parent.transform.parent.gameObject.transform.position,templates.rightRooms[rand].transform.rotation);
        //             Destroy(gameObject.transform.parent.transform.parent.gameObject);
        //         }
        //     }
            
        // }
    }
}
