using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Diagnostics;
using HarmonyLib;
using UnityEngine.UI;


namespace HelloGladios
{
    public class HelloClass : IMod
    {
        public void Initialize()
        {
            
            Harmony.CreateAndPatchAll(typeof(Patch));

            UnityEngine.Debug.Log("Hello mod loaded");

            DisplayMessage();


            GeneralManager.singleton.gameObject.AddComponent<HelloComponent>();
        }

        public static void DisplayMessage()
        {
            GeneralManager.CreateConfirmDialog("This gets annoying fast", "Hello Gladios!", true);
        }
    }

    [HarmonyPatch(typeof(GeneralManager), nameof(GeneralManager.CreateConfirmDialog))]
    class Patch
    {
        static void Postfix(ref BasicConfirmDialog __result)
        {
            if (__result != null)
            {
                __result.UpdateText(__result.textField.text + "(patched hello)");
            }
            UnityEngine.Debug.Log("Harmony postfix!");
        }
    }
}
