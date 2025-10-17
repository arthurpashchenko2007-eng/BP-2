const phonebookHash = {
'Marcus Aurelius': '+123456789',
'Seneca Wilson': '+987654321', 
'William Jackson': '+192837465', 
'Zeno Smith': '+5647382910'}

function findPhoneByNumber (name) {
    return phonebookHash[name];
}
console.log(findPhoneByNumber('William Jackson')); 
console.log(findPhoneByNumber('Marcus Aurelius')); 
console.log(findPhoneByNumber('Seneca Wilson')); 
console.log(findPhoneByNumber('Zeno Smith'));

    