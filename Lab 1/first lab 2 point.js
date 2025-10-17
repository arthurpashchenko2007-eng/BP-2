const Array = [ 15, 'apple', true, -5.5, 'banana', false, 0, 'cherry',
    'date', true, 'elderberry', -100, null, undefined, 42, false,
    'fig', 'grape', true, 'last one', -1
]; 
  const TypeCollection = {}; 
for (const element of Array) {
  const typeName = typeof element;
  if (TypeCollection[typeName]) {
    TypeCollection[typeName]++;
  } else {
    TypeCollection[typeName] = 1;
  }
}
