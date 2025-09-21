using System;
using System.Collections;
using UnityEngine;

public class Gem_R_Wealth_Mine : Gem_R_Wealth
{
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
        ++this.tempOwner.platinumCoin;
        Vector3 pos = victim.position;
        this.StartCoroutine(DropGoldRoutine());

        IEnumerator DropGoldRoutine()
        {
            int amount = DewMath.RandomRoundToInt(this.GetValue(this.killGold));
            int adjustedAmountPerDrop = this.amountPerDrop;
            if ((double)adjustedAmountPerDrop < (double)amount / 3.0)
                adjustedAmountPerDrop = Mathf.RoundToInt((float)amount / 3f);
            yield return (object)new UnityEngine.WaitForSeconds(this.initDelay);
            while (amount > 0 && !((UnityEngine.Object)this.owner == (UnityEngine.Object)null))
            {
                if (amount > adjustedAmountPerDrop)
                    NetworkedManagerBase<PickupManager>.instance.DropGold(false, false, adjustedAmountPerDrop, pos);
                else
                    NetworkedManagerBase<PickupManager>.instance.DropGold(false, false, amount, pos);
                amount -= adjustedAmountPerDrop;
                this.FxPlayNewNetworked(this.goldSpawnEffect, pos, new Quaternion?(Quaternion.identity));
                this.NotifyUse();
                yield return (object)new UnityEngine.WaitForSeconds(this.interval);
            }
        }
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
