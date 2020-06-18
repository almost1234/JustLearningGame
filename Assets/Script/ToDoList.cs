using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoList : MonoBehaviour
{
    /*  This is just a note 
     *  
     *  The gameplay is basically a horror puzzle game that allows the player to escape 
     *  whichever how they want.
     *  
     *  However, their actions could determine the final outcome of the story ( Depending if he kills / trap the ghost)
     *  
     *  PLAYER
     *  ------------------
     *  Player should be able to interact with the enviromnment, either picking up items, creating blockades or interact with future mechanism
     *  
     *  Bug found:
     *  - Player tries to instantiate inventory when there's nothing
     *  - Poor implementation of hiding
     *  - Poor implementation of trap-based interactions
     *  
     *  Future Tasks:
     *  - Ensure that Items generated could not be placed in the Wall area (LayoutArea)
     *  - Press Shift to run faster
     *  - Find a way to set "Awareness system", in which player's action will affect the detection of enemy and item interactions
     *  - Properly set the collision layering system : Differentiating between the direction system and player-item system
     *  
     *  ITEMS
     *  ------------------
     *  Items are objects that player could interact around the gameplay area. There will be future items that may/ may not
     *  linked with the story
     *  
     *  Bug found:
     *  - I guess there none?
     *  
     *  Future Tasks:
     *  - Properly create the ItemProperties class for base class in future Items prefab
     *  
     *  COVER
     *  -------------------
     *  Covers are area that player could interact to hide from the enemy. Enemy shouldn't see the player when hidden, and goes to its normal pathing
     *  
     *  Bug found:
     *  - For now none.
     *  
     *  Future Tasks:
     *  - I dont really find much creativity in this aspect. Could some items interact with these area to create traps?
     *  
     *  ENEMY
     *  -------------------
     *  Enemy will be assumed blind and move around the map. Only when the enemy encounter the player (Initally by sight, but I wanted to use sound detection kind
     *  (When the enemy goes a certain range, it could "hear" the player and start chasing the player)
     *  
     *  Bug found:
     *  - I'm way too dumb to even understand how A* pathfinder since I used a pre-built script
     *  
     *  Future Tasks:
     *  - Try to detach the script target. Maybe use the Unity Prebuilt AI pathing for normal search, and switch to A* pathfinding when the enemy found the player
     *  - Detection range (Maybe Collider but it could be too messy)
     *  - Possible trap damage (Either slow or stun, Example: Throwing the vase to the enemy may stun/ confuse them for a while
     *  
     *  FUTURE
     *  - Blockages
     * 
     *  
     *  
     *  
     *  
     *  
     *  
     *  
     */
}
