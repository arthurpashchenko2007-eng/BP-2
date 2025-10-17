function average (a,b) {
  return (a+b)/2;

} 
 function square (x) {
return x * x;

}
function cube (x) {
return x * x * x;

} 
 function canculate () {
   const Array = []; 
   for (let i = 0; i < 9; i++) {
   const squareResult = square(i);
   const cubeResult  = cube(i);
   const averageResult =  (squareResult, cubeResult);
   
   Array.push(averageResult);
 }
return Array;
   }
console.log(canculate());