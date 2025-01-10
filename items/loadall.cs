// do stuff that defines datablocks we need for items
rundir( "server/items/" );
run("damagetypes");
run("shockwave");
run("debris");
run("item");
run("marker");
run("nextweapon");
run("hotwire");

// turrets before weapons because elf/rocket define some datablocks/damagetypes weapons need
rundir( "server/items/turrets/" );
run("deployableturret");
run("heavydeployableturret");
run("elfturret");
run("indoorturret");
run("mortarturret");
run("plasmaturret");
run("rocketturret");
run("turret");

// for weird stuff that affects both turrets and weapon projectiles
rundir( "server/items/special/" );
run("lightning");

// now do weapons so they can define their damage types
rundir( "server/items/weapons/" );
run("blaster");
run("chaingun");
run("disclauncher");
run("elf");
run("grenadelauncher");
run("laserrifle");
run("mortar");
run("plasmagun");
run("flamethrower");
// run("rocketlauncher");
run("repairgun");
run("targetinglaser");

// mine damage type
rundir( "server/items/misc/" );
run("beacon");
run("flag");
run("grenade");
run("mine");
run("repairkit");
run("repairpatch");

// now items not defining damage types, but referencing them
rundir( "server/items/armors/" );
run("armordamageskins");
run("lightarmor");
run("mediumarmor");
run("heavyarmor");

rundir( "server/items/packs/" );
run("ammopack");
run("camerapack");
run("deployableammo");
run("deployableinv");
run("deployablesensorjammerpack");
run("energypack");
run("motionsensorpack");
run("pulsesensorpack");
run("repairpack");
run("commandpack");
run("sensorjammerpack");
run("shieldpack");
run("turretpack");
run("heavyturretpack");

rundir( "server/items/sensors/" );
run("sensor");
run("deployablemotionsensor");
run("deployablepulsesensor");
run("deployablesensor");
run("deployablesensorjammer");


rundir( "server/items/stations/" );
run("station");
run("vehiclestation");
run("ammostation");
run("commandstation");
run("deployablestation");
run("inventorystation");
run("remoteammostation");
run("remoteinventorystation");

rundir( "server/items/vehicles/" );
run("vehicle");
run("hpc");
run("lpc");
run("scout");


rundir( "server/items/" );
run("moveable");
run("staticshape");
run("trigger");
