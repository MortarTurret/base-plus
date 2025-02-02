//----------------------------------------------------------------------------
// Light Armor
//----------------------------------------------------------------------------
$DamageScale[larmor, $LandingDamageType] = $Armor[_default, damageRatio, $LandingDamageType];
$DamageScale[larmor, $ImpactDamageType] = $Armor[_default, damageRatio, $ImpactDamageType];
$DamageScale[larmor, $CrushDamageType] = $Armor[_default, damageRatio, $CrushDamageType];
$DamageScale[larmor, $ChaingunDamageType] = $Armor[_default, damageRatio, $ChaingunDamageType] * 1.2;
$DamageScale[larmor, $PlasmaDamageType] = $Armor[_default, damageRatio, $PlasmaDamageType] * 1.67;
$DamageScale[larmor, $TurretDamageType] = $Armor[_default, damageRatio, $TurretDamageType] * 1.3;
$DamageScale[larmor, $DiscDamageType] = $Armor[_default, damageRatio, $DiscDamageType];
$DamageScale[larmor, $RocketDamageType] = $Armor[_default, damageRatio, $RocketDamageType];
$DamageScale[larmor, $DebrisDamageType] = $Armor[_default, damageRatio, $DebrisDamageType] * 1.2;
$DamageScale[larmor, $GrenadeDamageType] = $Armor[_default, damageRatio, $GrenadeDamageType] * 1.2;
$DamageScale[larmor, $LaserDamageType] = $Armor[_default, damageRatio, $LaserDamageType];
$DamageScale[larmor, $MortarDamageType] = $Armor[_default, damageRatio, $MortarDamageType] * 1.3;
$DamageScale[larmor, $BlasterDamageType] = $Armor[_default, damageRatio, $BlasterDamageType] * 1.3;
$DamageScale[larmor, $ELFDamageType] = $Armor[_default, damageRatio, $ELFDamageType];
$DamageScale[larmor, $MineDamageType] = $Armor[_default, damageRatio, $MineDamageType] * 1.2;

$ItemMax[larmor, Blaster] = $Armor[_default, weapon, Blaster];
$ItemMax[larmor, Chaingun] = $Armor[_default, weapon, Chaingun];
$ItemMax[larmor, Disclauncher] = $Armor[_default, weapon, Disclauncher];
$ItemMax[larmor, GrenadeLauncher] = $Armor[_default, weapon, GrenadeLauncher];
$ItemMax[larmor, Mortar] = $Armor[_default, weapon, Mortar];
$ItemMax[larmor, PlasmaGun] = $Armor[_default, weapon, PlasmaGun];
$ItemMax[larmor, FlameThrower] = $Armor[_default, weapon, FlameThrower] - 1;
$ItemMax[larmor, LaserRifle] = $Armor[_default, weapon, LaserRifle] + 1;
$ItemMax[larmor, EnergyRifle] = $Armor[_default, weapon, EnergyRifle];
$ItemMax[larmor, MineAmmo] = $Armor[_default, misc, MineAmmo];
$ItemMax[larmor, Grenade] = $Armor[_default, misc, Grenade] - 1;
$ItemMax[larmor, Beacon] = $Armor[_default, misc, Beacon] + 3;

$ItemMax[larmor, BulletAmmo] = $Armor[_default, ammo, BulletAmmo] * 0.67;
$ItemMax[larmor, PlasmaAmmo] = $Armor[_default, ammo, PlasmaAmmo] * 0.75;
$ItemMax[larmor, DiscAmmo] = $Armor[_default, ammo, DiscAmmo];
$ItemMax[larmor, GrenadeAmmo] = $Armor[_default, ammo, GrenadeAmmo];
$ItemMax[larmor, MortarAmmo] = $Armor[_default, ammo, MortarAmmo];

$ItemMax[larmor, EnergyPack] = $Armor[_default, pack, EnergyPack];
$ItemMax[larmor, RepairPack] = $Armor[_default, pack, RepairPack];
$ItemMax[larmor, ShieldPack] = $Armor[_default, pack, ShieldPack];
$ItemMax[larmor, CommandPack] = $Armor[_default, pack, CommandPack] - 1;
$ItemMax[larmor, SensorJammerPack] = $Armor[_default, pack, SensorJammerPack];
$ItemMax[larmor, MotionSensorPack] = 0;
$ItemMax[larmor, PulseSensorPack] = $Armor[_default, pack, PulseSensorPack];
$ItemMax[larmor, DeployableSensorJammerPack] = $Armor[_default, pack, DeployableSensorJammerPack];
$ItemMax[larmor, CameraPack] = $Armor[_default, pack, CameraPack];
$ItemMax[larmor, TurretPack] = 0;
$ItemMax[larmor, HeavyTurretPack] = $Armor[_default, pack, HeavyTurretPack];
$ItemMax[larmor, AmmoPack] = $Armor[_default, pack, AmmoPack];
$ItemMax[larmor, RepairKit] = $Armor[_default, pack, RepairKit];
$ItemMax[larmor, DeployableInvPack] = 0;
$ItemMax[larmor, DeployableAmmoPack] = 0;

$MaxWeapons[larmor] = $Armor[_default, weapon, All] - 1;

//------------------------------------------------------------------
// light armor data:
//------------------------------------------------------------------
PlayerData larmor
{
  className = $Armor[_default, className]; 
  shapeFile = "larmor";
  damageSkinData = "armorDamageSkins";
  debrisId = playerDebris;
  flameShapeName = "lflame";
  shieldShapeName = "shield";
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
  // animation name, one shot, direction
  // firstPerson, chaseCam, thirdPerson, signalThread

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
  animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };

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


  // celebration animations:
  animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
  animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
  animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

  // taunt animations:
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

  boxNormalHeadPercentage  = 0.83;
  boxNormalTorsoPercentage = 0.53;
  boxCrouchHeadPercentage  = 0.6666;
  boxCrouchTorsoPercentage = 0.3333;

  boxHeadLeftPercentage  = 0;
  boxHeadRightPercentage = 1;
  boxHeadBackPercentage  = 0;
  boxHeadFrontPercentage = 1;
};