$weapon = "Mortar";
$ammo = "MortarAmmo";
$AutoUse[$weapon] = true;
$WeaponAmmo[$weapon] = $ammo;
$SellAmmo[$ammo] = 5; // sell or drop amount
$AmmoPackMax[$ammo] = 10;
Item::AddWeaponToSwitchCycle( $weapon );
Item::AddDamageType( "Mortar" );

//--------------------------------------
GrenadeData MortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 325;
   collisionRadius    = 0.65;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.16;
   damageType         = $MortarDamageType;

   explosionRadius    = 25.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 350;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.0375;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//----------------------------------------------------------------------------
ItemData MortarAmmo
{
	className = "Ammo";
	description = "Mortar Ammo";
	price = 5;
	shadowDetailMask = 4;
	shapeFile = "mortarammo";
  heading = "xAmmunition";
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 1.5;
	fireTime = 1.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mortar
{
	className = "Weapon";
	description = "Mortar";
	hudIcon = "mortar";
	imageType = MortarImage;
	price = 375;
	shadowDetailMask = 4;
	shapeFile = "mortargun";
	showWeaponBar = true;
  heading = "bWeapons";
};
