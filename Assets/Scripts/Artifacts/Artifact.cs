using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BlankArtifact", menuName = "Artifact", order = 1)]
public class Artifact : ScriptableObject
{
    public enum Modifier
    {
        PoisonCloud,
        FireCloud,
        CurseCloud,
        ShockCloud,

        FireArea,
        ShockArea,
        
        HealthBuff,
        DamageBuff,
        Speeduff,
        Regen
    }

    //Display
    public string Name;
    public Sprite Icon;
    public Modifier[] modifierEffects;

    //Values
    public float health;
    public float damage;
    public float regen;
    public float armor;
    public float protection;
    public float speed;
    public float passiveDamage;

    //Percent Mods
    public float health_percentage;
    public float damage_percentage;
    public float regen_percentage;
    public float armor_percentage;
    public float protection_percentage;
    public float speed_percentage;
    public float passiveDamage_percentage;
}
