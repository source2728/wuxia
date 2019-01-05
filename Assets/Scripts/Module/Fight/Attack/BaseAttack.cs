public class BaseAttack
{
    public delegate void AttackFinishDelegate();
    public AttackFinishDelegate OnAttackFinish = new AttackFinishDelegate(DelegateFunction);
    public static void DelegateFunction() { }

    public CharacterController Owner { get; set; }
    public CharacterController AttackTarget { get; set; }

    public virtual void StartAttack(FightController fightController)
    {

    }
}
