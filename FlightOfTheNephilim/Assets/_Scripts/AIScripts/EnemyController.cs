using UnityEngine;
using System.Collections;

[System.Serializable]
public struct EnemyData
{
    //Specific enemy data
    [Tooltip("The style this enemy will use")]
    public EnemyStyle Style; //The specific style of the enemy
    [Tooltip("The class this enemy will use")]
    public EnemyClassType Class; //The specific class of the enemy

    //shot timer data
    [Tooltip("The shortest time it should be between shots")]
    public float ShotTimerMin; //The shortest time it should take to shoot
    [Tooltip("The longest time it should be between shots")]
    public float ShotTimerMax; //The longest time it should take to shoot

    //static variables
    [Tooltip("The health of this enemy type")]
    public float Health; //The health of the enemy
    [Tooltip("The damage bullets from this enemy will do")]
    public float ShotDamage; //The damage if a bullet from this enemy hits the player
    [Tooltip("The damage this enemy does from ramming")]
    public float ShipDamage; //The damage if this enemy hits the player
    [Tooltip("The speed the enemy moves")]
    public float Speed; //The max speed that this enemy will move
    [Tooltip("The sprite that will represent this enemy")]
    public Sprite mySprite; //The sprite that will represent this enemy

    //radius of satisfaction data
    [Tooltip("The radius around the player this enemy should start shooting")]
    public float ShotRadius; //The radius around the player that the enemy will try to shoot the player
    [Tooltip("The minimum radius around the player this enemy should stop seeking")]
    public float SeekRadiusMin; //The minimum radius of satisfaction for seeking the enemy
    [Tooltip("The maximum radius around the player this enemy should stop seeking")]
    public float SeekRadiusMax; //The maximum radius of satisfaction for seeking the enemy

    //Style Specific Data
    //Immortal
    [Tooltip("The respawn timer for immortal style")]
    public float RespawnTimer; //The time to respawn on immortal style enemies.
    //Duplicator
    [Tooltip("The number of times this enemy will duplicate on death for duplicator style")]
    public int DuplicationCount; //The number of times the enemy will duplicate on death on duplicator style enemies


    public float GetRadius()
    {
        return Random.Range(SeekRadiusMin, SeekRadiusMax);
    }

    public float GetShotTimer()
    {
        return Random.Range(ShotTimerMin, ShotTimerMax); 
    }
}

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 12, 2016
/// Last Modified by: Michael Dobson
/// This is the script that will hold the data for the enemys.
/// Data stored will be used to generate a range of values to be
/// used by the enemy AI to generate different behavior between
/// enemies.
/// </summary>
public class EnemyController : MonoBehaviour {

    //Mimic Style
    public EnemyData MimicSoldier;
    public EnemyData MimicKamikaze;
    public EnemyData Mimictank;

    //Chatoic Style
    public EnemyData ChaoticSoldier;
    public EnemyData ChaoticKamikaze;
    public EnemyData ChaoticTank;

    //Trickster Style
    public EnemyData TrickSoldier;
    public EnemyData TrickKamikaze;
    public EnemyData TrickTank;

    //Duplicator Style
    public EnemyData DuplicatorSoldier;
    public EnemyData DuplicatorKamikaze;
    public EnemyData DuplicatorTank;

    //Immortal Style
    public EnemyData ImmortalSoldier;
    public EnemyData ImmortalKamikaze;
    public EnemyData ImmortalTank;


    public EnemyData? GetEnemyData(EnemyStyle Style, EnemyClassType ClassType)
    {
        switch (Style)
        {
            case EnemyStyle.Mimic:
                switch (ClassType)
                {
                    case EnemyClassType.Soldier:
                        return MimicSoldier;
                    case EnemyClassType.Tank:
                        return Mimictank;
                    case EnemyClassType.Kamikaze:
                        return MimicKamikaze;
                }
                break;
            case EnemyStyle.Chaotic:
                switch (ClassType)
                {
                    case EnemyClassType.Soldier:
                        return ChaoticSoldier;
                    case EnemyClassType.Tank:
                        return ChaoticTank;
                    case EnemyClassType.Kamikaze:
                        return ChaoticKamikaze;
                }
                break;
            case EnemyStyle.Duplicator:
                switch (ClassType)
                {
                    case EnemyClassType.Soldier:
                        return DuplicatorSoldier;
                    case EnemyClassType.Tank:
                        return DuplicatorTank;
                    case EnemyClassType.Kamikaze:
                        return DuplicatorKamikaze;
                }
                break;
            case EnemyStyle.Immortal:
                switch (ClassType)
                {
                    case EnemyClassType.Soldier:
                        return ImmortalSoldier;
                    case EnemyClassType.Tank:
                        return ImmortalTank;
                    case EnemyClassType.Kamikaze:
                        return ImmortalKamikaze;
                }
                break;
            case EnemyStyle.Trickster:
                switch (ClassType)
                {
                    case EnemyClassType.Soldier:
                        return TrickSoldier;
                    case EnemyClassType.Tank:
                        return TrickTank;
                    case EnemyClassType.Kamikaze:
                        return TrickKamikaze;
                }
                break;
        }
        return null;
    }
}
