function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY,
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ String::Escape(%command) @ "\"");
   // issueCommandI takes waypoint 0-1023 in x,y scaled mission area
   // issueCommand takes float mission coords.
   for(%i = 1; %dest[%i] != ""; %i = %i + 1) {
      if(!%dest[%i].muted[%commander])
         issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
   }
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, 
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ String::Escape(%command) @ "\"");
   for(%i = 1; %dest[%i] != ""; %i = %i + 1) {
   	  %dest = %dest[%i];
      if(!%dest.muted[%commander])
         issueTargCommand(%commander, %dest, %cmdIcon, %command, %targIdx);
   }
}

function remoteCStatus(%clientId, %status, %message)
{
   // setCommandStatus returns false if no status was changed.
   // in this case these should just be team says.
   if(setCommandStatus(%clientId, %status, %message))
   {
      if($dedicated)
         echo("COMMANDSTATUS: " @ %clientId @ " \"" @ String::Escape(%message) @ "\"");
   }
   else
      remoteSay(%clientId, true, %message);
}


function Client::takeControl(%clientId, %objectId) {
  // remote control
  if(%objectId == -1) return;

	%player = Client::getOwnedObject(%clientId);
  %playerName = Client::getName(%clientId);

	// If mounted to a vehicle then can't mount any other objects
	if(%player.driver != "" || %player.vehicleSlot != "") return;

  if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId)) {
    //echo(GameBase::getTeam(%objectId) @ " " @ Client::getTeam(%clientId));

   return;
  }

   if(GameBase::getControlClient(%objectId) != -1) {
      echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));

      return;
   }

	%name = GameBase::getDataName(%objectId);

	if(%name != CameraTurret && %name != DeployableTurret && %name != HeavyDeployableTurret)
  {
    if(%objectId.__hotwired) 
		{
      Client::SendMessage(%clientId, 1, "Command Link Failed: Turret " @ %objectId @ " operating under low power.");

      return;
		}

    else if(!GameBase::isPowered(%objectId)) 
		{
      Client::SendMessage(%clientId, 1, "Command Link Failed: Turret " @ %objectId @ " is offline.");

      return;
		}
  }
  
  if(!CommandPack::IsAvailable(%player)) {
    if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && !$TestCheats) {
      Client::SendMessage(%clientId, 1, "Command Link Failed: Operator \"" @ %playerName @ "::" @ %clientId @ "\" unauthorized.");

      return;
    }
  }

  if(GameBase::getDamageState(%objectId) == "Enabled") {
    Client::setControlObject(%clientId, %objectId);
    Client::setGuiMode(%clientId, $GuiModePlay);
  }
}

function remoteCmdrMountObject(%clientId, %objectIdx) {
   Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

function checkControlUnmount(%clientId) {
   %ownedObject = Client::getOwnedObject(%clientId);
   %ctrlObject = Client::getControlObject(%clientId);
   if(%ownedObject != %ctrlObject)
   {
      if(%ownedObject == -1 || %ctrlObject == -1)
         return;
      if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
         return;
      Client::setControlObject(%clientId, %ownedObject);
   }
}

