﻿using Modding;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using ModCommon;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using GlobalEnums;
using Modding.Menu;
using System.Collections;
using ModCommon.Util;
using System;

namespace HollowPoint
{
    class HPUI : MonoBehaviour
    {
        GameObject canvas;
        Text caliber;
        Text ammo;
        Text magazine;

        public void Awake()
        {         
            CanvasUtil.CreateFonts();
            canvas = CanvasUtil.CreateCanvas(RenderMode.ScreenSpaceOverlay, new Vector2(1920, 1080));
            UnityEngine.Object.DontDestroyOnLoad(canvas);
            caliber = CanvasUtil.CreateTextPanel(canvas, "", 25, TextAnchor.MiddleLeft, new CanvasUtil.RectData(new Vector2(600, 50), new Vector2(-560, 805), new Vector2(0.5f, 0), new Vector2(0.5f, 0), new Vector2(0.5f, 0.5f)), true).GetComponent<Text>();
            caliber.color = new Color(1f, 1f, 1, 1f);
            caliber.text = "";

            ammo = CanvasUtil.CreateTextPanel(canvas, "", 25, TextAnchor.MiddleLeft, new CanvasUtil.RectData(new Vector2(600, 50), new Vector2(-560, 775), new Vector2(0.5f, 0), new Vector2(0.5f, 0), new Vector2(0.5f, 0.5f)), true).GetComponent<Text>();
            ammo.color = new Color(1f, 1f, 1, 1f);
            ammo.text = "";

            magazine = CanvasUtil.CreateTextPanel(canvas, "", 25, TextAnchor.MiddleLeft, new CanvasUtil.RectData(new Vector2(600, 50), new Vector2(-560, 745), new Vector2(0.5f, 0), new Vector2(0.5f, 0), new Vector2(0.5f, 0.5f)), true).GetComponent<Text>();
            magazine.color = new Color(1f, 1f, 1, 1f);
            magazine.text = "";

            Modding.Logger.Log("UI LOADED");
        }


        public void OnGUI()
        {
            //Current CALIBER
            caliber.text = "CAL: " + AmmunitionControl.currAmmoType.AmmoName;

            //Current AMMO
            if (AmmunitionControl.reloading)
            {
                ammo.text = "AMM: RELOADING " + AmmunitionControl.currAmmoType.CurrAmmo + "%"; 
            }
            else if(AmmunitionControl.currAmmoType.AmmoName.Contains("Nail"))
            {
                ammo.text = "AMM: N/A";
            }
            else
            {
                ammo.text = "AMM: " + AmmunitionControl.currAmmoType.CurrAmmo;
            }

            //Current MAGAZINES
            if (AmmunitionControl.currAmmoType.AmmoName.Contains("Nail"))
            {
                magazine.text = "MAG: N/A"; 
            }
            else
            {
                magazine.text = "MAG: " + new String('|', AmmunitionControl.currAmmoType.CurrMag);
            }
        }

    }
}
