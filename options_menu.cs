using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; 
using System; 
using TMPro;

namespace BNG
{
    public class options_menu : MonoBehaviour
    {
        //sound defaults Controls
        public int sfx_level;
        public int amb_level; 
        public int min_sfx_lvl;
        public int min_amb_lvl;
       

        //turn controls 
        public string turn_type;
        public string snap_Angle;
        private int rotat_angleINT;
        private int turn_selection;

        //Text controls
        public Text sfx_lvl_TXT;
        public Text amb_lvl_TXT;
        public Text rotat_angle_TXT;
        public Text turn_typ_TXT;

        //Audio Mixers
        public AudioMixer aMixer;

        private void Start()
        {
            //Get saved prefs
            rotat_angleINT = PlayerPrefs.GetInt("snapAngle");
            turn_selection = PlayerPrefs.GetInt("TurnSelection");
            amb_level = PlayerPrefs.GetInt("AmbLvl");
            sfx_level = PlayerPrefs.GetInt("SfxLvl");


            if (rotat_angleINT <= 0 || rotat_angleINT >= 359)
            {
                rotat_angleINT = 45;
            }

            rotat_angle_TXT.text = rotat_angleINT.ToString();

            if (turn_selection == 0)
            {
                turn_typ_TXT.text = "Snap";
                turn_type = "Snap";
            }
            else if (turn_selection == 1)
            {
                turn_typ_TXT.text = "Smooth";
                turn_type = "Smooth";
            }

            if (turn_selection != 0 || turn_selection != 1)
            {
                turn_selection = 0;
            }

            //Load up sound settings
            if (amb_level < min_amb_lvl)
            {
                amb_level = min_amb_lvl;
            }
            else if (amb_level > 0)
            {
                amb_level = 0;
            }


            if (sfx_level < min_sfx_lvl)
            {
                sfx_level = min_sfx_lvl;
            }
            else if (sfx_level > 0)
            {
                sfx_level = 0;
            }



            sfx_lvl_TXT.text = sfx_level.ToString();
            amb_lvl_TXT.text = amb_level.ToString();

            setAmbVolume((float)amb_level);
            setsfxVolume((float)sfx_level); 

            savetoPrefs(); 
        }


        //Turn type change 
        public void change_turn_type()
        {
            if (turn_type == "Snap")
            {
                turn_type = "Smooth";
                turn_selection = 1;
            }
            else
            {
                turn_type = "Snap";
                turn_selection = 0;
            }
            turn_typ_TXT.text = turn_type;
        }


        //change rotation angles
        public void rotat_angle_up()
        {
            rotat_angleINT += 1;
            if(rotat_angleINT > 359)
            {
                rotat_angleINT = 1; 
            }

            rotat_angle_TXT.text = rotat_angleINT.ToString();
        }

        public void rotat_angle_dwn()
        {
            rotat_angleINT -= 1; 

            if(rotat_angleINT < 1)
            {
                rotat_angleINT = 359; 
            }

            rotat_angle_TXT.text = rotat_angleINT.ToString();
        }

        public void setsfxVolume(float sfxvolume)
        {
            aMixer.SetFloat("sfxVolume", sfxvolume);
            sfx_lvl_TXT.text = sfx_level.ToString();
        }

        public void setAmbVolume(float ambvolume)
        {
            aMixer.SetFloat("ambVolume", ambvolume);
            amb_lvl_TXT.text = amb_level.ToString();
        }



        // This function saves everything to playerprefs
  
        public void savetoPrefs()
        {
            //change rotation type
            PlayerRotation rotary = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerRotation>();
            if(turn_type == "Snap")
            {
                rotary.RotationType = RotationMechanic.Snap;
                rotary.SnapRotationAmount = (float)rotat_angleINT; 
            }
            else
            {
                rotary.RotationType = RotationMechanic.Smooth;
                rotary.SnapRotationAmount = (float)rotat_angleINT;
            }

            //save the settings
            PlayerPrefs.SetInt("snapAngle", rotat_angleINT);
            PlayerPrefs.SetInt("TurnSelection", turn_selection);
            PlayerPrefs.SetInt("AmbLvl", amb_level);
            PlayerPrefs.SetInt("SfxLvl", sfx_level);
            PlayerPrefs.Save();
        }
    }
}
