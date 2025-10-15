function inc(num) {
  num.n = num.n + 1;
}

const obj = { n: 5 };
inc(obj);
console.dir(obj);