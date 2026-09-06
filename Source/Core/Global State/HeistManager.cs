using Godot;
using System;
using System.Collections.Generic;

public class HeistManager
{
    static private HeistManager instance_ = new HeistManager();
    static public HeistManager instance => instance_;

    public Action<List<HeistResource>> HeistsChanged;
    public Action<List<HeistResource>> HeistsUnlocked;
    public Action<HeistResource> HeistSelected;


    private List<HeistResource> heists_ = new List<HeistResource>();
    private List<HeistResource> unlocked_heists_ = new List<HeistResource>();
    private HeistResource selected_heist_ = null;

    public void AddHeist(HeistResource res)
    {
        if (heists_.Contains(res)) return;

        heists_.Add(res);
        HeistsChanged?.Invoke(heists_);
    }

    public void UnlockHeist(HeistResource res)
    {
        if (!heists_.Contains(res)) return;
        if (unlocked_heists_.Contains(res)) return;

        unlocked_heists_.Add(res);
        HeistsUnlocked?.Invoke(unlocked_heists_);
    }

    public void SetCurrentHeist(HeistResource res)
    {
        if (res == null) return;
        if (res == selected_heist_) return;

        selected_heist_ = res;
        HeistSelected?.Invoke(res);
    }

    public List<HeistResource> GetUnlockedHeists() => unlocked_heists_;
    public List<HeistResource> GetHeists() => heists_;

}
