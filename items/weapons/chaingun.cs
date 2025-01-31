
$weapon = "Chaingun";
$ammo = "BulletAmmo";
$AutoUse[$weapon] = true;
$WeaponAmmo[$weapon] = $ammo;
$SellAmmo[$ammo] = 25; // sell or drop amount
$AmmoPackMax[$ammo] = 150;
Item::AddWeaponToSwitchCycle( $weapon );
Item::AddDamageType( "Chaingun" );

ExplosionData bulletExp0
{
   shapeName = "chainspk.dts";
   soundId   = ricochet1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData bulletExp1
{
   shapeName = "chainspk.dts";
   soundId   = ricochet2;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 0.5 };
   colors[2]  = { 1.0, 1.0, 0.5 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData bulletExp2
{
   shapeName = "chainspk.dts";
   soundId   = ricochet3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0,  0.0, 0.0 };
   colors[1]  = { 0.75, 1.0, 1.0 };
   colors[2]  = { 0.75, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};


//--------------------------------------
BulletData ChaingunBullet01
{
  aimDeflection      = 0.0005;
  bulletHoleIndex    = 0;
  bulletShapeName    = "bullet.dts";
  damageClass        = 0;
  damageType         = $ChaingunDamageType;
  damageValue        = 0.07;
  explosionTag       = bulletExp0;
  expRandCycle       = 0.025;
  inheritedVelocityScale = 2;
  isVisible          = true;
  mass               = 0.08;
  muzzleVelocity     = 350.0;
  totalTime          = 1.5;
  tracerLength       = 30;
  tracerPercentage   = 1.0;
};

BulletData ChaingunBullet02
{
  aimDeflection      = 0.0006;
  bulletHoleIndex    = 0;
  bulletShapeName    = "bullet.dts";
  damageClass        = 0;
  damageType         = $ChaingunDamageType;
  damageValue        = 0.12;
  explosionTag       = bulletExp0;
  expRandCycle       = 0.1;
  inheritedVelocityScale = 2;
  isVisible          = true;
  mass               = 0.075;
  muzzleVelocity     = 360.0;
  totalTime          = 1.5;
  tracerLength       = 30;
  tracerPercentage   = 1.0;
};

BulletData ChaingunBullet03
{
  aimDeflection      = 0.0007;
  bulletHoleIndex    = 0;
  bulletShapeName    = "bullet.dts";
  damageClass        = 0;
  damageType         = $ChaingunDamageType;
  damageValue        = 0.17;
  explosionTag       = bulletExp0;
  expRandCycle       = 0.175;
  inheritedVelocityScale = 2;
  isVisible          = true;
  mass               = 0.07;
  muzzleVelocity     = 370.0;
  totalTime          = 1.5;
  tracerLength       = 30;
  tracerPercentage   = 1.0;
};

BulletData ChaingunBullet04
{
  aimDeflection      = 0.0009;
  bulletHoleIndex    = 0;
  bulletShapeName    = "bullet.dts";
  damageClass        = 0;
  damageType         = $ChaingunDamageType;
  damageValue        = 0.22;
  explosionTag       = bulletExp0;
  expRandCycle       = 0.25;
  inheritedVelocityScale = 2;
  isVisible          = true;
  mass               = 0.065;
  muzzleVelocity     = 380.0;
  totalTime          = 1.5;
  tracerLength       = 30;
  tracerPercentage   = 1.0;
};

BulletData ChaingunBullet05
{
  aimDeflection      = 0.0012;
  bulletHoleIndex    = 0;
  bulletShapeName    = "bullet.dts";
  damageClass        = 0;
  damageType         = $ChaingunDamageType;
  damageValue        = 0.27;
  explosionTag       = bulletExp0;
  expRandCycle       = 0.4;
  inheritedVelocityScale = 2;
  isVisible          = true;
  mass               = 0.06;
  muzzleVelocity     = 390.0;
  totalTime          = 1.5;
  tracerLength       = 30;
  tracerPercentage   = 1.0;
};

BulletData ChaingunBullet06
{
  aimDeflection      = 0.0015;
  bulletHoleIndex    = 0;
  bulletShapeName    = "bullet.dts";
  damageClass        = 0;
  damageType         = $ChaingunDamageType;
  damageValue        = 0.32;
  explosionTag       = bulletExp0;
  expRandCycle       = 0.55;
  inheritedVelocityScale = 2;
  isVisible          = true;
  mass               = 0.055;
  muzzleVelocity     = 400.0;
  totalTime          = 1.5;
  tracerLength       = 30;
  tracerPercentage   = 1.0;
};

BulletData ChaingunBullet07
{
  aimDeflection      = 0.0018;
  bulletHoleIndex    = 0;
  bulletShapeName    = "bullet.dts";
  damageClass        = 0;
  damageType         = $ChaingunDamageType;
  damageValue        = 0.37;
  explosionTag       = bulletExp0;
  expRandCycle       = 0.7;
  inheritedVelocityScale = 2;
  isVisible          = true;
  mass               = 0.05;
  muzzleVelocity     = 410.0;
  totalTime          = 1.5;
  tracerLength       = 30;
  tracerPercentage   = 1.0;
};

BulletData ChaingunBullet08
{
  aimDeflection      = 0.0022;
  bulletHoleIndex    = 0;
  bulletShapeName    = "bullet.dts";
  damageClass        = 0;
  damageType         = $ChaingunDamageType;
  damageValue        = 0.42;
  explosionTag       = bulletExp0;
  expRandCycle       = 0.85;
  inheritedVelocityScale = 2;
  isVisible          = true;
  mass               = 0.045;
  muzzleVelocity     = 420.0;
  totalTime          = 1.5;
  tracerLength       = 30;
  tracerPercentage   = 1.0;
};

BulletData ChaingunBullet09
{
  aimDeflection      = 0.0027;
  bulletHoleIndex    = 0;
  bulletShapeName    = "bullet.dts";
  damageClass        = 0;
  damageType         = $ChaingunDamageType;
  damageValue        = 0.47;
  explosionTag       = bulletExp0;
  expRandCycle       = 1.0;
  inheritedVelocityScale = 2;
  isVisible          = true;
  mass               = 0.04;
  muzzleVelocity     = 425.0;
  totalTime          = 1.5;
  tracerLength       = 30;
  tracerPercentage   = 1.0;
};

BulletData ChaingunBullet10
{
  aimDeflection      = 0.005;
  bulletHoleIndex    = 0;
  bulletShapeName    = "bullet.dts";
  damageClass        = 0;
  damageType         = $ChaingunDamageType;
  damageValue        = 0.11;
  explosionTag       = bulletExp0;
  expRandCycle       = 3.0;
  inheritedVelocityScale = 2;
  isVisible          = true;
  mass               = 0.05;
  muzzleVelocity     = 425.0;
  totalTime          = 1.5;
  tracerLength       = 30;
  tracerPercentage   = 1.0;
};

//----------------------------------------------------------------------------

ItemData BulletAmmo
{
  className = "Ammo";
  description = "Bullet";
  heading = "xAmmunition";
  price = 1;
  shadowDetailMask = 4;
  shapeFile = "ammo1";
};

ItemImageData ChaingunImage
{
	accuFire = true;
	ammoType = BulletAmmo;
	fireTime = 0.2;
	lightColor = { 0.6, 1, 1 };
	lightRadius = 3;
	lightTime = 1;
	lightType = 3;
	mountPoint = 0;
	reloadTime = 0;
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundFireChaingun;
	sfxSpinDown = SoundSpinDown;
	sfxSpinUp = SoundSpinUp;
	shapeFile = "chaingun";
	spinDownTime = 3;
	spinUpTime = 0.5;
	weaponType = 1;
};

ItemData Chaingun
{
  className = "Weapon";
  description = "Chaingun";
  heading = "bWeapons";
  hudIcon = "chain";
  imageType = ChaingunImage;
  price = 125;
  shadowDetailMask = 4;
  shapeFile = "chaingun";
  showWeaponBar = true;
};

function ChaingunImage::onFire(%player, %slot) {
	%ammo = Player::getItemCount(%player, $WeaponAmmo["Chaingun"]);

	if(%ammo) {	
		%muzzle = GameBase::getMuzzleTransform(%player);
		%velocity = Item::getVelocity(%player);
    %heat = %player.__weaponHeat;

    //- Yes, this is a very clunky way to do this... but the game doesn't allow for 
    //- dynamic evaluations or value changes to parced rendering images, so we'll 
    //- have to stick with this for the time being.
    if(%heat < 0.1) {
      Projectile::spawnProjectile("ChaingunBullet01", %muzzle, %player, %velocity, $los::object);
    }

    else if(%heat < 0.2) {
      Projectile::spawnProjectile("ChaingunBullet02", %muzzle, %player, %velocity, $los::object);
    }

    else if(%heat < 0.3) {
      Projectile::spawnProjectile("ChaingunBullet03", %muzzle, %player, %velocity, $los::object);
    }

    else if(%heat < 0.4) {
      Projectile::spawnProjectile("ChaingunBullet04", %muzzle, %player, %velocity, $los::object);
    }

    else if(%heat < 0.5) {
      Projectile::spawnProjectile("ChaingunBullet05", %muzzle, %player, %velocity, $los::object);
    }

    else if(%heat < 0.6) {
      Projectile::spawnProjectile("ChaingunBullet06", %muzzle, %player, %velocity, $los::object);
    }

    else if(%heat < 0.7) {
      Projectile::spawnProjectile("ChaingunBullet07", %muzzle, %player, %velocity, $los::object);
    }

    else if(%heat < 0.8) {
      Projectile::spawnProjectile("ChaingunBullet08", %muzzle, %player, %velocity, $los::object);
    }

    else if(%heat < 0.9) {
      Projectile::spawnProjectile("ChaingunBullet09", %muzzle, %player, %velocity, $los::object);
    }

    else { 
      Projectile::spawnProjectile("ChaingunBullet10", %muzzle, %player, %velocity, $los::object);
    }

    Player::decItemCount(%player, $WeaponAmmo["Chaingun"], 1);
  }

  else {
    GameBase::playSound(%player, SoundDryFire, 0);
  }
}