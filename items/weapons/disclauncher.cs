$ammo = "DiscAmmo";
$weapon = "DiscLauncher";
$AmmoPackMax[$ammo] = 15;
$AutoUse[$weapon] = true;
$SellAmmo[$ammo] = 5; // sell or drop amount
$WeaponAmmo[$weapon] = $ammo;

Item::AddWeaponToSwitchCycle( $weapon );
Item::AddDamageType( "Disc" );

//--------------------------------------------------------------------------- //
//- Explosion defs                                                            //
//--------------------------------------------------------------------------- //
ExplosionData heavyDiscExp0 {
   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   faceCamera = true;
   hasLight   = true;
   lightRange = 8.0;
   radFactors = { 0.5, 1.0, 1.0 };
   randomSpin = true;
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;
   timeOne  = 0.850;
   timeScale = 1.5;
   timeZero = 0.250;
};

ExplosionData heavyDiscExp1 {
   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   faceCamera = true;
   hasLight   = true;
   lightRange = 8.0;
   radFactors = { 0.5, 1.0, 1.0 };
   randomSpin = true;
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;
   timeOne  = 0.850;
   timeScale = 1.5;
   timeZero = 0.250;
};

ExplosionData heavyDiscExp2 {
   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   faceCamera = true;
   hasLight   = true;
   lightRange = 8.0;
   radFactors = { 0.5, 1.0, 1.0 };
   randomSpin = true;
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;
   timeOne  = 0.850;
   timeScale = 1.5;
   timeZero = 0.250;
};

//--------------------------------------------------------------------------- //
//- Ammo defs                                                                 //
//--------------------------------------------------------------------------- //
ItemData DiscAmmo {
  description = "Disc";
  className = "Ammo";
  shapeFile = "discammo";
  heading = "xAmmunition";
  shadowDetailMask = 4;
  price = 2;
};

//--------------------------------------------------------------------------- //
//- Projectile defs                                                           //
//--------------------------------------------------------------------------- //
RocketData DiscShell {
  acceleration     = 5.0;
  bulletShapeName = "discb.dts";
  collisionRadius = 0.0;
  damageClass      = 1;
  damageType       = $DiscDamageType;
  damageValue      = 0.5;
  explosionRadius  = 7.5;
  explosionTag    = rocketExp;
  inheritedVelocityScale = 0.5;
  kickBackStrength = 150.0;
  lightColor       = { 0.4, 0.4, 1.0 };
  lightRange       = 5.0;
  liveTime         = 8.0;
  mass            = 2.0;
  muzzleVelocity   = 65.0;
  soundId = SoundDiscSpin;
  terminalVelocity = 80.0;
  totalTime        = 6.5;
  trailLength      = 15;
  trailType        = 1;
  trailWidth       = 0.3;
};

BulletData HeavyDiscShellLeft {
  acceleration      = DiscShell.acceleration;
  aimDeflection     = 0.0075;
  bulletShapeName   = DiscShell.bulletShapeName;
  collisionRadius   = DiscShell.collisionRadius;
  damageClass       = DiscShell.damageClass;
  damageType        = DiscShell.damageType;
  damageValue       = DiscShell.damageValue / 2 * 1.25;
  explosionRadius   = DiscShell.explosionRadius;
  explosionTag      = heavyDiscExp0;
  expRandCycle       = 3.0;
  inheritedVelocityScale = DiscShell.inheritedVelocityScale;
  isVisible          = true;
  kickBackStrength  = DiscShell.kickBackStrength;
  lightColor        = DiscShell.lightColor;
  lightRange        = DiscShell.lightRange;
  liveTime          = DiscShell.liveTime;
  mass              = DiscShell.mass;
  muzzleVelocity    = DiscShell.muzzleVelocity * 0.8;
  rotationPeriod    = 1.75;
  soundId           = SoundDiscSpin;
  terminalVelocity  = DiscShell.terminalVelocity * 0.8;
  totalTime         = DiscShell.totalTime * 1.25;
  tracerLength      = DiscShell.trailLength * 2;
  tracerPercentage  = 1.0;
};

BulletData HeavyDiscShellRight {
  acceleration      = HeavyDiscShellLeft.acceleration;
  aimDeflection     = HeavyDiscShellLeft.aimDeflection;
  bulletShapeName   = HeavyDiscShellLeft.bulletShapeName;
  collisionRadius   = HeavyDiscShellLeft.collisionRadius;
  damageClass       = HeavyDiscShellLeft.damageClass;
  damageType        = HeavyDiscShellLeft.damageType;
  damageValue       = HeavyDiscShellLeft.damageValue;
  explosionRadius   = HeavyDiscShellLeft.explosionRadius;
  explosionTag      = HeavyDiscShellLeft.explosionTag;
  expRandCycle      = HeavyDiscShellLeft.expRandCycle;
  inheritedVelocityScale = HeavyDiscShellLeft.inheritedVelocityScale;
  isVisible         = HeavyDiscShellLeft.isVisible;
  kickBackStrength  = HeavyDiscShellLeft.kickBackStrength;
  lightColor        = HeavyDiscShellLeft.lightColor;
  lightRange        = HeavyDiscShellLeft.lightRange;
  liveTime          = HeavyDiscShellLeft.liveTime;
  mass              = HeavyDiscShellLeft.mass;
  muzzleVelocity    = HeavyDiscShellLeft.muzzleVelocity;
  rotationPeriod    = HeavyDiscShellLeft.rotationPeriod * -1;
  soundId           = HeavyDiscShellLeft.soundId;
  terminalVelocity  = HeavyDiscShellLeft.terminalVelocity;
  totalTime         = HeavyDiscShellLeft.totalTime;
  tracerLength      = HeavyDiscShellLeft.tracerLength;
  tracerPercentage  = HeavyDiscShellLeft.tracerPercentage;
};

//--------------------------------------------------------------------------- //
//- Image defs                                                                //
//--------------------------------------------------------------------------- //
ItemImageData DiscLauncherImage {
  accuFire = true;
  ammoType = DiscAmmo;
  fireTime = 1.25;
  mountPoint = 0;
  projectileType = DiscShell;
  reloadTime = 0.25;
  sfxActivate = SoundPickUpWeapon;
  sfxFire = SoundFireDisc;
  sfxReady = SoundDiscSpin;
  sfxReload = SoundDiscReload;
  shapeFile = "disc";
  spinUpTime = 0.25;
  weaponType = 3;
};

ItemImageData HeavyDiscLauncherImage {
  accuFire = false;
  fireTime = 0;
  mountOffset = { 0, 0, -0.15 };
  mountPoint = DiscLauncherImage.mountPoint;
  mountRotation = { 0, 0, 0 };
  reloadTime = 0;
  shapeFile = "paintgun";
  spinUpTime = 0;
  weaponType = DiscLauncherImage.weaponType;
};

ItemImageData HeavyDiscLauncherLeftImage {
  accuFire = false;
  ammoType = DiscLauncherImage.ammoType;
  fireTime = DiscLauncherImage.fireTime;
  mountPoint = DiscLauncherImage.mountPoint;
  mountRotation = { 0, 1.21, 0 };
  projectileType = HeavyDiscShellLeft;
  reloadTime = DiscLauncherImage.reloadTime;
  sfxActivate = SoundPickUpWeapon;
  sfxFire = DiscLauncherImage.sfxFire;
  sfxReady = DiscLauncherImage.sfxReady;
  sfxReload = DiscLauncherImage.sfxReload;
  shapeFile = DiscLauncherImage.shapeFile;
  spinUpTime = DiscLauncherImage.spinUpTime;
  weaponType = DiscLauncherImage.weaponType;
};

ItemImageData HeavyDiscLauncherRightImage {
  accuFire = false;
  ammoType = DiscLauncherImage.ammoType;
  fireTime = DiscLauncherImage.fireTime;
  mountPoint = DiscLauncherImage.mountPoint;
  mountRotation = { 0, -1.21, 0 };
  projectileType = HeavyDiscShellRight;
  reloadTime = DiscLauncherImage.reloadTime;
  sfxFire = DiscLauncherImage.sfxFire;
  // sfxReady = DiscLauncherImage.sfxReady;
  sfxReady = SoundMortarIdle;
  sfxReload = DiscLauncherImage.sfxReload;
  shapeFile = DiscLauncherImage.shapeFile;
  spinUpTime = DiscLauncherImage.spinUpTime;
  weaponType = DiscLauncherImage.weaponType;
};

//--------------------------------------------------------------------------- //
//- Item defs                                                                 //
//--------------------------------------------------------------------------- //
ItemData DiscLauncher
{
  className = "Weapon";
  description = "Disc Launcher";
  heading = "bWeapons";
  hudIcon = "disk";
  imageType = DiscLauncherImage;
  price = 150;
  shadowDetailMask = 4;
  shapeFile = "disc";
  showWeaponBar = true;
};

ItemData HeavyDiscLauncher
{
  className = "Weapon";
  description = "Heavy Disc Launcher";
  heading = "bWeapons";
  hudIcon = "disk";
  imageType = HeavyDiscLauncherImage;
  price = 150;
  shadowDetailMask = 4;
  shapeFile = "disc";
  showInventory = false;
  showWeaponBar = true;
};

ItemData HeavyDiscLauncherLeftExtra
{
  className = "Weapon";
  description = "Heavy Disc Launcher";
  heading = "bWeapons";
  hudIcon = "disk";
  imageType = HeavyDiscLauncherLeftImage;
  price = 0;
  shadowDetailMask = 4;
  shapeFile = "force";
  showInventory = false;
  showWeaponBar = false;
};

ItemData HeavyDiscLauncherRightExtra
{
  className = "Weapon";
  description = "Heavy Disc Launcher";
  heading = "bWeapons";
  hudIcon = "disk";
  imageType = HeavyDiscLauncherRightImage;
  price = 0;
  shadowDetailMask = 4;
  shapeFile = "force";
  showInventory = false;
  showWeaponBar = false;
};

//--------------------------------------------------------------------------- //
//- Callback event methods                                                    //
//--------------------------------------------------------------------------- //
  //- Disc Launcher
  function DiscLauncher::onUse(%player, %slot) {
    Player::mountItem(%player, (%player.__armor == "Heavy") ? HeavyDiscLauncher : DiscLauncher, $WeaponSlot);
  }

  function DiscLauncher::onUnmount(%player, %slot) {
    Player::unmountItem(%player, 4);
    Player::unmountItem(%player, 6);
  }

  function DiscLauncher::onDrop(%player, %item) {
    %state = Player::getItemState(%player, $WeaponSlot);
    
    if(%state != "Fire" && %state != "Reload") {
      Player::unmountItem(%player, 4);
      Player::unmountItem(%player, 6);

      Item::onDrop(%player, %item);
    }
  }

  //- Heavy Disc Launcher
  function HeavyDiscLauncher::onMount(%player, %slot) {
    Player::mountItem(%player, HeavyDiscLauncherLeftExtra, 4);
    Player::mountItem(%player, HeavyDiscLauncherRightExtra, 6);
  }

  function HeavyDiscLauncherImage::onActivate(%player) {
    Player::trigger(%player, 4, true);
    Player::trigger(%player, 6, true);
  }

  function HeavyDiscLauncherImage::onDeactivate(%player) {
    Player::trigger(%player, 4, false);
    Player::trigger(%player, 6, false);
  }

  function HeavyDiscLauncher::onUnmount(%player, %slot) {
    Player::unmountItem(%player, 4);
    Player::unmountItem(%player, 6);
  }

  function HeavyDiscLauncher::onDrop(%player, %item) {
    %state = Player::getItemState(%player, $WeaponSlot);
    %weapon = Player::getMountedItem(%this, $WeaponSlot);
    
    if(%state != "Fire" && %state != "Reload") {
      Player::unmountItem(%player, $WeaponSlot);
      Player::unmountItem(%player, 4);
      Player::unmountItem(%player, 6);

      Player::dropItem(%player, %weapon);

      Item::onDrop(%player, %weapon);
    }
  }