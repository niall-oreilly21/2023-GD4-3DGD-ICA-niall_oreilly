namespace GD
{
    /// <summary>
    /// Used to decide how to apply a buff from a list of available buffs on a collectible item
    /// </summary>
    /// <see cref="ConsumableObjectData"/>
    public enum BuffPolicyType : sbyte
    {
        ApplyAll,
        ApplyRandom
    }
}