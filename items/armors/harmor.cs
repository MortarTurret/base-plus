//----------------------------------------------------------------------------
// Heavy Armor
//----------------------------------------------------------------------------
$DamageScale[harmor, $LandingDamageType] = $Armor[_default, damageRatio, $LandingDamageType];
$DamageScale[harmor, $ImpactDamageType] = $Armor[_default, damageRatio, $ImpactDamageType];
$DamageScale[harmor, $CrushDamageType] = $Armor[_default, damageRatio, $CrushDamageType];
$DamageScale[harmor, $ChaingunDamageType] = $Armor[_default, damageRatio, $ChaingunDamageType] * 0.6;
$DamageScale[harmor, $PlasmaDamageType] = $Armor[_default, damageRatio, $PlasmaDamageType] * 0.67;
$DamageScale[harmor, $TurretDamageType] = $Armor[_default, damageRatio, $TurretDamageType] * 0.7;
$DamageScale[harmor, $DiscDamageType] = $Armor[_default, damageRatio, $DiscDamageType] * 0.6;
$DamageScale[harmor, $RocketDamageType] = $Armor[_default, damageRatio, $RocketDamageType] * 0.6;
$DamageScale[harmor, $DebrisDamageType] = $Armor[_default, damageRatio, $DebrisDamageType] * 0.8;
$DamageScale[harmor, $GrenadeDamageType] = $Armor[_default, damageRatio, $GrenadeDamageType] * 0.8;
$DamageScale[harmor, $LaserDamageType] = $Armor[_default, damageRatio, $LaserDamageType] * 0.6;
$DamageScale[harmor, $MortarDamageType] = $Armor[_default, damageRatio, $MortarDamageType] * 0.7;
$DamageScale[harmor, $BlasterDamageType] = $Armor[_default, damageRatio, $BlasterDamageType] * 0.7;
$DamageScale[harmor, $ELFDamageType] = $Armor[_default, damageRatio, $ELFDamageType];
$DamageScale[harmor, $MineDamageType] = $Armor[_default, damageRatio, $MineDamageType] * 0.8;

$ItemMax[harmor, Blaster] = $Armor[_default, weapon, Blaster];
$ItemMax[harmor, Chaingun] = $Armor[_default, weapon, Chaingun];
$ItemMax[harmor, Disclauncher] = $Armor[_default, weapon, Disclauncher];
$ItemMax[harmor, GrenadeLauncher] = $Armor[_default, weapon, GrenadeLauncher];
$ItemMax[harmor, Mortar] = $Armor[_default, weapon, LaserRifle] + 1;
$ItemMax[harmor, PlasmaGun] = $Armor[_default, weapon, PlasmaGun];
$ItemMax[harmor, FlameThrower] = $Armor[_default, weapon, FlameThrower];
$ItemMax[harmor, LaserRifle] = $Armor[_default, weapon, LaserRifle];
$ItemMax[harmor, EnergyRifle] = $Armor[_default, weapon, EnergyRifle];
$ItemMax[harmor, MineAmmo] = $Armor[_default, misc, MineAmmo];
$ItemMax[harmor, Grenade] = $Armor[_default, misc, Grenade] + 3;
$ItemMax[harmor, Beacon] = $Armor[_default, misc, Beacon] - 1;

$ItemMax[harmor, BulletAmmo] = $Armor[_default, ammo, BulletAmmo] * 1.50;
$ItemMax[harmor, PlasmaAmmo] = $Armor[_default, ammo, PlasmaAmmo] * 1.25;
$ItemMax[harmor, DiscAmmo] = $Armor[_default, ammo, DiscAmmo] * 1.34;
$ItemMax[harmor, GrenadeAmmo] = $Armor[_default, ammo, GrenadeAmmo] * 2;
$ItemMax[harmor, MortarAmmo] = $Armor[_default, ammo, MortarAmmo];

$ItemMax[harmor, EnergyPack] = $Armor[_default, pack, EnergyPack];
$ItemMax[harmor, RepairPack] = $Armor[_default, pack, RepairPack];
$ItemMax[harmor, ShieldPack] = $Armor[_default, pack, ShieldPack];
$ItemMax[harmor, CommandPack] = $Armor[_default, pack, CommandPack] - 1;
$ItemMax[harmor, SensorJammerPack] = $Armor[_default, pack, SensorJammerPack];
$ItemMax[harmor, MotionSensorPack] = $Armor[_default, pack, MotionSensorPack];
$ItemMax[harmor, PulseSensorPack] = $Armor[_default, pack, PulseSensorPack];
$ItemMax[harmor, DeployableSensorJammerPack] = $Armor[_default, pack, DeployableSensorJammerPack];
$ItemMax[harmor, CameraPack] = $Armor[_default, pack, CameraPack];
$ItemMax[harmor, TurretPack] = $Armor[_default, pack, TurretPack];
$ItemMax[harmor, HeavyTurretPack] = $Armor[_default, pack, HeavyTurretPack] + 1;
$ItemMax[harmor, AmmoPack] = $Armor[_default, pack, AmmoPack];
$ItemMax[harmor, RepairKit] = $Armor[_default, pack, RepairKit];
$ItemMax[harmor, DeployableInvPack] = $Armor[_default, pack, DeployableInvPack];
$ItemMax[harmor, DeployableAmmoPack] = $Armor[_default, pack, DeployableAmmoPack];

$MaxWeapons[harmor] = $Armor[_default, weapon, All] + 1;

//------------------------------------------------------------------
// Heavy Armor data:
//------------------------------------------------------------------
PlayerData harmor
{
  className = $Armor[_default, className]; 
  shapeFile = "harmor";
  flameShapeName = "hflame";
  shieldShapeName = "shield";
  damageSkinData = "armorDamageSkins";
  debrisId = playerDebris;
  shadowDetailMask = 1;

  canCrouch = true;
  jetSound = SoundJetHeavy;
  mapFilter = 1;
  mapIcon = "M_player";
  visibleToSensor = True;

  maxJetSideForceFactor = $Armor[_default, handling, forward] * 0.048;
  maxJetForwardVelocity = $Armor[_default, handling, jetForward] * 0.71;
  minJetEnergy = $Armor[_default, energy, min];
  jetForce = $Armor[_default, handling, force] * 1.2;
  jetEnergyDrain = $Armor[_default, handling, drain] * 1.1;

  maxDamage = $Armor[_default, health] * 1.32; 
  maxForwardSpeed = $Armor[_default, handling, forward] * 0.8;
  maxBackwardSpeed = $Armor[_default, handling, backward] * 0.8;
  maxSideSpeed = $Armor[_default, handling, strafe] * 0.44;
  groundForce = $Armor[_default, handling, ground] * 0.9;
  groundTraction = $Armor[_default, handling, traction] * 1.5;
  mass = $Armor[_default, handling, mass] * 1.385;
  maxEnergy = $Armor[_default, energy, max] * 1.375;
  drag = $Armor[_default, handling, drag];
  density = $Armor[_default, handling, density] * 1.67;

  minDamageSpeed = $Armor[_default, damageRatio, speed] * 1.0; 
  damageScale = $Armor[_default, damageRatio, scale] * 1.2;

  jumpImpulse = $Armor[_default, handling, impulse] * 1.25;
  jumpSurfaceMinDot = $Armor[_default, handling, surface];

  // animation data:
  // animation name, one shot, exclude, direction,
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
    SoundHFootRSoft,
    SoundHFootRHard,
    SoundHFootRSoft,
    SoundHFootRHard,
    SoundHFootRSoft,
    SoundHFootRSoft,
    SoundHFootRSoft,
    SoundHFootRHard,
    SoundHFootRSnow,
    SoundHFootRSoft,
    SoundHFootRSoft,
    SoundHFootRSoft,
    SoundHFootRSoft,
    SoundHFootRSoft,
    SoundHFootRSoft
  }; 
  lFootSounds ={
    SoundHFootLSoft,
    SoundHFootLHard,
    SoundHFootLSoft,
    SoundHFootLHard,
    SoundHFootLSoft,
    SoundHFootLSoft,
    SoundHFootLSoft,
    SoundHFootLHard,
    SoundHFootLSnow,
    SoundHFootLSoft,
    SoundHFootLSoft,
    SoundHFootLSoft,
    SoundHFootLSoft,
    SoundHFootLSoft,
    SoundHFootLSoft
  };

  footPrints = { 4, 5 };

  boxWidth = 0.8;
  boxDepth = 0.8;
  boxNormalHeight = 2.6;

  boxNormalHeadPercentage  = 0.70;
  boxNormalTorsoPercentage = 0.45;

  boxHeadLeftPercentage  = 0.48;
  boxHeadRightPercentage = 0.70;
  boxHeadBackPercentage  = 0.48;
  boxHeadFrontPercentage = 0.60;
};
