using System;
using BepInEx;
using UnityEngine;

public class Gem_C_Platinum : Gem
{
    public float gracePeriod = 1.5f;
    public double gainChance = 0.5d;
    public ScalingValue killGold;
    private KillTracker _tracker;

    public override void OnEquipSkill(SkillTrigger newSkill)
    {
        base.OnEquipSkill(newSkill);
        if (!this.isServer)
            return;
        this._tracker = newSkill.TrackKills(this.gracePeriod, new Action<EventInfoKill>(this.Callback));
    }

    private void Callback(EventInfoKill obj)
    {
        if (!(obj.victim is Monster victim))
            return;
        if ((double)UnityEngine.Random.value > (double)this.gainChance)
            return;
        ++this.tempOwner.platinumCoin;
    }

    public override void OnUnequipSkill(SkillTrigger oldSkill)
    {
        base.OnUnequipSkill(oldSkill);
        if (!this.isServer)
            return;
        this._tracker.Stop();
    }

    private void MirrorProcessed()
    {
    }
}
