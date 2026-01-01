$files = @(
    "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCollectionsGeneric\SunamoCollectionsGeneric\_sunamo\SunamoData\Data\FromToTSHCollectionsGeneric.cs",
    "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCollectionsGeneric\SunamoCollectionsGeneric\_sunamo\SunamoData\Data\FromToCollectionsGeneric.cs",
    "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCollectionsGeneric\SunamoCollectionsGeneric\_sunamo\SunamoValues\Constants\Messages.cs",
    "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCollectionsGeneric\SunamoCollectionsGeneric\_sunamo\SunamoInterfaces\Interfaces\ISunamoDictionary.cs",
    "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCollectionsGeneric\SunamoCollectionsGeneric\_sunamo\SunamoInterfaces\Interfaces\IStatusBroadcaster.cs",
    "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCollectionsGeneric\SunamoCollectionsGeneric\_sunamo\SunamoTextOutputGenerator\TextOutputGeneratorArgs.cs",
    "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCollectionsGeneric\SunamoCollectionsGeneric\_sunamo\SunamoTextOutputGenerator\TextOutputGenerator.cs",
    "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCollectionsGeneric\SunamoCollectionsGeneric\_sunamo\SunamoInterfaces\Interfaces\IIdentificator.cs",
    "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCollectionsGeneric\SunamoCollectionsGeneric\_sunamo\SunamoExceptions\ThrowEx.cs",
    "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCollectionsGeneric\SunamoCollectionsGeneric\_sunamo\SunamoExceptions\Exceptions.cs",
    "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCollectionsGeneric\SunamoCollectionsGeneric\_public\SunamoData\Data\FromToTSHCollectionsGenericShared.cs",
    "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCollectionsGeneric\SunamoCollectionsGeneric\_public\SunamoData\Data\FromToCollectionsGenericShared.cs",
    "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCollectionsGeneric\SunamoCollectionsGeneric\_public\SunamoInterfaces\Interfaces\ProgressStateCAG.cs"
)

foreach ($file in $files) {
    if (Test-Path $file) {
        $content = Get-Content $file -Raw
        # Remove the header comments (lines 1-2)
        $content = $content -replace "^// EN: Variable names have been checked and replaced with self-descriptive names`r?`n// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy`r?`n", ""
        Set-Content -Path $file -Value $content -NoNewline
        Write-Host "Processed: $file"
    } else {
        Write-Host "File not found: $file"
    }
}
