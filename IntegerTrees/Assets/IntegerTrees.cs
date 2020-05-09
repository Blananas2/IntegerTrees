using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class IntegerTrees : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable[] WeedEaters;
    public TextMesh[] Weeds;
    public KMSelectable chungus;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    int yes = 0;
    int fuck = 0;
    int silvena = 0;
    int gofuckyourself = 0;
    int integer = 0;
    private List<int> weed1 = new List<int>{};
    private List<int> weed2 = new List<int>{};

    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable WeedEater in WeedEaters) {
           WeedEater.OnInteract += delegate () { WeedEaterPress(WeedEater); return false; };
          }
          chungus.OnInteract += delegate () { PressChungus(); return false; };
    }

    void Start () {
      yes = UnityEngine.Random.Range(5,201);
      fuck = UnityEngine.Random.Range(5,201);
      weed1.Add(yes);
      weed2.Add(fuck);
      Weeds[0].text = yes.ToString();
      Weeds[1].text = fuck.ToString();
      Weeds[2].text = "0";
      Debug.LogFormat("[Integer Trees #{0}] The top number is {1} and the bottom one is {2}.", moduleId, yes, fuck);
      PenisMeasurer();
      PenisMeasurerTwo();
      for (int i = 0; i < weed1.Count(); i++) {
        for (int j = 0; j < weed2.Count(); j++) {
          if (weed1[i] == weed2[j] && weed1[i] > gofuckyourself) {
            gofuckyourself = weed1[i];
          }
        }
      }
      Debug.LogFormat("[Integer Trees #{0}] The highest shared value is {1}", moduleId, gofuckyourself);
      integer = weed1.Count() + weed2.Count();
      Debug.LogFormat("[Integer Trees #{0}] The amount of steps are {1}", moduleId, integer);
      gofuckyourself *= integer;
      gofuckyourself %= 100000;
      Debug.LogFormat("[Integer Trees #{0}] Multiplying the highest shared value and the amount of rows in the tree gives {1}.", moduleId, gofuckyourself);
	}
  void WeedEaterPress(KMSelectable WeedEater){
    WeedEater.AddInteractionPunch();
		GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, WeedEater.transform);
    for (int i = 0; i < 8; i++) {
      if (WeedEater == WeedEaters[i]) {
        if (i == 0) {
          silvena += 1000;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 1) {
          if (silvena < 1000) {
            return;
          }
          silvena -= 1000;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 2) {
          silvena += 100;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 3) {
          if (silvena < 100) {
            return;
          }
          silvena -= 100;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 4) {
          silvena += 10;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 5) {
          if (silvena < 10) {
            return;
          }
          silvena -= 10;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 6) {
          silvena += 1;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 7) {
          if (silvena < 1) {
            return;
          }
          silvena -= 1;
          Weeds[2].text = silvena.ToString();
        }
    }
  }
}
  void PenisMeasurer(){
    Something:
    if (yes % 2 == 0) {
      yes /= 2;
      weed1.Add(yes);
      Debug.LogFormat("[Integer Trees #{0}] The top number is even, dividing by 2 gives you {1}", moduleId, yes);
    }
    else {
      yes *= 3;
      yes += 1;
      weed1.Add(yes);
      Debug.LogFormat("[Integer Trees #{0}] The top number is odd, multiplying by 3 and adding 1 gives {1}", moduleId, yes);
    }
    if (yes == 1) {
      return;
    }
    else {
      goto Something;
    }
  }
  void PenisMeasurerTwo(){
    Somethingelse:
    if (fuck % 2 == 0) {
      fuck /= 2;
      weed2.Add(fuck);
      Debug.LogFormat("[Integer Trees #{0}] The bottom number is even, dividing by 2 gives you {1}", moduleId, fuck);
    }
    else {
      fuck *= 3;
      fuck += 1;
      weed2.Add(fuck);
      Debug.LogFormat("[Integer Trees #{0}] The bottom number is odd, multiplying by 3 and adding 1 gives {1}", moduleId, fuck);
    }
    if (fuck == 1) {
      return;
   }
  else {
    goto Somethingelse;
  }
 }
 void PressChungus(){
   chungus.AddInteractionPunch();
   GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, chungus.transform);
   if (silvena == gofuckyourself) {
     Debug.LogFormat("[Integer Trees #{0}] You submitted {1}. Module disarmed.", moduleId, silvena);
     GetComponent<KMBombModule>().HandlePass();
   }
   else {
     Debug.LogFormat("[Integer Trees #{0}] You submitted {1}. You should have submitted {1}.", moduleId, silvena, gofuckyourself);
     silvena = 0;
     Weeds[2].text = silvena.ToString();
     GetComponent<KMBombModule>().HandleStrike();
   }
 }
}
