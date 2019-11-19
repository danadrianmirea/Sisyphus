﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LB_PU : PU_HUD_HANDLER
{
    /* The class LB_PU is a subclass of the PU_HUD_HANDLER class.  Inheriting all of the set variables and defined functions of the superclass.
     */
    private TimeOut lightningBolt;
    /* The TimeOut lightningBolt is another copy of the reference to the TimeOut script used for the powerups.  It allows the subclass LB_PU
    * to read the type variable and timeractive variable from the TimeOut script.  These variables indicate to the LB_PU class whether or not
    * it should act and if so for how long it should change the transparency of the powerup sprite.
    */
    // Start is called before the first frame update
    void Start()
    {
        lightningBolt = FindObjectOfType<TimeOut>();  
        powerUp.color = new Color(1f, 1f, 1f, 0.0f);

    }

    /* At start the lightningBolt object is set to the TimeOut object that is current generated by using the Unityengine function FindObjectOfType<>.  This sets the
     * variable lightningBolt to the instance of the TimeOut class that is controlling the powerup on the screen.
     * The color of the lightning bolt power up sprite is also set to default color and full transparency.
     */

    // Update is called once per frame
    public override void Update()
    {
        if (lightningBolt.type == 2)
        {
            /* If the type of powerup on the screen is the lightning bolt then the rest of the function is enacted.  This type value is checked once per frame of the 
           * game.  The type must be compared to integers and there are currently 4 types of powerups that can be applied to type.  From 0 to 3.
           */
            if (lightningBolt.timerActive > 0.0f)
            {
                /* If the type of the power up is lightningBolt and the timer active is greater than 0 then the lightningBolt sprite becomes opaque.
                 * otherwise if the timeractive is at or below 0 then the sprite will fade to full transparency.
                 * The numbers compared to the timerActive variable must be floats as timerActive is a float value.
                 */
                float step = duration * Time.deltaTime;
                powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, maxAlpha, step));
                //  timer.color = new Color(1f, 1f, 1f, Mathf.Lerp(timer.color.a, maxAlpha, step));
                /* The timer.color changing functions are something that  may be implemented in a future release of the product but are not currently impacting
                   * the build in this version of the project.
                   */
            }
            else if (lightningBolt.timerActive <= 0.0f)
            {
                float step = duration * Time.deltaTime;
                powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, minAlpha, step));
               // timer.color = new Color(1f, 1f, 1f, Mathf.Lerp(timer.color.a, minAlpha, step));
            }
        }
    }

}
