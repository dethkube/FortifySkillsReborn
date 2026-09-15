# FortifySkillsReborn
FortifySkillsReborn is a fork of [FortifySkillsRedux](https://github.com/searica/FortifySkillsRedux) by Searica (itself a remake of the original FortifySkills mod), updated for Valheim 1.0 and maintained by dethkube. It changes how skills are lost on death. Each skill gains a second, slowly-growing fortified level, and your skills can never fall below it. The longer you stay alive the higher that floor rises, so repeated deaths no longer undo your progress.

By default you still take the game's normal death penalty, but cannot drop below your fortified level. For the harsher behaviour of the older FortifySkillsRedux, where dying drops each skill to its fortified level, set **Skill Loss Mode** to `ResetToFortify` (see [Configuration](#configuration)).

**Server-Side Info**: This mod does work as a client-side only mod and only needs to be installed on the server if you wish to enforce configuration settings.

## Supported Game Version
Updated for **Valheim 1.0** (built and verified against 1.0.12, Deep North). Requires Jotunn 2.30.0 or newer.

Skills added by the game since the previous release (Polearms, Crossbows, Dodge and Ride) get their own configuration sections automatically.

## Renamed from FortifySkillsRedux
This mod was renamed from **FortifySkillsRedux** to **FortifySkillsReborn**, which changes the plugin GUID and therefore the config file name:

- Old: `BepInEx/config/Searica.Valheim.FortifySkillsRedux.cfg`
- New: `BepInEx/config/dethkube.Valheim.FortifySkillsReborn.cfg`

If you are coming from FortifySkillsRedux, **uninstall it first**. Running both at once means both patch the same methods, so your XP rates get applied twice. Your existing settings are not carried over automatically; copy them into the new file if you want to keep them.

Two things behave differently in this fork (see [Mechanics](#mechanics)):

- Death now applies the normal game penalty with the fortified level as a floor, instead of resetting each skill straight to its fortified level.
- The default XP values have changed (Active Skill XP Multiplier 1.5 to 1.0, Max Fortify Skill XP Rate 0.8 to 0.5).

To get the old behaviour back, see [Matching the old FortifySkillsRedux behaviour](#matching-the-old-fortifyskillsredux-behaviour). It takes three settings.

## Installation
**Via Mod Manager (Recommended)**
- The best way to install the mod is using r2modman and installing it from Thunderstore: [FortifySkillsReborn on Thunderstore](https://thunderstore.io/c/valheim/p/HappyFunTimeGoGo/FortifySkillsReborn/).
- The next best way is to use Thunderstore Mod Manager.

**Manual**
- Download and install [BepInEx Pack](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/)
- Download and install [Jotunn](https://valheim.thunderstore.io/package/ValheimModding/Jotunn/)
- Download this mod and move `FortifySkillsReborn.dll` into `<GameLocation>/BepInEx/plugins`

## Mechanics
Every skill has a second level tracked alongside it, called the fortified level. It rises as you earn skill XP, very slowly at first and faster while your active level sits well above it. The longer you stay alive, the more of your progress becomes permanent. Your fortified level is shown in parentheses next to your active level in the skill list.

**Skill Loss Mode** controls what happens to that progress when you die.

### FortifyFloor (default)
You take the game's normal death penalty (5% by default, scaled by your world modifiers), and the fortified level acts purely as a floor.

| Scenario | Active | Fortified | After dying |
|---|---|---|---|
| Normal death | 20 | 16 | **19** (lost 5%, still above the floor) |
| Repeated deaths | 17 | 16 | **16** (cannot fall below the floor) |
| Soft death (dying again shortly after a death) | 20 | 16 | **20** (no penalty, same as the base game) |

A death costs you the same as it does in the base game. The fortified level only limits how far you can fall.

### ResetToFortify
Dying sets each skill straight to its fortified level, discarding whatever the normal penalty would have been.

| Scenario | Active | Fortified | After dying |
|---|---|---|---|
| Any hard death | 20 | 16 | **16** (the whole gap is lost) |

This is how FortifySkillsRedux behaved. Your fortified level can fall a long way behind your active level during a long survival streak, so a single death can cost far more than the vanilla 5%, such as the 20% in the table above. Redux offset that with bonus active XP and a faster-rising fortified level, so if you pick this mode you should restore those values too. See [Matching the old FortifySkillsRedux behaviour](#matching-the-old-fortifyskillsredux-behaviour).

### In either mode
- A string of deaths won't destroy your skill level. No need to worry about the No Skill Drain buff ending just before you die.
- Less used skills won't wither away completely from the occasional death. If you use one weapon type a lot early game but then switch to something else, now a few deaths without training the original weapon skill won't completely reset it.
- Your skills can never drop below their fortified levels, however many times you die.

## Configuration
Changes made to the configuration settings will be reflected in-game immediately (no restart required) and they will also sync to clients if the mod is on the server. The mod also has a built in file watcher so you can edit settings via an in-game configuration manager (changes applied upon closing the in-game configuration manager) or by changing values in the file via a text editor or mod manager.

### Global Section
**Verbosity**
- Low will log basic information about the mod. Medium will log information that is useful for troubleshooting. High will log a lot of information, do not set it to this without good reason as it will slow down your game.
    - Acceptable values: Low, Medium, High
    - Default value: Low.

**Skill Loss Mode [Synced with Server]**
- How your skills are reduced when you die.
    - `FortifyFloor`: you take the normal game penalty (5% by default, scaled by your world modifiers) but never drop below your fortified skill level. A soft death (dying again soon after a death) costs nothing, same as the base game.
    - `ResetToFortify`: your skills are set straight to their fortified skill level. This can cost considerably more than the normal penalty, and is how FortifySkillsRedux behaved.
    - Acceptable values: FortifyFloor, ResetToFortify
    - Default value: FortifyFloor.

**Keep All Items on Death [Synced with Server]**
- Whether to keep all items on death.
    - Acceptable values: False, True
    - Default value: false.

**Keep Equipped Items on Death [Synced with Server]**
- Whether to keep your equipped items when you die.
    - Acceptable values: False, True
    - Default value: false.

**Use Individual Settings [Synced with Server]**
- If enabled, use the config settings for each individual Vanilla skill and the Modded skill config settings for all skills added by mods. If disabled use the config setting from the Mechanics section for all skills.
    - Acceptable values: False, True
    - Default value: false.

### Mechanics
**Active Skill XP Multiplier [Synced with Server]**
- Controls XP gained for the active skill level. 1 = base game XP, 1.5 = 50% bonus XP, 0.8 = 20% less XP.
    - Default value: 1.0
    - Raise this to 1.5 if you use `ResetToFortify`. See [Matching the old FortifySkillsRedux behaviour](#matching-the-old-fortifyskillsredux-behaviour).

**Max Fortify Skill XP Rate [Synced with Server]**
- Controls maximum rate of XP earned for the fortified skill as a percentage of vanilla XP rates. Values below 1 mean that fortified skills will always increase slower than vanilla skills. Values above 1 mean that fortified skills can increase faster than vanilla skills if your active skill level is high enough.
    - Higher values keep the fortified level closer behind your active level, which raises your floor faster and makes each death cost less.
    - Default value: 0.5
    - Raise this to 0.8 if you use `ResetToFortify`. See [Matching the old FortifySkillsRedux behaviour](#matching-the-old-fortifyskillsredux-behaviour).

**Fortify Skill XP Per Level [Synced with Server]**
- Controls XP gained for the fortified skill. For every level the active skill is above the fortified skill increase the percentage of XP gained for the fortified skill by this amount up to Max Fortify Skill XP Rate.
    - Default value: 0.1

### Matching the old FortifySkillsRedux behaviour
This fork's defaults are tuned for `FortifyFloor`. Switching **Skill Loss Mode** to `ResetToFortify` on its own will feel harsher than FortifySkillsRedux ever did, because Redux paired that reset with bonus active XP and a faster-rising fortified level. To reproduce Redux's tuning, change all three:

| Setting | FortifySkillsReborn default | For FortifySkillsRedux behaviour |
|---|---|---|
| Skill Loss Mode | `FortifyFloor` | `ResetToFortify` |
| Active Skill XP Multiplier | 1.0 | **1.5** |
| Max Fortify Skill XP Rate | 0.5 | **0.8** |
| Fortify Skill XP Per Level | 0.1 | 0.1 (unchanged) |

Why the other two matter:

- **Active Skill XP Multiplier 1.5** gives you 50% bonus active XP, which is what made the steeper death penalty bearable. You regain the lost levels faster than the base game allows.
- **Max Fortify Skill XP Rate 0.8** lets the fortified level climb faster, keeping it closer behind your active level so the gap lost on death stays smaller.

Leaving these at 1.0 and 0.5 while using `ResetToFortify` means you take Redux's full death penalty with none of its compensation.

If **Use Individual Settings** is enabled, these XP values live in each per-skill section and in Modded Skill Settings, not in Mechanics.

### IndividualSkills Section
There is a section with the same config settings for each skill in the Vanilla game and one additional section for all skills added by mods. 
These settings are only used if Use Individual Settings is Enabled and they allow you to customize the XP gains for each individual skill.


## Building from Source
The project targets `net48` and builds with the .NET SDK on **Linux, macOS and Windows**:

```sh
dotnet build -c Release
```

A Release build also assembles the Nexus and Thunderstore packages under `Publish/`. A Debug build instead copies the plugin straight into your BepInEx `plugins` folder.

Two things have to be found on disk: your **Valheim install** (for the game assemblies, which are publicized at build time) and a **BepInEx install** (for `BepInEx.dll` and `0Harmony.dll`). Both are auto-detected, including Steam's default Linux/macOS/Windows locations and r2modman / Thunderstore Mod Manager profiles. If detection picks the wrong place, override it without editing anything:

```sh
dotnet build -c Release \
  -p:VALHEIM_INSTALL="$HOME/.steam/steam/steamapps/common/Valheim" \
  -p:BEPINEX_PATH="$HOME/.config/r2modmanPlus-local/Valheim/profiles/Default/BepInEx"
```

Use `-p:R2ModManProfile=MyProfile` to point at a mod manager profile other than `Default`, and `-p:MOD_DEPLOYPATH=...` to change where Debug builds deploy. See `environment.props` for the full list.

> Note: Jotunn ships its own assembly publicizer, but it is a .NET Framework MSBuild task that `dotnet build` cannot load. This project uses the cross-platform `BepInEx.AssemblyPublicizer.MSBuild` instead, so there is no Windows-only prebuild step.

## Compatibility
**All skill mods by Smoothbrain**
  - The XP multiplier settings in this mod stacks multiplicatively with the XP multiplier in Smoothbrain's skill mods.
  - If you set EnableIndividualSettings to True and keep ModdedSkillXPMult set to 1.0 it will not impact the XP gain rates of Smoothbrain's skill mods while still letting you customize the skill gain rates for Vanilla skills via the IndividualSkills XP multiplier settings.

**Incompatibilities**
- May have issues with anything that changes the SkillsDialog text in-game.

## Notes
- If you want to be extra cautious you can back up your character files, as this mod changes how those files are written. They live in:
    - Windows: `%appdata%\..\LocalLow\IronGate\Valheim\characters`
    - Linux (native build): `~/.config/unity3d/IronGate/Valheim/characters`
    - Linux (Proton): `~/.steam/steam/steamapps/compatdata/892970/pfx/drive_c/users/steamuser/AppData/LocalLow/IronGate/Valheim/characters`
    - macOS: `~/Library/Application Support/unity.IronGate.Valheim/characters`
- Your Fortify skill level will be set to 95% of your current skill level when you first install it, so dying immediately has the same effect as the base game in either mode.
- If you remove this mod your character will be fine, the fortify skill level will disappear and the current skill level will stay the same (including any levels gained from raising **Active Skill XP Multiplier** above 1.0).

## Source Code
Source code is available on Github.

| Github Repository: | <img height="18" src="https://github.githubassets.com/favicons/favicon-dark.svg"></img><a href="https://github.com/dethkube/FortifySkillsReborn"> FortifySkillsReborn</a>|
|-----------|---------------|


### Contributions
If you would like to provide suggestions, make feature requests, or reports bugs and compatibility issues please open an issue on the Github repository.

### Credits
This mod is based on the original one made by Merlyn42 and the patched version was made by Remeil. This mod is a complete rewrite of the original though as the original stopped working several game updates back and has no license. My thanks to Merlyn42 for the original idea though! Also, many thanks to the developers of Jotunn for all their work making the library. Also many thanks to Searica for all their work, happy I could update this for the 1.0 release!

## Credits and License
- Original **FortifySkills** mod: Merlyn42, with a later patched version by Remeil.
- **FortifySkillsRedux**, which this mod is forked from: [Searica](https://github.com/searica/FortifySkillsRedux).
- This fork (**FortifySkillsReborn**): dethkube, https://github.com/dethkube/FortifySkillsReborn

Licensed under the **GNU General Public License v3.0**; see [LICENSE](LICENSE). This is a modified version of FortifySkillsRedux; changes made in 2026 include updating the mod for Valheim 1.0, cross-platform build support, the addition of the Skill Loss Mode setting, and new default XP values.
