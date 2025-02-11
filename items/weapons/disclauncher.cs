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
  collisionRadius   = 0.2;
  damageClass       = DiscShell.damageClass;
  damageType        = DiscShell.damageType;
  damageValue       = DiscShell.damageValue / 2 * 1.25;
  explosionRadius   = DiscShell.explosionRadius * 1.25;
  explosionTag      = heavyDiscExp0;
  expRandCycle       = 3.0;
  inheritedVelocityScale = DiscShell.inheritedVelocityScale * 1.25;
  isVisible          = true;
  kickBackStrength  = DiscShell.kickBackStrength * 1.5;
  lightColor        = DiscShell.lightColor;
  lightRange        = DiscShell.lightRange * 1.5;
  liveTime          = DiscShell.liveTime * 1.25;
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
  accuFire = false;
  ammoType = DiscAmmo;
  fireTime = 0;
  mountOffset = { 0, 0.05, -0.01 };
  mountPoint = 0;
  mountRotation= { 0, 3.14, 0 };
  reloadTime = 0;
  sfxActivate = SoundPickUpWeapon;
  shapeFile = "paintgun";
  spinUpTime = 0;
  weaponType = 3;
};

ItemImageData LightDiscLauncherImage {
  accuFire = true;
  ammoType = DiscLauncherImage.ammoType;
  fireTime = 1.25;
  mountPoint = 0;
  projectileType = DiscShell;
  reloadTime = 0.25;
  sfxFire = SoundFireDisc;
  sfxReady = SoundDiscSpin;
  sfxReload = SoundDiscReload;
  shapeFile = "disc";
  spinUpTime = 0.25;
  weaponType = DiscLauncherImage.weaponType;
};

ItemImageData HeavyDiscLauncherLeftImage {
  accuFire = false;
  ammoType = DiscLauncherImage.ammoType;
  fireTime = LightDiscLauncherImage.fireTime * 1.1;
  mountPoint = LightDiscLauncherImage.mountPoint;
  mountRotation = { 0, 1.21, 0 };
  projectileType = HeavyDiscShellLeft;
  reloadTime = LightDiscLauncherImage.reloadTime * 1.1;
  sfxFire = LightDiscLauncherImage.sfxFire;
  sfxReady = LightDiscLauncherImage.sfxReady;
  sfxReload = LightDiscLauncherImage.sfxReload;
  shapeFile = LightDiscLauncherImage.shapeFile;
  spinUpTime = LightDiscLauncherImage.spinUpTime * 1.1;
  weaponType = LightDiscLauncherImage.weaponType;
};

ItemImageData HeavyDiscLauncherRightImage {
  accuFire =false;
  ammoType = DiscLauncherImage.ammoType;
  fireTime = HeavyDiscLauncherLeftImage.fireTime;
  mountPoint = HeavyDiscLauncherLeftImage.mountPoint;
  mountRotation = { 0, -1.21, 0 };
  projectileType = HeavyDiscShellRight;
  reloadTime = HeavyDiscLauncherLeftImage.reloadTime;
  sfxFire = HeavyDiscLauncherLeftImage.sfxFire;
  sfxReady = SoundMortarIdle;
  sfxReload = HeavyDiscLauncherLeftImage.sfxReload;
  shapeFile = HeavyDiscLauncherLeftImage.shapeFile;
  spinUpTime = HeavyDiscLauncherLeftImage.spinUpTime;
  weaponType = HeavyDiscLauncherLeftImage.weaponType;
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

ItemData LightDiscLauncher
{
  className = DiscLauncher.className;
  description = "Light " @ DiscLauncher.description;
  heading = DiscLauncher.heading;
  hudIcon = DiscLauncher.hudIcon;
  imageType = LightDiscLauncherImage;
  price = 0;
  shadowDetailMask = DiscLauncher.shadowDetailMask;
  shapeFile = DiscLauncher.shapeFile;
  showInventory = false;
  showWeaponBar = false;
};

ItemData HeavyDiscLauncherLeft
{
  className = DiscLauncher.className;
  description = "Heavy " @ DiscLauncher.description;
  heading = DiscLauncher.heading;
  hudIcon = DiscLauncher.hudIcon;
  imageType = HeavyDiscLauncherLeftImage;
  price = 0;
  shadowDetailMask = DiscLauncher.shadowDetailMask;
  shapeFile = DiscLauncher.shapeFile;
  showInventory = false;
  showWeaponBar = false;
};

ItemData HeavyDiscLauncherRight
{
  className = DiscLauncher.className;
  description = "Heavy " @ DiscLauncher.description;
  heading = DiscLauncher.heading;
  hudIcon = DiscLauncher.hudIcon;
  imageType = HeavyDiscLauncherRightImage;
  price = 0;
  shadowDetailMask = DiscLauncher.shadowDetailMask;
  shapeFile = DiscLauncher.shapeFile;
  showInventory = false;
  showWeaponBar = false;
};

//--------------------------------------------------------------------------- //
//- Callback event methods                                                    //
//--------------------------------------------------------------------------- //
function DiscLauncher::onUse(%player, %slot) {
  Player::mountItem(%player, DiscLauncher, $WeaponSlot);

  if(%player.__armor == "Heavy") {
    Player::mountItem(%player, HeavyDiscLauncherLeft, 4);
    Player::mountItem(%player, HeavyDiscLauncherRight, 6);
  }

  else {
    Player::mountItem(%player, LightDiscLauncher, 4);
  }
}

function DiscLauncher::onSynActivate(%player) {
  Player::trigger(%player, 4, true);
  Player::trigger(%player, 6, true);
}

function DiscLauncher::onSynDectivate(%player) {
  Player::trigger(%player, 4, false);
  Player::trigger(%player, 6, false);
}

function DiscLauncher::onUnmount(%player, %slot) {
  Player::trigger(%player, 4, false);
  Player::trigger(%player, 6, false);

  Player::unmountItem(%player, $WeaponSlot);
  Player::unmountItem(%player, 4);
  Player::unmountItem(%player, 6);
} 