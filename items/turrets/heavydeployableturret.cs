ExplosionData HeavyEnergyExp
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
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

//--------------------------------------
BulletData HeavyFusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = HeavyEnergyExp;
   mass               = 0.05;

   damageClass        = 0;
   damageType         = $TurretDamageType;
   damageValue        = 0.25;

   muzzleVelocity     = 65.0;
   totalTime          = 5.0;
   liveTime           = 3.0;

   lightRange         = 5.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.65;
   isVisible          = True;

   rotationPeriod = 1.25;
};

//--------------------------------------------
TurretData HeavyDeployableTurret
{
	activationSound = SoundPlasmaTurretOn;
	castLOS = true;
	className = "Turret";
	damageSkinData = "objectDamageSkins";
	deactivateSound = SoundPlasmaTurretOff;
	debrisId = defaultDebrisMedium;
	description = "Heavy Remote Turret";
	dopplerVelocity = 0;
	explosionId = LargeShockwave;
	fireSound = SoundPlasmaTurretFire;
	mapFilter = 2;
	mapIcon = "M_turret";
	maxDamage = 0.825;
	maxEnergy = 130;
	maxGunEnergy = 5.5;
	minGunEnergy = 40;
	projectileType = HeavyFusionBolt;
	range = 65;
	reloadDelay = 0.6;
	shadowDetailMask = 8;
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 3.0;
	speedModifier = 1.75;
	supression = false;
	visibleToSensor = true;
	whirSound = SoundPlasmaTurretTurn;
};

function HeavyDeployableTurret::onAdd(%this)
{
	schedule("HeavyDeployableTurret::deploy(" @ %this @ ");", 1, %this);

	GameBase::setRechargeRate(%this, 5);

	%this.shieldStrength = 0.01;

	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Heavy Remote Turret");
	}
}

function HeavyDeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this, 1, "deploy");
}

function HeavyDeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this, true);
}

function HeavyDeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);

  $TeamItemCount[GameBase::getTeam(%this) @ "HeavyTurretPack"]--;
}

// Override base class just in case.
function HeavyDeployableTurret::onPower(%this, %power, %generator) {
	if(%power) {
		%this.shieldStrength = 0.01;

		GameBase::setRechargeRate(%this, 5);
	}

	else {
		%this.shieldStrength = 0;

		GameBase::setRechargeRate(%this, 0);
		Turret::checkOperator(%this);
	}

	GameBase::setActive(%this,%power);
}

function HeavyDeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this, 5);
	GameBase::setActive(%this, true);
}	
