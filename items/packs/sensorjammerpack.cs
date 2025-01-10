//----------------------------------------------------------------------------
ItemImageData SensorJammerPackImage
{
  firstPerson = false;
  maxEnergy = 10;  // Energy used/sec for sustained weapons
  mountOffset = { 0, -0.05, 0 };
  mountPoint = 2;
  mountRotation = { 0, 0, 0 };
  sfxFire = SoundJammerOn;
  shapeFile = "sensorjampack";
  weaponType = 2;  // Sustained
};

ItemData SensorJammerPack
{
	className = "Backpack";
	description = "Sensor Jammer Pack";
	hiliteOnActive = true;
	hudIcon = "sensorjamerpack";
	imageType = SensorJammerPackImage;
	price = 200;
	shadowDetailMask = 4;
	shapeFile = "sensorjampack";
	showWeaponBar = true;
  heading = "cBackpacks";
};

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}
