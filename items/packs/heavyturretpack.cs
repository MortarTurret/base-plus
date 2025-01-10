ItemImageData HeavyTurretPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData HeavyTurretPack
{
	description = "Heavy Turret";
	shapeFile = "magcargo";
	className = "Backpack";
  heading = "dDeployables";
	imageType = HeavyTurretPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HeavyTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}

	else {
		Player::deployItem(%player,%item);
	}
}

function HeavyTurretPack::onDeploy(%player,%item,%pos)
{
	if (HeavyTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function HeavyTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player, 4.5)) {
			%obj = getObjectType($los::object);

			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
        %set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$HeavyTurretBoxMaxLength,$HeavyTurretBoxMaxWidth,$HeavyTurretBoxMaxHeight,0);
				%num = CountObjects(%set, "HeavyDeployableTurret", %num);

				deleteObject(%set);

				if($MaxNumHeavyTurretsInBox > %num) {
          %set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$HeavyTurretBoxMinLength,$HeavyTurretBoxMinWidth,$HeavyTurretBoxMinHeight,0);
					%num = CountObjects(%set, "HeavyDeployableTurret", %num);

					deleteObject(%set);

					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {

							if(checkDeployArea(%client, $los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("hellfiregun", "Turret", HeavyDeployableTurret, true);

                addToSet("MissionCleanup", %turret);

								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"HVY Turret#" @ $totalNumHeavyTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client, 0, "Heavy Remote Turret deployed");

								playSound(SoundPickupBackpack, $los::position);

								$TeamItemCount[GameBase::getTeam(%player) @ "HeavyTurretPack"]++;

								echo("MSG: ", %client, " deployed a Heavy Remote Turret");

								//	Remote turrets - kill points to player that deploy them
								Client::setOwnedObject( %client, %turret ); 
								Client::setOwnedObject( %client, %player );

								return true;
							}
						}

						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 

					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other heavy remote turrets");
				}

        else 
					Client::sendMessage(%client,0,"Interference from other heavy remote turrets in the area");
			}

			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}

		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}

	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for heavy remote turrets");

	return false;
}

function checkDeployArea(%client,%pos)
{
  %set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set, $StaticObjectType | $ItemObjectType | $SimPlayerObjectType, %pos, 1, 1, 1, 1);

	if(!%num) {
		deleteObject(%set);
		
    return 1;
	}

	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
		%obj = Group::getObject(%set,0);	

		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");

		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;	
}