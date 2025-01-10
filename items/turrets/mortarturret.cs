ExplosionData mortarExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 1.375;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

//--------------------------------------
GrenadeData MortarTurretShell
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

//--------------------------------------------
TurretData MortarTurret
{
	activationSound = SoundMortarTurretOn;
	castLOS = true;
	className = "Turret";
	damageSkinData = "objectDamageSkins";
	deactivateSound = SoundMortarTurretOff;
	debrisId = defaultDebrisMedium;
	description = "Mortar Turret";
	dopplerVelocity = 0;
	explosionId = LargeShockwave;
	fireSound = SoundMortarTurretFire;
	mapFilter = 2;
	mapIcon = "M_turret";
	maxDamage = 1.0;
	maxEnergy = 45;
	maxGunEnergy = 100;
	minGunEnergy = 45;
	projectileType = MortarTurretShell;
	range = 0;
	reloadDelay = 1.5;
	shadowDetailMask = 8;
	shapeFile = "mortar_turret";
	shieldShapeName = "shield_medium";
	speed = 2.5;
	speedModifier = 2.5;
	supression = false;
	visibleToSensor = true;
	whirSound = SoundMortarTurretTurn;
};
