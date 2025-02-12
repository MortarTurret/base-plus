//------------------------------------------------------------------------------
//-  Get the average visible distance of the current mission
//------------------------------------------------------------------------------
function getAVR() {
  %terrain = nameToID("MissionGroup/Landscape/Terrain");

  return %terrain.visibleDistance;
}