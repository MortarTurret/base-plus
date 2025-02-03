//- ------------------------------------------------------------------------- //
//- New default configuration for all armors                                  //
//- ------------------------------------------------------------------------- //
//- NOTE: All armor values are based off of these values (which allows for 
//- automatic relative scaling of values in the future, if required)

//- ----------------------------------------------------------------------- //
//- Default inventory listing                                               //
//- ----------------------------------------------------------------------- //
  $Armor[_default, basePrice] = 300;
  $Armor[_default, className] = "Armor";
  $Armor[_default, heading] = "aArmor";

//- ----------------------------------------------------------------------- //
//- Default items                                                           //
//- ----------------------------------------------------------------------- //
  //- Default weapon availability
  $Armor[_default, weapon, All] = 3;
  $Armor[_default, weapon, Blaster] = 1;
  $Armor[_default, weapon, Chaingun] = 1;
  $Armor[_default, weapon, Disclauncher] = 1;
  $Armor[_default, weapon, EnergyRifle] = 1;
  $Armor[_default, weapon, GrenadeLauncher] = 1;
  $Armor[_default, weapon, LaserRifle] = 0;
  $Armor[_default, weapon, Mortar] = 0;
  $Armor[_default, weapon, RocketLauncher] = 0;
  $Armor[_default, weapon, PlasmaGun] = 1;
  $Armor[_default, weapon, FlameThrower] = 1;

  //- Default pack availability
  $Armor[_default, pack, EnergyPack] = 1;
  $Armor[_default, pack, RepairPack] = 1;
  $Armor[_default, pack, ShieldPack] = 1;
  $Armor[_default, pack, CommandPack] = 1;
  $Armor[_default, pack, SensorJammerPack] = 1;
  $Armor[_default, pack, MotionSensorPack] = 1;
  $Armor[_default, pack, PulseSensorPack] = 1;
  $Armor[_default, pack, DeployableSensorJammerPack] = 1;
  $Armor[_default, pack, CameraPack] = 1;
  $Armor[_default, pack, TurretPack] = 1;
  $Armor[_default, pack, HeavyTurretPack] = 0;
  $Armor[_default, pack, AmmoPack] = 1;
  $Armor[_default, pack, RepairKit] = 1;
  $Armor[_default, pack, DeployableInvPack] = 1;
  $Armor[_default, pack, DeployableAmmoPack] = 1;
  $Armor[_default, pack, DeployableEchoPack] = 1;
  $Armor[_default, pack, DeployableGenPack] = 1;

  //- Default max ammo pools
  $Armor[_default, ammo, BulletAmmo] = 150;
  $Armor[_default, ammo, PlasmaAmmo] = 40;
  $Armor[_default, ammo, DiscAmmo] = 15;
  $Armor[_default, ammo, GrenadeAmmo] = 15;
  $Armor[_default, ammo, MortarAmmo] = 15;

  //- Default max misc. items
  $Armor[_default, misc, MineAmmo] = 2;
  $Armor[_default, misc, Grenade] = 2;
  $Armor[_default, misc, Beacon] = 2;

//- ----------------------------------------------------------------------- //
//- Default damage ratios                                                   //
//- ----------------------------------------------------------------------- //
  $Armor[_default, damageRatio, $LandingDamageType] = 1.0;
  $Armor[_default, damageRatio, $ImpactDamageType] = 1.0;
  $Armor[_default, damageRatio, $CrushDamageType] = 1.0;
  $Armor[_default, damageRatio, $ChaingunDamageType] = 1.0;
  $Armor[_default, damageRatio, $PlasmaDamageType] = 0.6;
  $Armor[_default, damageRatio, $TurretDamageType] = 1.0;
  $Armor[_default, damageRatio, $DiscDamageType] = 1.0;
  $Armor[_default, damageRatio, $RocketDamageType] = 1.0;
  $Armor[_default, damageRatio, $GrenadeDamageType] = 1.0;
  $Armor[_default, damageRatio, $DebrisDamageType] = 1.0;
  $Armor[_default, damageRatio, $LaserDamageType] = 1.0;
  $Armor[_default, damageRatio, $MortarDamageType] = 1.0;
  $Armor[_default, damageRatio, $BlasterDamageType] = 1.0;
  $Armor[_default, damageRatio, $ELFDamageType] = 1.0;
  $Armor[_default, damageRatio, $MineDamageType] = 1.0;
  $Armor[_default, damageRatio, scale] = 0.005;
  $Armor[_default, damageRatio, speed] = 25;

//- ----------------------------------------------------------------------- //
//- Default health + energy pools                                           //
//- ----------------------------------------------------------------------- //
  $Armor[_default, energy, max] = 80.0;
  $Armor[_default, energy, min] = 1.0;
  $Armor[_default, health] = 1.0;

//- ----------------------------------------------------------------------- //
//- Default physics handling                                                //
//- ----------------------------------------------------------------------- //
  $Armor[_default, handling, mass] = 13.0;
  $Armor[_default, handling, forward] = 8.0;
  $Armor[_default, handling, backward] = $Armor[_default, handling, forward] * 0.87;
  $Armor[_default, handling, density] = 1.5;
  $Armor[_default, handling, drag] = 1.0;
  $Armor[_default, handling, ground] = 35 * $Armor[_default, handling, mass];
  $Armor[_default, handling, impulse] = 110;
  $Armor[_default, handling, drain] = 1;
  $Armor[_default, handling, force] = 320;
  $Armor[_default, handling, jetForward] = 17;
  $Armor[_default, handling, jetStrafe] = $Armor[_default, handling, forward] * 0.1;
  $Armor[_default, handling, strafe] = $Armor[_default, handling, forward] * 0.9;
  $Armor[_default, handling, surface] = 0.2;
  $Armor[_default, handling, traction] = $Armor[_default, handling, density] * 2;

//- ------------------------------------------------------------------------- //
//- Global armor setup                                                        //
//- ------------------------------------------------------------------------- //
  //- Light Armor
  ItemData LightArmor
  {
    heading = $Armor[_default, heading];
    description = "Light Armor";
    className = $Armor[_default, className];
    price = $Armor[_default, basePrice] - 100;
  };

  $ArmorType[Male, LightArmor] = larmor;
  $ArmorName[larmor] = LightArmor;
  $ArmorType[Female, LightArmor] = lfemale;
  $ArmorName[lfemale] = $ArmorName[larmor];

  //- Medium Armor
  ItemData MediumArmor
  {
    heading = $Armor[_default, heading];
    description = "Medium Armor";
    className = $Armor[_default, className];
    price = $Armor[_default, basePrice];
  };

  $ArmorType[Male, MediumArmor] = marmor;
  $ArmorName[marmor] = MediumArmor;
  $ArmorType[Female, MediumArmor] = mfemale;
  $ArmorName[mfemale] = $ArmorName[marmor];

  //- Heavy Armor
  ItemData HeavyArmor
  {
    heading = $Armor[_default, heading];
    description = "Heavy Armor";
    className = $Armor[_default, className];
    price = $Armor[_default, basePrice] + 100;
  };

  $ArmorType[Male, HeavyArmor] = harmor;
  $ArmorType[Female, HeavyArmor] = harmor;
  $ArmorName[harmor] = HeavyArmor;