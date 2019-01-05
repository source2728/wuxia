using PureMVC.Patterns;

public class StartUpCommand : MacroCommand
{
    protected override void InitializeMacroCommand()
    {
        AddSubCommand(typeof(LoadServiceCommand));
        AddSubCommand(typeof(LoadGameCommand));
        AddSubCommand(typeof(EnterGameSceneCommand));
    }
}
