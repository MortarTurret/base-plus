ExplosionData turretExp
{
   shapeName = "fusionex.dts";
   soundId   = turretExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0,  1.0,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $TurretDamageType;

   muzzleVelocity     = 50.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};



//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

TurretData PlasmaTurret
{
	activationSound = SoundPlasmaTurretOn;
	castLOS = true;
	className = "Turret";
	damageSkinData = "objectDamageSkins";
	deactivateSound = SoundPlasmaTurretOff;
	debrisId = defaultDebrisMedium;
	description = "Plasma Turret";
	dopplerVelocity = 0;
	explosionId = LargeShockwave;
	fireSound = SoundPlasmaTurretFire;
	mapFilter = 2;
	mapIcon = "M_turret";
	maxDamage = 1.0;
	maxEnergy = 200;
	maxGunEnergy = 6;
	minGunEnergy = 75;
	projectileType = FusionBolt;
	range = 100;
	reloadDelay = 0.8;
	shadowDetailMask = 8;
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	supression = false;
	visibleToSensor = true;
	whirSound = SoundPlasmaTurretTurn;
};
