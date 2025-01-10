ExplosionData energyExp
{
   shapeName = "enex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = True;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $TurretDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------------
TurretData DeployableTurret
{
	activationSound = SoundRemoteTurretOn;
	castLOS = true;
	className = "Turret";
	damageSkinData = "objectDamageSkins";
	deactivateSound = SoundRemoteTurretOff;
	debrisId = flashDebrisMedium;
	description = "Remote Turret";
	dopplerVelocity = 0;
	explosionId = flashExpMedium;
	fireSound = SoundRemoteTurretFire;
	mapFilter = 2;
	mapIcon = "M_turret";
	maxDamage = 0.65;
	maxEnergy = 60;
	maxGunEnergy = 5;
	minGunEnergy = 6;
	projectileType = MiniFusionBolt;
	range = 30;
	reloadDelay = 0.4;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	shadowDetailMask = 4;
	shapeFile = "remoteturret";
	shieldShapeName = "shield";
	speed = 4.0;
	speedModifier = 1.5;
	supression = false;
	visibleToSensor = true;
};

function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");", 1, %this);

	GameBase::setRechargeRate(%this, 5);

	%this.shieldStrength = 0;

	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
	}
}

function DeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this, 1, "deploy");
}

function DeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);

  $TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}

// Override base class just in case.
function DeployableTurret::onPower(%this,%power,%generator) {}

function DeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	
