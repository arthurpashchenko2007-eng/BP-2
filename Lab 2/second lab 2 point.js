function range (start,end) {
    array = []
    for (let i = start; i <= end; i++) {
        array.push(i);
    
    } 
    return array;
}
console.log( range(15,30) );
range(15,30);

function raneOdd (start,end) {
    array = []
    for (let i = start; i <= end; i++) {
        if (i % 2 ==! 0) {
            array.push(i);
        }
    } 
    return array; 
}
console.log( raneOdd(15,30) );