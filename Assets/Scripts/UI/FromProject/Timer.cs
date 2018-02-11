using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/*
 * usage:
 * create timmer, set up cd;
 * 
 * if(timmer.isReadyRestart())
 *      do something every [cd] time (in seconds)
 */

[System.Serializable]
public class Timer
{

    public Timer( float _cd)
    {
        actualTime = 0;
        cd = _cd;
    }
    public Timer()
    {
        actualTime = 0;
    }
    // actual time of timmer; when the timmer was last restarted
    public float actualTime = 0;
    // how much time have to be elapsed from last reset to be ready
    public float cd = 1;

    // resets actual time
    public void restart()
    {
        actualTime = Time.time;
    }

    // returns true if time elapsed from last reset is greather than passed argument (cd)
    public bool isReady( float cd)
    {
        return Time.time - actualTime >= cd;
    }
    // returns true if time elapsed from last reset is greather than public member of this class (cd)
    public bool isReady()
    {
        return isReady(cd);
    }
    // the same as above but automatically resets if timer was ready
    public bool isReadyRestart(float cd)
    {
        if( Time.time - actualTime >= cd )
        {
            restart();
            return true;
        }
        return false;
    }
    // the same as above but automatically resets if timer was ready
    public bool isReadyRestart()
    {
        return isReadyRestart(cd);
    }
}
