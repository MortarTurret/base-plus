//----------------------------------------------------------------------------
// light Female Armor
//----------------------------------------------------------------------------
$DamageScale[lfemale, $LandingDamageType] = $DamageScale[larmor, $LandingDamageType];
$DamageScale[lfemale, $ImpactDamageType] = $DamageScale[larmor, $ImpactDamageType];
$DamageScale[lfemale, $CrushDamageType] = $DamageScale[larmor, $CrushDamageType];
$DamageScale[lfemale, $ChaingunDamageType] = $DamageScale[larmor, $ChaingunDamageType];
$DamageScale[lfemale, $PlasmaDamageType] = $DamageScale[larmor, $PlasmaDamageType];
$DamageScale[lfemale, $TurretDamageType] = $DamageScale[larmor, $TurretDamageType];
$DamageScale[lfemale, $DiscDamageType] = $DamageScale[larmor, $DiscDamageType];
$DamageScale[lfemale, $RocketDamageType] = $DamageScale[larmor, $RocketDamageType];
$DamageScale[lfemale, $DebrisDamageType] = $DamageScale[larmor, $DebrisDamageType];
$DamageScale[lfemale, $GrenadeDamageType] = $DamageScale[larmor, $GrenadeDamageType];
$DamageScale[lfemale, $LaserDamageType] = $DamageScale[larmor, $LaserDamageType];
$DamageScale[lfemale, $MortarDamageType] = $DamageScale[larmor, $MortarDamageType];
$DamageScale[lfemale, $BlasterDamageType] = $DamageScale[larmor, $BlasterDamageType];
$DamageScale[lfemale, $ELFDamageType] = $DamageScale[larmor, $ELFDamageType];
$DamageScale[lfemale, $MineDamageType] = $DamageScale[larmor, $MineDamageType];

$ItemMax[lfemale, Blaster] = $ItemMax[larmor, Blaster];
$ItemMax[lfemale, Chaingun] = $ItemMax[larmor, Chaingun];
$ItemMax[lfemale, Disclauncher] = $ItemMax[larmor, Disclauncher];
$ItemMax[lfemale, GrenadeLauncher] = $ItemMax[larmor, GrenadeLauncher];
$ItemMax[lfemale, Mortar] = $ItemMax[larmor, Mortar];
$ItemMax[lfemale, RocketLauncher] = $ItemMax[larmor, RocketLauncher];
$ItemMax[lfemale, PlasmaGun] = $ItemMax[larmor, PlasmaGun];
$ItemMax[lfemale, FlameThrower] = $ItemMax[larmor, FlameThrower];
$ItemMax[lfemale, LaserRifle] = $ItemMax[larmor, LaserRifle];
$ItemMax[lfemale, EnergyRifle] = $ItemMax[larmor, EnergyRifle];
$ItemMax[lfemale, MineAmmo] = $ItemMax[larmor, MineAmmo];
$ItemMax[lfemale, Grenade] = $ItemMax[larmor, Grenade];
$ItemMax[lfemale, Beacon] = $ItemMax[larmor, Beacon];

$ItemMax[lfemale, BulletAmmo] = $ItemMax[larmor, BulletAmmo];
$ItemMax[lfemale, PlasmaAmmo] = $ItemMax[larmor, PlasmaAmmo];
$ItemMax[lfemale, DiscAmmo] = $ItemMax[larmor, DiscAmmo];
$ItemMax[lfemale, GrenadeAmmo] = $ItemMax[larmor, GrenadeAmmo];
$ItemMax[lfemale, MortarAmmo] = $ItemMax[larmor, MortarAmmo];

$ItemMax[lfemale, EnergyPack] = $ItemMax[larmor, EnergyPack];
$ItemMax[lfemale, RepairPack] = $ItemMax[larmor, RepairPack];
$ItemMax[lfemale, ShieldPack] = $ItemMax[larmor, ShieldPack];
$ItemMax[lfemale, CommandPack] = $ItemMax[larmor, CommandPack];
$ItemMax[lfemale, SensorJammerPack] = $ItemMax[larmor, SensorJammerPack];
$ItemMax[lfemale, MotionSensorPack] = $ItemMax[larmor, MotionSensorPack];
$ItemMax[lfemale, PulseSensorPack] = $ItemMax[larmor, PulseSensorPack];
$ItemMax[lfemale, DeployableSensorJammerPack] = $ItemMax[larmor, DeployableSensorJammerPack];
$ItemMax[lfemale, CameraPack] = $ItemMax[larmor, CameraPack];
$ItemMax[lfemale, TurretPack] = $ItemMax[lfemale, TurretPack];
$ItemMax[lfemale, HeavyTurretPack] = $ItemMax[larmor, HeavyTurretPack];
$ItemMax[lfemale, AmmoPack] = $ItemMax[larmor, AmmoPack];
$ItemMax[lfemale, RepairKit] = $ItemMax[larmor, RepairKit];
$ItemMax[lfemale, DeployableInvPack] = $ItemMax[larmor, DeployableInvPack];
$ItemMax[lfemale, DeployableAmmoPack] = $ItemMax[larmor, DeployableAmmoPack];
$ItemMax[lfemale, DeployableGenPack] = $ItemMax[larmor, DeployableGenPack];
$ItemMax[lfemale, DeployableEchoPack] = $ItemMax[larmor, DeployableEchoPack];

$MaxWeapons[lfemale] = $MaxWeapons[larmor];

//------------------------------------------------------------------
// Light female data:
//------------------------------------------------------------------
PlayerData lfemale
{
  className = "Armor";
  shapeFile = "lfemale";
  flameShapeName = "lflame";
  shieldShapeName = "shield";
  damageSkinData = "armorDamageSkins";
  debrisId = playerDebris;
  shadowDetailMask = 1;

  canCrouch = true;
  jetSound = SoundJetLight;
  mapFilter = 1;
  mapIcon = "M_player";
  visibleToSensor = True;

  maxJetSideForceFactor = 0.8;
  maxJetForwardVelocity = 22;
  minJetEnergy = 1;
  jetForce = 236;
  jetEnergyDrain = 0.8;

  maxDamage = $Armor[_default, health] * 0.66;

  maxForwardSpeed = $Armor[_default, handling, forward] * 1.375;
  maxBackwardSpeed = $Armor[_default, handling, backward] * 1.44;
  maxSideSpeed = $Armor[_default, handling, strafe] * 1.25;

  groundForce = $Armor[_default, handling, ground] * 1.125;
  groundTraction = $Armor[_default, handling, traction];
  mass = $Armor[_default, handling, mass] * 0.692;
  maxEnergy = $Armor[_default, energy, max] * 0.75;
  drag = $Armor[_default, handling, drag];
  density = $Armor[_default, handling, density] * 0.8;

  minDamageSpeed = $Armor[_default, damageRatio, speed] * 1.25; 
  damageScale = $Armor[_default, damageRatio, scale] * 1.0;

  jumpImpulse = $Armor[_default, handling, impulse] * 0.69;
  jumpSurfaceMinDot = $Armor[_default, handling, surface];

  // animation data:
  // animation name, one shot, exclude, direction,
  // firstPerson, chaseCam, thirdPerson, signalThread

  // movement animations:
  // movement animations:
  animData[0]  = { "root", none, 1, true, true, true, false, 0 };
  animData[1]  = { "run", none, 1, true, false, true, false, 3 };
  animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
  animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
  animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
  animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
  animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
  animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
  animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
  animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
  animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
  animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
  animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
  animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
  animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
  animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
  animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
  animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
  animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
  animData[19] = { "jet", none, 1, true, true, true, false, 3 };

  // misc. animations:
  animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
  animData[21] = { "throw", none, 1, true, false, false, false, 3 };
  animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
  animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
  animData[24] = { "apc root", none, 1, false, false, false, false, 3 };

  // death animations:
  animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

  // signal moves:
  animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
  animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
  animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
  animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
  animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

  // celebraton animations:
  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
  animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
  animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

  // taunt anmations:
  animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
  animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

  // poses:
  animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
  animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

  // Bonus wave
  animData[50] = { "wave", none, 1, true, false, false, true, 1 };

  rFootSounds = {
    SoundLFootRSoft,
    SoundLFootRHard,
    SoundLFootRSoft,
    SoundLFootRHard,
    SoundLFootRSoft,
    SoundLFootRSoft,
    SoundLFootRSoft,
    SoundLFootRHard,
    SoundLFootRSnow,
    SoundLFootRSoft,
    SoundLFootRSoft,
    SoundLFootRSoft,
    SoundLFootRSoft,
    SoundLFootRSoft,
    SoundLFootRSoft
  }; 
 
  lFootSounds = {
    SoundLFootLSoft,
    SoundLFootLHard,
    SoundLFootLSoft,
    SoundLFootLHard,
    SoundLFootLSoft,
    SoundLFootLSoft,
    SoundLFootLSoft,
    SoundLFootLHard,
    SoundLFootLSnow,
    SoundLFootLSoft,
    SoundLFootLSoft,
    SoundLFootLSoft,
    SoundLFootLSoft,
    SoundLFootLSoft,
    SoundLFootLSoft
  };

  footPrints = { 0, 1 };

  boxWidth = 0.5;
  boxDepth = 0.5;
  boxNormalHeight = 2.3;
  boxCrouchHeight = 1.8;

  boxNormalHeadPercentage  = 0.85;
  boxNormalTorsoPercentage = 0.53;
  boxCrouchHeadPercentage  = 0.88;
  boxCrouchTorsoPercentage = 0.35;

  boxHeadLeftPercentage  = 0;
  boxHeadRightPercentage = 1;
  boxHeadBackPercentage  = 0;
  boxHeadFrontPercentage = 1;
};
