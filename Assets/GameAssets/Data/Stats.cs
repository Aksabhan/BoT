/* Author : Annick Dumais
 * Last Revision : 14 mai 2026
 * Purpose : This is a data driven class that will be used
 * as a stats container
 */

using System;

[Serializable]
public class Stats
{
    public float moveSpeed;
    public float rateOfFire; //time between each shots
    public float distanceOfFire;
    //HP Scale TBD
    //public int currentHealth; --> This should go in the GM
    public int maxHealth;
    //public currentProjectile; --> GM
    //public startingProjectile; --> Inventory container?!
    public float momentum;


}
