using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HockeyEditor;

namespace FSM_Bot
{
    public class Bot
    {
        public StackFSM mBrain;
        public Player puckOwner;
        public HQMTeam mTeam;

        public void Init()
        //Initializes the Bot and sets default behavior
        {
            mBrain = new StackFSM();
            mTeam = PlayerManager.LocalPlayer.Team;
            mBrain.pushState(idle);
        }

        public void idle()
        {
            //if has owner = true
            mBrain.popState();
            //    if team owned
            mBrain.pushState(attack);
            //    else
            mBrain.pushState(steal);
            //else if (distanceToPuck < 10)
            //(no owner and nearby)
            mBrain.popState();
            mBrain.pushState(chase);
        }

        public void attack()
        //if has puck itself, drives net
        //if teammate has puck, follows teammate
        {
           

            mBrain.pushState(idle);
        }

        public void steal()
        //attempts to take the puck from nearby players
        {
            if (puckOwner.Team != HQMTeam.NoTeam)
            {

                if (puckOwner.Team == mTeam)
                {
                    mBrain.popState();
                    mBrain.pushState(attack);
                }

                else
                {
                    if (Puck.Position == PlayerManager.LocalPlayer.Position)//TODO: WITHIN X METERS
                    {
                        //TODO: Move towards puck owner
                    }
                    else
                    //if enemy puck carrier isn't nearby, get back on defense
                    {
                        mBrain.popState();
                        mBrain.pushState(defend);
                    }
                    
                }

            }
            else
            {
                mBrain.popState();
                mBrain.pushState(chase);
            }
           
        }

        public void patrol()
        //moves around near the initial position to maintain momentum
        {

            //if too far from initial position
            mBrain.pushState(defend);
        }

        public void defend()
        //returns to initial position
        {
            //return to initial position

            //if team gets puck
            mBrain.popState();
            mBrain.pushState(attack);
            //else if opponent has puck and is close
            mBrain.popState();
            mBrain.pushState(steal);

            //else if no one is near puck
            mBrain.popState();
            mBrain.pushState(chase);
        }

        public void chase()
        //heads directly to the puck
        {
            //if puck is too far away...
            mBrain.popState();
            mBrain.pushState(idle);

            //else.. chase puck

        }

        public void update()
        {
            mBrain.update();
        }


    }
}
