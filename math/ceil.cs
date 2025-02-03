//------------------------------------------------------------------------------
//-  Round up to the nearest integer 
//------------------------------------------------------------------------------
function ceil(%floatValue) {
  //- If the value is already an integer, just return it
  if(%floatValue == floor(%floatValue)) {
    return %floatValue;
  }

  //- Add 1 to the value to ensure the ceiling will round up
  %adjustedValue = %floatValue + 1;

  //- Apply floor to the adjusted value to get the ceiling
  %adjustedValue = floor(%adjustedValue);

  //- Return the ceiled value
  return %adjustedValue;
}