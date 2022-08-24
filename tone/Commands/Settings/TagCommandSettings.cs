using Spectre.Console.Cli;
using tone.Commands.Settings.Interfaces;

namespace tone.Commands.Settings;

public class TagCommandSettings : TagSettingsBase, IPrependSeriesToDescriptionTaggerSettings
{

    [CommandOption("--assume-yes|-y")] public bool AssumeYes { get; init; } = false;
    [CommandOption("--dry-run")] public bool DryRun { get; init; } = false;

    /*
    public override ValidationResult Validate()
    {
        return Name.Length < 2
            ? ValidationResult.Error("Names must be at least two characters long")
            : ValidationResult.Success();
    }
    */
}
