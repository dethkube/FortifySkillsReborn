<table>
	<tbody>
		<tr>
			<th align="center">Version</th>
			<th align="center">Notes</th>
		</tr>
		<tr>
			<td align="center">1.7.1</td>
			<td align="left">
				<ul>
					<li>New mod icon, so the package is no longer easy to confuse with FortifySkillsRedux (sorry Searica).</li>
					<li>Internal cleanup: removed this mod's bundled config file watcher in favour of the equivalent one Jotunn now provides. No change in behaviour.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.7.0</td>
			<td align="left">
				<ul>
					<li>Added a <b>Skill Loss Mode</b> setting, which changes how skills are reduced on death.
						<ul>
							<li><code>FortifyFloor</code> (new default): you take the normal game death penalty (5% by default, scaled by world modifiers) and the fortified level acts purely as a floor. A skill at 20 with a fortified level of 16 now drops to 19 rather than 16.</li>
							<li><code>ResetToFortify</code>: the previous behaviour, where dying sets each skill straight to its fortified level. To match how FortifySkillsRedux was tuned, also set Active Skill XP Multiplier to 1.5 and Max Fortify Skill XP Rate to 0.8.</li>
						</ul>
					</li>
					<li>Fixed soft deaths being penalised. The base game only lowers skills on a hard death, but the fortified levels were previously applied on every death, so dying again shortly after a death still cost you skill levels. In <code>FortifyFloor</code> mode a soft death now costs nothing, matching the base game.</li>
					<li>Rewrote the README around the new setting, including a "Matching the old FortifySkillsRedux behaviour" section.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.6.0</td>
			<td align="left">
				<ul>
					<li>Updated for Valheim 1.0 (tested against 1.0.12, Deep North).</li>
					<li>Updated Jotunn to 2.30.0 and BepInEx to 5.4.2350.</li>
					<li>Config entries are now generated for the skills added since the last release (Polearms, Crossbows, Dodge, Ride).</li>
					<li>The project now builds on Linux and macOS as well as Windows.</li>
					<li>Renamed from FortifySkillsRedux to FortifySkillsReborn. The plugin GUID is now <code>dethkube.Valheim.FortifySkillsReborn</code>, so the config file name has changed and settings are not carried over. Uninstall FortifySkillsRedux before using this mod.</li>
					<li>Changed the default Active Skill XP Multiplier from 1.5 to 1.0 (vanilla XP rates).</li>
					<li>Changed the default Max Fortify Skill XP Rate from 0.8 to 0.5.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.5.3</td>
			<td align="left">
				<ul>
					<li>Fixed ordering of the Mechanics section in config file.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.5.2</td>
			<td align="left">
				<ul>
					<li>Fixed ordering of the sections in config file.</li>
					<li>Changed item drops on death settings to by synced with the server.</li>
					<li>Updated Jotunn.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.5.1</td>
			<td align="left">
				<ul>
					<li>Fixed item duplication on death bug.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.5.0</td>
			<td align="left">
				<ul>
					<li>Fixed spelling.</li>
					<li>Added config settings for keeping items on death.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.4.0</td>
			<td align="left">
				<ul>
					<li>Added more configuration options for individual skills.</li>
					<li>Improved config setting names and descriptions.</li>
					<li>Added support for shudnal's configuration manager.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.3.1</td>
			<td align="left">
				<ul>
					<li>Updated to Jotunn 2.22.0 and restored pre Bog Witch config syncing behaviour so configs are only synced if the mod is installed on the server.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.3.0</td>
			<td align="left">
				<ul>
					<li>Updated for Bog Witch release.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.2.0</td>
			<td align="left">
				<ul>
					<li>Updated for Ashlands release.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.1.0</td>
			<td align="left">
				<ul>
					<li>Changed Config file layout and added settings for FortifyLevelUpRate for each skill individually.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.0.9</td>
			<td align="left">
				<ul>
					<li>Made FortifySkillsReborn override the forced skill loss in Hardcore mode. Fortified skills will behave as intended regardless of in-game skill loss settings.</li>
					<li>Updated Jotunn version.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.0.8</td>
			<td align="left">
				<ul>
					<li>Improved compatibility with DeathTweaks. Skills will now override DeathTweaks and be reset to the correct FortifySkill level.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.0.7</td>
			<td align="left">
				<ul>
					<li>Minor fix to reduce unnecessary saving of the configuration file when no changes have occurred.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.0.6</td>
			<td align="left">
				<ul>
					<li>Updated icon and README.</li>
					<li>Recompiled against newest game version.</li>
					<li>Fix issue with changes made using the in-game configuration manager not saving properly if the game crashes.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.0.5</td>
			<td align="left">
				<ul>
					<li>Fixed issue with skills added by other mods using SkillManager not reseting to their fortified skill level on death.</li>
					<li>Rearranged and cleaned up configuration file. (<b>You need to regenerate your config file!)</b></li>
					<li>Improved logging for debug purposes.</li>
					<li>Updated icon.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.0.4</td>
			<td align="left">
				<ul>
					<li>Update for current game patch.</li>
					<li>Decoupled Fortify Skill level XP rate and Active Skill level XP multiplier.</li>
					<li>Console commands that reset skills now also reset fortified skills.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.0.3</td>
			<td align="left">
				<ul>
					<li>Maintenance update.</li>
					<li>Improved shutdown performance.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.0.1/1.0.2</td>
			<td align="left">
				<ul>
					<li>Update for patch 0.217.25</li>
					<li>
						Switched to using Jotunn for syncing server data.
						<ul>
							<li>Removed EnableMod setting.</li>
							<li>Removed LockingConfiguration setting.</li>
						</ul>
					</li>
					<li>Added a config file watcher to sync changes made on disk.</li>
					<li>Added config setting to control how much information output to the log. Should be useful for user's reporting issues.</li>
					<li>Update CHANGELOG format.</li>
				</ul>
			</td>
		</tr>
		<tr>
			<td align="center">1.0.0</td>
			<td align="left">
				<ul>
					<li>Initial release.</li>
				</ul>
			</td>
		</tr>
	</tbody>
</table>

